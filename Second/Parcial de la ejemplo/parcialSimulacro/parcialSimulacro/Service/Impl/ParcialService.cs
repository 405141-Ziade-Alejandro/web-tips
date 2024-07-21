using AutoMapper;
using parcialSimulacro.Dto;
using parcialSimulacro.Models;
using parcialSimulacro.Repository;
using parcialSimulacro.Validator;

namespace parcialSimulacro.Service.Impl;

public class ParcialService : IParcialService
{
    private readonly IMapper _mapper;
    private readonly IAlbanilesRepository _albanilesRepository;
    private readonly IObrasRepository _obrasRepository;

    private readonly AlbanilXObraValidator _albanilXObraValidator;
    private readonly AlbanilValidator _albanilValidator;

    public ParcialService(IMapper mapper, IAlbanilesRepository albanilesRepository, IObrasRepository obrasRepository, AlbanilXObraValidator albanilXObraValidator, AlbanilValidator albanilValidator)
    {
        _mapper = mapper;
        _albanilesRepository = albanilesRepository;
        _obrasRepository = obrasRepository;
        _albanilXObraValidator = albanilXObraValidator;
        _albanilValidator = albanilValidator;
    }


    public async Task<Responce<List<ObraDto>>> GetAllObrasAsync()
    {
        var responce = new Responce<List<ObraDto>>();

        try
        {
            var obrasList = await _obrasRepository.GetAllObrasAsync();
            var obrasListDto = _mapper.Map<List<ObraDto>>(obrasList);
            responce.Data = obrasListDto;
            responce.Success = true;
        }
        catch (Exception e)
        {
            responce.Success = false;
            responce.message = "error";
            throw;
        }
        return responce;
    }

    public async Task<Responce<AlbanilXObraDto>> PostAlbanilXObraAsync(AlbanilXObraDto albanilXObraDto)
    {
        var responce = new Responce<AlbanilXObraDto>();
        var validation = await _albanilXObraValidator.ValidateAsync(albanilXObraDto);
        if (!validation.IsValid)
        {
            var errorMEssages = string.Join(", ", validation.Errors.Select(x => x.ErrorMessage));
            responce.Success = false;
            responce.message = errorMEssages;
            return responce;
        }
        
        
        try
        {
            var albanilExist = await _albanilesRepository.GetAlbanilById(albanilXObraDto.IdAlbanil);

            if (albanilExist==null|| !albanilExist.Activo)
            {
                responce.Success = false;
                responce.message = "no esta activo o no existe";
                return responce;
            }

            var albanilYaInObra =
                await _obrasRepository.AlbanilInObra(albanilXObraDto.IdObra, albanilXObraDto.IdAlbanil);
            if (albanilYaInObra)
            {
                responce.Success = false;
                responce.message = "El albanil ya esta en esa obra";
                return responce;
            }
            
            
            var albanilXobra = _mapper.Map<AlbanilesXObra>(albanilXObraDto);
            albanilXobra.Id = Guid.NewGuid();
            albanilXobra.FechaAlta=DateTime.Now;
            responce.message = "exito";
            
            await _obrasRepository.AddAlbanilToObra(albanilXobra);
            responce.Success = true;
        }
        catch (Exception e)
        {
            responce.Success = false;
            responce.message = "error";
            throw;
        }
        return responce;
    }

    public async Task<Responce<AlbanilDto>> PostAlbanilAsync(AlbanilDto albanilDto)
    {
        var responce = new Responce<AlbanilDto>();
        var validation = await _albanilValidator.ValidateAsync(albanilDto);
        if (!validation.IsValid)
        {
            var errorMEssages = string.Join(", ", validation.Errors.Select(x => x.ErrorMessage));
            responce.Success = false;
            responce.message = errorMEssages;
            return responce;
        }
        try
        {
            var existentAlbanil = await _albanilesRepository.AlbanilExist(albanilDto.Dni);
            if (existentAlbanil)
            {
                responce.Success = false;
                responce.message = "albañil ya existe";
                return responce;
            }
            
            var albanil = _mapper.Map<Albanile>(albanilDto);
            albanil.Activo = true;
            albanil.FechaAlta=DateTime.Now;
            albanil.Id = Guid.NewGuid();
            
            await _albanilesRepository.AddAlbanil(albanil);
            responce.Success = true;
            responce.message = "albanil se agrego con exito";
        }
        catch (Exception e)
        {
            responce.Success = false;
            responce.message = "error";
            throw;
        }

        return responce;
    }

    public async Task<Responce<List<AlbanilDto>>> GetAlbanilesNotObraAsync(Guid idObra)
    {
        
        var responce = new Responce<List<AlbanilDto>>();
        try
        {
            var albanilesList = await _obrasRepository.GetAlbanilesNotInObra(idObra);
            var albanilesDtoList = _mapper.Map<List<AlbanilDto>>(albanilesList);
            responce.Data = albanilesDtoList;
            responce.Success = true;
        }
        catch (Exception e)
        {
            responce.Success = false;
            responce.message = "error";
            throw;
        }

        return responce;
    }
}
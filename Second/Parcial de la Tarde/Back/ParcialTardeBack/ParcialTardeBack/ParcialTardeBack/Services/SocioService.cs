using AutoMapper;
using ParcialTardeBack.Dto;
using ParcialTardeBack.Interfaces;
using ParcialTardeBack.Interfaces.Services;
using ParcialTardeBack.Models;
using ParcialTardeBack.Response;

namespace ParcialTardeBack.Services;

public class SocioService : ISocioService
{
    private readonly ISocioRepository _socioRepository;
    private readonly IMapper _mapper;

    public SocioService(ISocioRepository socioRepository, IMapper mapper)
    {
        _socioRepository = socioRepository;
        _mapper = mapper;
    }

    public async Task<ApiResponse<List<SocioDto>>> GetAll()
    {
        var socios = await _socioRepository.GetAll();
        if (socios.Count > 0)
        {
            var sociosDto = _mapper.Map<List<SocioDto>>(socios);
            return new ApiResponse<List<SocioDto>>
            {
                Data = sociosDto
            };
        }
        throw new Exception("No se encontraron socios");
    }

    public async Task<ApiResponse<SocioDto>> GetById(Guid id)
    {
        var socio = await _socioRepository.GetById(id);
        if (socio != null)
        {
            var socioDto = _mapper.Map<SocioDto>(socio);
            return new ApiResponse<SocioDto>
            {
                Data = socioDto
            };
        }
        throw new Exception("No se encontro ese id");
    }

    public async Task<ApiResponse<SocioDto>> AltaSocio(SocioDto socio)
    {
        var socioEntity = _mapper.Map<Socio>(socio);
        var socioSave = _socioRepository.AltaSocio(socioEntity);
        SocioDto saveDto = _mapper.Map<SocioDto>(socioSave);

        return new ApiResponse<SocioDto>
        {
            Data = saveDto
        };
    }
}
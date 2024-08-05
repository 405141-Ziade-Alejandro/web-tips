using AutoMapper;
using BackEnd.Dto;
using BackEnd.Models;
using BackEnd.Repository;
using BackEnd.Validator;

namespace BackEnd.Service.Impl;

public class EmpleadoService : IEmpleadoService
{
    private readonly IMapper _mapper;
    private readonly IEmpleadoRepository _empleadoRepository;
    private readonly EmpleadoValidator _validator;

    public EmpleadoService(IMapper mapper, IEmpleadoRepository empleadoRepository, EmpleadoValidator validator)
    {
        _mapper = mapper;
        _empleadoRepository = empleadoRepository;
        _validator = validator;
    }

    public async Task<ResultadoBase<List<EmpleadoDto>>> GetAllEmpleadosAsync()
    {
        

        var resultado = new ResultadoBase<List<EmpleadoDto>>();

        try
        {
            var lista = await _empleadoRepository.GetAllEmpleados();

            var listaDto = new List<EmpleadoDto>();
            foreach (Empleado empleado in lista)
            {
                var empleadoDto = _mapper.Map<EmpleadoDto>(empleado);
                var sucursal = await _empleadoRepository.GetSurcursalAsync(empleado.IdSucursal);
                empleadoDto.Ciudad= await _empleadoRepository.GetCiudadAsync(sucursal.IdCiudad);
                empleadoDto.Sucursal = sucursal.Nombre;
                empleadoDto.Cargo = await _empleadoRepository.GetCargoAsync(empleado.IdCargo);
                listaDto.Add(empleadoDto);
            }

            resultado.Resultado = listaDto;
            resultado.Success = true;
            resultado.Message = "exito";
        }
        catch (Exception e)
        {
            resultado.Success = false;
            resultado.Message = "error";
            Console.WriteLine(e);
            throw;
        }
        
        return resultado;
    }

    public async Task<ResultadoBase<EmpleadoAltaDto>> PostEmpleadoAsync(EmpleadoAltaDto empleadoAltaDto)
    {
        var responce = new ResultadoBase<EmpleadoAltaDto>();
        var validator = await _validator.ValidateAsync(empleadoAltaDto);

        if (!validator.IsValid)
        {
            var errores = string.Join(", ", validator.Errors.Select(x => x.ErrorMessage));
            responce.Success = false;
            responce.Message = errores;
            return responce;
        }
        
        try
        {
            var check = await _empleadoRepository.GetEmpleadoByDni(empleadoAltaDto.Dni);
            if (check)
            {
                responce.Success = false;
                responce.Message = "ya existe ese empleado";
                return responce;
            }
            
            var empleado = _mapper.Map<Empleado>(empleadoAltaDto);
            empleado.FechaAlta= DateTime.Now;
            empleado.Id = Guid.NewGuid();

            await _empleadoRepository.PostEmpleadoAsync(empleado);
            responce.Success = true;
            responce.Message = "exito";
        }
        catch (Exception e)
        {
            responce.Success = false;
            responce.Message = "error";
            Console.WriteLine(e);
            throw;
        }

        return responce;
    }
}
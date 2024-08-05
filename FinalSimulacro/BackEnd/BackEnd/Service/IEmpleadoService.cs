using BackEnd.Dto;

namespace BackEnd.Service;

public interface IEmpleadoService
{
    Task<ResultadoBase<List<EmpleadoDto>>> GetAllEmpleadosAsync();
    Task<ResultadoBase<EmpleadoAltaDto>> PostEmpleadoAsync(EmpleadoAltaDto empleadoAltaDto);
}
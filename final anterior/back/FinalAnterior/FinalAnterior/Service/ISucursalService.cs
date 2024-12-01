using FinalAnterior.Dto;

namespace FinalAnterior.Service;

public interface ISucursalService
{
    Task<BaseDto<SucursalDto>> GetTheSucursalAsync();
    Task<BaseDto<List<ConfiguracionDto>>> GetConfiguracionesAsync();
    Task<BaseDto<SucursalDto>> PutSucursalAsync(SucursalDto sucursalDto);
}
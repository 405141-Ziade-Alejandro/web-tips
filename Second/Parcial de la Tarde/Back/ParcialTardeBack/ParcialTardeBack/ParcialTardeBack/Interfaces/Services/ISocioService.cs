using ParcialTardeBack.Dto;
using ParcialTardeBack.Response;

namespace ParcialTardeBack.Interfaces.Services;

public interface ISocioService
{
    Task<ApiResponse<List<SocioDto>>> GetAll();
    Task<ApiResponse<SocioDto>> GetById(Guid id);
    Task<ApiResponse<SocioDto>> AltaSocio(SocioDto socio);
}
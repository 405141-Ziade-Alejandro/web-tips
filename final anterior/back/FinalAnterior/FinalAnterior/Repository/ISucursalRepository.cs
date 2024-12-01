using FinalAnterior.Models;

namespace FinalAnterior.Repository;

public interface ISucursalRepository
{
    Task<List<Sucursal>> getAllSucursales();
    Task<List<Configuracion>> GetConfigurations();


    Task<Sucursal> GetSucursal(Guid sucursalDtoId);

    Task PutSucursal(Sucursal oldSucursal);
}
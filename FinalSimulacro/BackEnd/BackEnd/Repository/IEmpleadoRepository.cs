using BackEnd.Models;

namespace BackEnd.Repository;

public interface IEmpleadoRepository
{
    Task<List<Empleado>> GetAllEmpleados();
    Task PostEmpleadoAsync(Empleado empleado);
    Task<bool> GetEmpleadoByDni(string Dni);
    Task<Sucursal> GetSurcursalAsync(Guid idSucursal);
    Task<string> GetCiudadAsync(Guid idCiudad);
    Task<string> GetCargoAsync(Guid idCargo);
}
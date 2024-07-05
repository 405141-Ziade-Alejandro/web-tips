using ParcialTardeBack.Models;

namespace ParcialTardeBack.Interfaces;

public interface ISocioRepository
{
    Task<List<Socio>> GetAll();
    Task<Socio> GetById(Guid id);
    Task<Socio> AltaSocio(Socio socio);
}
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ParcialTardeBack.Interfaces;
using ParcialTardeBack.Models;

namespace ParcialTardeBack.Repos;

public class SocioRepository : ISocioRepository
{
    private readonly ParcialSociosClubContext _contextDb;
    
    public SocioRepository(ParcialSociosClubContext contextDb)
    {
        _contextDb = contextDb;
    }

    public async Task<List<Socio>> GetAll()
    {
        var socios = await _contextDb.Socios.ToListAsync();
        return socios;
    }

    public async Task<Socio> GetById(Guid id)
    {
        var socio = await _contextDb.Socios.FirstOrDefaultAsync(s => s.Id == id);
        if (socio != null)
        {
            return socio;
        }
        throw new Exception("No se encontro el socio!");
    }

    public async Task<Socio> AltaSocio(Socio socio)
    {
        Socio socioCheck = await GetByDni(socio.Dni);
        if (socioCheck == null)
        {
            socio.FechaCreacion = DateTime.Today;
            EntityEntry<Socio> socioSave = _contextDb.Socios.Add(socio);
            await _contextDb.SaveChangesAsync();
            return socioSave.Entity;
        }
        else
        {
            socio.Id = socioCheck.Id;
            EntityEntry<Socio> socioSave = _contextDb.Socios.Update(socio);
            await _contextDb.SaveChangesAsync();
            return socioSave.Entity;
        }
    }

    private async Task<Socio> GetByDni(int dni)
    {
        var socio = await _contextDb.Socios.FirstOrDefaultAsync(s => s.Dni == dni);
        return socio;
    }
}
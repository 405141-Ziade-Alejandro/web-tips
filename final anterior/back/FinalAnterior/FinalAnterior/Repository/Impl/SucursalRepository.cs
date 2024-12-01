using FinalAnterior.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalAnterior.Repository.Impl;

public class SucursalRepository : ISucursalRepository
{
    private readonly ContextDb _contextDb;

    public SucursalRepository(ContextDb contextDb)
    {
        _contextDb = contextDb;
    }

    public async Task<List<Sucursal>> getAllSucursales()
    {
        List<Sucursal> sucursales = await _contextDb.Sucursales.ToListAsync();
        return sucursales;
    }

    public async Task<List<Configuracion>> GetConfigurations()
    {
        List<Configuracion> configuracions = await _contextDb.Configuraciones.ToListAsync();
        return configuracions;
    }

    public async Task<Sucursal> GetSucursal(Guid sucursalDtoId)
    {
        Sucursal sucursal = await _contextDb.Sucursales.FindAsync(sucursalDtoId);
        
        return sucursal;
    }

    public async Task PutSucursal(Sucursal oldSucursal)
    {
        _contextDb.Sucursales.Update(oldSucursal);
        await _contextDb.SaveChangesAsync();
    }
}
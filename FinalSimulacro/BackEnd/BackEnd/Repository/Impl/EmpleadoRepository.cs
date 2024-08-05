using BackEnd.Models;
using Microsoft.EntityFrameworkCore;
using RepasoParcialTarde.Context;

namespace BackEnd.Repository.Impl;

public class EmpleadoRepository : IEmpleadoRepository
{
    private readonly ContextDb _context;

    public EmpleadoRepository(ContextDb context)
    {
        _context = context;
    }
    public async Task<List<Empleado>> GetAllEmpleados()
    {
        var lista = await _context.empleados.ToListAsync();
        return lista;
    }

    public async Task PostEmpleadoAsync(Empleado empleado)
    {
        await _context.empleados.AddAsync(empleado);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> GetEmpleadoByDni(string Dni)
    {
        var hay = await _context.empleados.AnyAsync(x => x.Dni == Dni);
        return hay;
    }

    public async Task<Sucursal> GetSurcursalAsync(Guid idSucursal)
    {
        var sucursal = await _context.Sucursales.FindAsync(idSucursal);
        return sucursal;
    }

    public async Task<string> GetCiudadAsync(Guid idCiudad)
    {
        var ciudad = await _context.Ciudades.FindAsync(idCiudad);
        return ciudad.Nombre;
    }

    public async Task<string> GetCargoAsync(Guid idCargo)
    {
        var cargoName = await _context.Cargos.FindAsync(idCargo);
        return cargoName.Nombre;
    }
}
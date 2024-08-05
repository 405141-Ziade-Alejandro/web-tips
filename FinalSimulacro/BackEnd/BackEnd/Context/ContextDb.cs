using BackEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace RepasoParcialTarde.Context;

public class ContextDb : DbContext
{
    public ContextDb(DbContextOptions<ContextDb> options) : base(options)
    {
    }
    
    public DbSet<Cargo> Cargos { get; set; }    
    public DbSet<Ciudad> Ciudades { get; set; }
    public DbSet<Empleado> empleados { get; set; }
    public DbSet<Sucursal> Sucursales { get; set; }

    
}
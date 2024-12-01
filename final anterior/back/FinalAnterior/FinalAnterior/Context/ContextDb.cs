using Microsoft.EntityFrameworkCore;

namespace FinalAnterior.Models;

public class ContextDb : DbContext
{
    public ContextDb(DbContextOptions<ContextDb> options) : base(options)
    {
    }
    //public DbSet<Socio> Socios { get; set; }
    public DbSet<Configuracion> Configuraciones { get; set; }
    public DbSet<Provincia> Provincias { get; set; }
    public DbSet<Sucursal> Sucursales { get; set; }
    public DbSet<Tipo> Tipos { get; set; }
}
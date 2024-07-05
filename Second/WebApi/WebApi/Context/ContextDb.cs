using Microsoft.EntityFrameworkCore;

namespace RepasoParcialTarde.Context;

public class ContextDb : DbContext
{
    public ContextDb(DbContextOptions<ContextDb> options) : base(options)
    {
        
    }
	 //public DbSet<Socio> Socios { get; set; }
}
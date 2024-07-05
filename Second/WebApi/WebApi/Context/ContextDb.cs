using Microsoft.EntityFrameworkCore;

namespace RepasoParcialTarde.Context;

public class ContextDb : DbContext
{
    public ContextDb(DbContextOptions<ContextDb> options) : base(options)
    {
        
    }
}
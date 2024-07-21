using Microsoft.EntityFrameworkCore;
using parcialSimulacro.Models;

namespace parcialSimulacro.Repository.Impl;

public class AlbanilesRepository : IAlbanilesRepository
{
    private readonly ContextDb _contextDb;

    public AlbanilesRepository(ContextDb contextDb)
    {
        _contextDb = contextDb;
    }
    
    public async Task<List<Albanile>> GetAllActiveAbaniles()
    {
        var albanilesActivos = await _contextDb.Albaniles.Where(x => x.Activo).ToListAsync();
        return albanilesActivos;
    }

    public async Task AddAlbanil(Albanile albanile)
    {
        await _contextDb.Albaniles.AddAsync(albanile);
        await _contextDb.SaveChangesAsync();
    }

    public async Task<Albanile> GetAlbanilById(Guid id)
    {
        var albanil = await _contextDb.Albaniles.FindAsync(id);
        return albanil;
    }

    public async Task<bool> AlbanilExist(string dni)
    {
        var result = await _contextDb.Albaniles.AnyAsync(x => x.Dni.Equals(dni));
        return result;
    }
}
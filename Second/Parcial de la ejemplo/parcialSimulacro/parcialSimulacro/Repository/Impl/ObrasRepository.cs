using Microsoft.EntityFrameworkCore;
using parcialSimulacro.Models;

namespace parcialSimulacro.Repository.Impl;

public class ObrasRepository : IObrasRepository
{

    private readonly ContextDb _contextDb;

    public ObrasRepository(ContextDb contextDb)
    {
        _contextDb = contextDb;
    }
    
    public async Task<List<Obra>> GetAllObrasAsync()
    {
        var obras = await _contextDb.Obras
            .Include(x => x.IdTipoObraNavigation)
            .Include(x => x.AlbanilesXObras)
            .ToListAsync();
        return obras;
    }

    public async Task AddAlbanilToObra(AlbanilesXObra albanilesXObra)
    {
        await _contextDb.AlbanilesXObras.AddAsync(albanilesXObra);
        await _contextDb.SaveChangesAsync();
    }

    public async Task<List<Albanile>> GetAlbanilesNotInObra(Guid obraId)
    {
        var albanilesInObra = _contextDb.AlbanilesXObras
            .Where(x => x.IdObra == obraId).Select(x => x.IdAlbanil);

        var albanilesNotInObra = await _contextDb.Albaniles
            .Where(alb => !albanilesInObra.Contains(alb.Id) && alb.Activo)
            .ToListAsync();
        return albanilesNotInObra;
    }

    public async Task<bool> AlbanilInObra(Guid obraId, Guid albanilId)
    {
        var albanilInObra = await _contextDb.AlbanilesXObras
            .AnyAsync(x => x.IdObra == obraId && x.IdAlbanil == albanilId);
        return albanilInObra;
    }
}
using parcialSimulacro.Models;

namespace parcialSimulacro.Repository;

public interface IObrasRepository
{
    Task<List<Obra>> GetAllObrasAsync();
    Task AddAlbanilToObra(AlbanilesXObra albanilesXObra);
    Task<List<Albanile>> GetAlbanilesNotInObra(Guid obraId);
    Task<bool> AlbanilInObra(Guid obraId, Guid albanilId);
}
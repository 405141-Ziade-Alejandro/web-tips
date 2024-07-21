using parcialSimulacro.Models;

namespace parcialSimulacro.Repository;

public interface IAlbanilesRepository
{
    Task<List<Albanile>> GetAllActiveAbaniles();
    Task AddAlbanil(Albanile albanile);
    Task<Albanile> GetAlbanilById(Guid id);
    Task<bool> AlbanilExist(string dni);
}
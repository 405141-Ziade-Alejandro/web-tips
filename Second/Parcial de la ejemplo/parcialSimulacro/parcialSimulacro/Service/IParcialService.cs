using parcialSimulacro.Dto;
using parcialSimulacro.Models;

namespace parcialSimulacro.Service;

public interface IParcialService
{
    Task<Responce<List<ObraDto>>> GetAllObrasAsync();
    Task<Responce<AlbanilXObraDto>> PostAlbanilXObraAsync(AlbanilXObraDto albanilXObraDto);
    Task<Responce<AlbanilDto>> PostAlbanilAsync(AlbanilDto albanilDto);
    Task<Responce<List<AlbanilDto>>> GetAlbanilesNotObraAsync(Guid idObra);
}
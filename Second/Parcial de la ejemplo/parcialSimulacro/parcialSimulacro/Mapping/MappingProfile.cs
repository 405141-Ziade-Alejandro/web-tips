using AutoMapper;
using parcialSimulacro.Dto;
using parcialSimulacro.Models;

namespace parcialSimulacro.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        
        CreateMap<Albanile, AlbanilDto>().ReverseMap();
        CreateMap<Obra, ObraDto>()
            .ForMember(x=>x.CantAlbaniles , 
                opt=> opt.MapFrom(src=>src.AlbanilesXObras.Count))
            .ForMember(x=> x.NombreTipoObra ,
                opt => opt.MapFrom(src=>src.IdTipoObraNavigation.Nombre))
            .ReverseMap();
        CreateMap<AlbanilesXObra, AlbanilXObraDto>().ReverseMap();
    }
}
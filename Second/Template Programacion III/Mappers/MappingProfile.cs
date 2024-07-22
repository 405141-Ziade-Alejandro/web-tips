using AutoMapper;

namespace Template_Programacion_III.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            /*
            CreateMap<Tipo, TipoDto>().ReverseMap();
            CreateMap<Ejemplo, EjemploDto>()                $Con este mapeo ya estaria$
                .ForMember(dest => dest.Tipo, opt => opt.MapFrom(src => src.IdTipoNavigation)); 

            CreateMap<EjemploDto, Ejemplo>()               $Este mapeo graba un factura-detalle$
                .ForMember(dest => dest.IdTipo, opt => opt.MapFrom(src => src.Tipo.Id))
                .ForMember(dest => dest.IdTipoNavigation, opt => opt.MapFrom(src => src.Tipo));
                */

        }
    }
}
using AutoMapper;
using ParcialTardeBack.Dto;
using ParcialTardeBack.Models;

namespace ParcialTardeBack.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Socio, SocioDto>();
        CreateMap<SocioDto, Socio>();
        // CreateMap<Monster, MonsterDto>()
        //     .ForMember(dest => dest.Tipo,
        //         opt => opt.MapFrom(src => src.Tipo)); // mapeamos directamente la entidad Tipo a TipoDto
        // CreateMap<Tipo, TipoDto>();
    }
}
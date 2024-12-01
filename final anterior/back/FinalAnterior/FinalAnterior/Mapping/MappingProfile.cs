using AutoMapper;
using FinalAnterior.Dto;
using FinalAnterior.Models;


namespace RepasoParcialTarde.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // CreateMap<Socio, SocioDto>();
        // CreateMap<SocioDto, Socio>();
        CreateMap<Sucursal, SucursalDto>().ReverseMap();
        CreateMap<Configuracion,ConfiguracionDto>().ReverseMap();
    }
}
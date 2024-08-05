using AutoMapper;
using BackEnd.Dto;
using BackEnd.Models;


namespace RepasoParcialTarde.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Empleado, EmpleadoDto>().ReverseMap();
        CreateMap<Empleado, EmpleadoAltaDto>().ReverseMap();
    }
}
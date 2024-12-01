using AutoMapper;
using FinalAnterior.Dto;
using FinalAnterior.Models;
using FinalAnterior.Repository;
using FinalAnterior.Repository.Impl;
using FinalAnterior.Validators;
using FluentValidation;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FinalAnterior.Service.Impl;

public class SucursalService : ISucursalService
{
    private readonly ISucursalRepository _sucursalRepository;

    private readonly IMapper _mapper;
    
    private readonly SucursalValidator _validator;

    public SucursalService(ISucursalRepository sucursalRepository, IMapper mapper, SucursalValidator validator)
    {
        _sucursalRepository = sucursalRepository;
        _mapper = mapper;
        _validator = validator;
    }

    public async Task<BaseDto<SucursalDto>> GetTheSucursalAsync()
    {
        BaseDto<SucursalDto> baseDto = new BaseDto<SucursalDto>();

        List<Sucursal> sucursales = await _sucursalRepository.getAllSucursales();

        if (sucursales.Count == 0)
        {
            baseDto.Success = false;
            baseDto.Message = "Nenhuma sucursal foi encontrada.";
            return baseDto;
        }

        Guid bsProvince = Guid.Parse("0993a2bc-418d-4372-a077-0f2424db3d78");

        // sucursales = sucursales.Where(s => !s.Provincia.Nombre.Equals("Buenos Aires")).ToList();
        sucursales = sucursales
            .Where(s => !s.IdProvincia.Equals(bsProvince))
            .ToList();

        Sucursal sucursalMasReciente = null;

        foreach (Sucursal sucursal in sucursales)
        {
            if (sucursalMasReciente == null || sucursalMasReciente.FechaAlta < sucursal.FechaAlta)
            {
                sucursalMasReciente = sucursal;
            }
        }

        SucursalDto sucursalDto = _mapper.Map<SucursalDto>(sucursalMasReciente);

        baseDto.Data = sucursalDto;
        baseDto.Success = true;

        return baseDto;
    }

    public async Task<BaseDto<List<ConfiguracionDto>>> GetConfiguracionesAsync()
    {
        BaseDto<List<ConfiguracionDto>> baseDto = new BaseDto<List<ConfiguracionDto>>();

        List<Configuracion> configuraciones = await _sucursalRepository.GetConfigurations();

        var config = _mapper.Map<List<ConfiguracionDto>>(configuraciones);

        baseDto.Data = config;
        baseDto.Success = true;
        return baseDto;
    }

    public async Task<BaseDto<SucursalDto>> PutSucursalAsync(SucursalDto sucursalDto)
    {
        BaseDto<SucursalDto> baseDto = new BaseDto<SucursalDto>();
        
        var validator = await _validator.ValidateAsync(sucursalDto);
        
        if (!validator.IsValid)
        {
            var errors = string.Join(", ", validator.Errors.Select(e => e.ErrorMessage));
            baseDto.Success = false;
            baseDto.Message = errors;
            return baseDto;
            
        }

        Sucursal oldSucursal = await _sucursalRepository.GetSucursal(sucursalDto.Id);

        if (oldSucursal == null)
        {
            baseDto.Success = false;
            baseDto.Message = "esa sucursal no exite";
            return baseDto;
        }

        _mapper.Map(sucursalDto, oldSucursal);

        await _sucursalRepository.PutSucursal(oldSucursal);

        SucursalDto newSucursal = _mapper.Map<SucursalDto>(oldSucursal);

        baseDto.Data = newSucursal;
        baseDto.Success = true;
        
        return baseDto;
    }
}
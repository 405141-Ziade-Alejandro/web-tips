using Microsoft.AspNetCore.Mvc;
using ParcialTardeBack.Dto;
using ParcialTardeBack.Interfaces.Services;

namespace ParcialTardeBack.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SocioController : ControllerBase
{
    private readonly ISocioService _socioService;

    public SocioController(ISocioService socioService)
    {
        _socioService = socioService;
    }
    
    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var socios = await _socioService.GetAll();

        return Ok(socios);
    }
    
    [HttpGet("GetById/{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var socio = await _socioService.GetById(id);

        return Ok(socio);
    }
    
    [HttpPost]
    public async Task<IActionResult> AltaSocio([FromBody]SocioDto socioDto)
    {
        var socio = await _socioService.AltaSocio(socioDto);

        return Ok(socio);
    }
}
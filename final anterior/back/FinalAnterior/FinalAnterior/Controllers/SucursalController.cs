using FinalAnterior.Dto;
using FinalAnterior.Models;
using FinalAnterior.Service;
using Microsoft.AspNetCore.Mvc;

namespace FinalAnterior.Controllers;
[Route("api/[controller]")]
[ApiController]
public class SucursalController : ControllerBase
{
    private readonly ISucursalService _sucursalService;

    public SucursalController(ISucursalService sucursalService)
    {
        _sucursalService = sucursalService;
    }

    [HttpGet]
    public async Task<IActionResult> GetTheSucursal()
    {
        var responce = await _sucursalService.GetTheSucursalAsync();
        if (!responce.Success)
        {
            return StatusCode(500, responce.Message);
        }
        return Ok(responce);
    }

    [HttpGet("/config")]
    public async Task<IActionResult> GetTheConfig()
    {
        var responce = await _sucursalService.GetConfiguracionesAsync();
        if (!responce.Success)
        {
            return StatusCode(500, responce.Message);
        }
        return Ok(responce);
    }

    [HttpPut]
    public async Task<IActionResult> PutTheSucursal([FromBody] SucursalDto sucursal)
    {
        var responce = await _sucursalService.PutSucursalAsync(sucursal);
        if (!responce.Success)
        {
            return StatusCode(500, responce.Message);
        }
        return Ok(responce);
    }
}
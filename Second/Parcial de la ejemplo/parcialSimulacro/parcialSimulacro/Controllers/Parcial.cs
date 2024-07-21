using Microsoft.AspNetCore.Mvc;
using parcialSimulacro.Dto;
using parcialSimulacro.Models;
using parcialSimulacro.Service;

namespace parcialSimulacro.Controllers;
[ApiController]
[Route("api/[controller]")]
public class Parcial : ControllerBase
{
    private readonly IParcialService _parcialService;

    public Parcial(IParcialService parcialService)
    {
        _parcialService = parcialService;
    }
    //endpoint 1
    [HttpGet("getobras")]
    public async Task<IActionResult> GetObras()
    {
        var obras = await _parcialService.GetAllObrasAsync();
        if (!obras.Success)
        {
            return BadRequest(obras);
        }
        return Ok(obras);
    }

    //entpoint 2
    [HttpPost("postAlbanilxobra")]
    public async Task<IActionResult> PostAlbanilXObra([FromBody] AlbanilXObraDto albanilXObraDto)
    {
        var result = await _parcialService.PostAlbanilXObraAsync(albanilXObraDto);
        if (!result.Success)
        {
            return BadRequest(result);
        }
        return Ok(result);
    }
    
    
    //Endpoint 3
    [HttpPost("postAlbanil")]
    public async Task<IActionResult> PostAlbanil([FromBody] AlbanilDto albanilDto)
    {
        var result = await _parcialService.PostAlbanilAsync(albanilDto);
        if (!result.Success)
        {
            return BadRequest(result);
        }
        return Ok(result);
    }
    //endpoint 4
    [HttpGet("getalbaniles")]
    public async Task<IActionResult> GetAlbaniles([FromQuery] Guid idObra)
    {
        var result = await _parcialService.GetAlbanilesNotObraAsync(idObra);
        if (!result.Success)
        {
            return BadRequest(result);
        }
        return Ok(result);
    }
}
using BackEnd.Dto;
using BackEnd.Service;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers;
[ApiController]
[Route("api/post")]
public class PostController: ControllerBase
{
    private readonly IEmpleadoService _empleadoService;

    public PostController(IEmpleadoService empleadoService)
    {
        _empleadoService = empleadoService;
    }

    [HttpPost("empleados")]
    public async Task<IActionResult> PostEmploy([FromBody] EmpleadoAltaDto empleadoAltaDto)
    {
        var responce = await _empleadoService.PostEmpleadoAsync(empleadoAltaDto);

        if (!responce.Success)
        {
            return BadRequest(responce);
        }

        return Ok(responce);
    }
}
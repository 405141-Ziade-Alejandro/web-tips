using BackEnd.Service;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers;
[ApiController]
[Route("api/get")]
public class GetController : ControllerBase
{
    private readonly IEmpleadoService _empleadoService;

    public GetController(IEmpleadoService empleadoService)
    {
        _empleadoService = empleadoService;
    }

    [HttpGet("empleados")]
    public async Task<IActionResult> GetAllEmploies()
    {
        var responce = await _empleadoService.GetAllEmpleadosAsync();

        if (!responce.Success)
        {
            return BadRequest(responce);
        }

        return Ok(responce);
    }
}
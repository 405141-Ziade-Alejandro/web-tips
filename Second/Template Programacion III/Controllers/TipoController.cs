using Microsoft.AspNetCore.Mvc;

namespace Template_Programacion_III.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoController : ControllerBase
    {
        /*
        private readonly ITipoService _tipoService;

        public TipoController(ITipoService tipoService)
        {
            _tipoService = tipoService;
        }

        [HttpGet("GetAllSubtablas")]
        public async Task<IActionResult> GetAllSubtabla()
        {
            var response = await _tipoService.GetAllSubtabla();
            if (response.Success)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }
        */
    }
}
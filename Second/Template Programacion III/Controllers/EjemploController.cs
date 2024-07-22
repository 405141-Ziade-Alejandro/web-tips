using Microsoft.AspNetCore.Mvc;

namespace Template_Programacion_III.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EjemploController : ControllerBase
    {
        /*
        private readonly IEjemploService _ejemploService;

        public EjemploController(IEjemploService ejemploService)
        {
            _ejemploService = ejemploService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _ejemploService.GetAll();
            if (response.Success)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }

        [HttpGet("GetAllBy/{texto}")]
        public async Task<IActionResult> GetAllBy(string texto)
        {
            var response = await _ejemploService.GetAllBy(texto);
            if (response.Success)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var response = await _ejemploService.GetById(id);
            if (response.Success)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }

        [HttpGet("GetAllBySubtabla/{tipo}")]
        public async Task<IActionResult> GetAllBySubtabla(string tipo)
        {
            var response = await _ejemploService.GetAllBySubtabla(tipo);
            if (response.Success)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }

        [HttpPost("Post")]
        public async Task<IActionResult> Post([FromBody] EjemploDto ejemploDto)
        {
            var response = await _ejemploService.Post(ejemploDto);
            if (response.Success)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }
        */
    }
}
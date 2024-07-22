using Template_Programacion_III.Interfaces.Service;

namespace Template_Programacion_III.Services
{
    public class EjemploService : IEjemploService
    {
        /*
        private readonly IEjemploRepository _ejemploRepository;
        private readonly IMapper _mapper;

        public EjemploService(IEjemploRepository ejemploRepository, IMapper mapper)
        {
            _ejemploRepository = ejemploRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse<List<EjemploDto>>> GetAll()
        {
            var response = new ApiResponse<List<EjemploDto>>();

            try
            {
                var ejemplos = await _ejemploRepository.GetAll();
                var ejemplosDto = _mapper.Map<List<EjemploDto>>(ejemplos);

                if (ejemplos.Count == 0)
                {
                    response.SetError("No se encontro nada!", HttpStatusCode.NotFound);
                    return response;
                }

                response.Data = ejemplosDto;
                return response;
            }
            catch (Exception e)
            {
                response.SetError(e.Message, HttpStatusCode.BadRequest);
                return response;
            }
        }

        public async Task<ApiResponse<List<EjemploDto>>> GetAllBy(string texto)
        {
            var response = new ApiResponse<List<EjemploDto>>();

            try
            {
                var ejemplos = await _ejemploRepository.GetAllBy(texto);
                var ejemplosDto = _mapper.Map<List<EjemploDto>>(ejemplos);

                if (ejemplos.Count == 0)
                {
                    response.SetError("No se encontro nada!", HttpStatusCode.NotFound);
                    return response;
                }

                response.Data = ejemplosDto;
                return response;
            }
            catch (Exception e)
            {
                response.SetError(e.Message, HttpStatusCode.BadRequest);
                return response;
            }
        }

        public async Task<ApiResponse<EjemploDto>> GetById(Guid id)
        {
            var response = new ApiResponse<EjemploDto>();

            try
            {
                var ejemplo = await _ejemploRepository.GetById(id);
                if (ejemplo == null)
                {
                    response.SetError("No se encontro!", HttpStatusCode.NotFound);
                    return response;
                }

                var ejemploDto = _mapper.Map<EjemploDto>(ejemplo);
                response.Data = ejemploDto;
                return response;
            }
            catch (Exception e)
            {
                response.SetError(e.Message, HttpStatusCode.BadRequest);
                return response;
            }
        }

        public async Task<ApiResponse<List<EjemploDto>>> GetAllBySubtabla(string tipo)
        {
            var response = new ApiResponse<List<EjemploDto>>();

            try
            {
                var ejemplos = await _ejemploRepository.GetAllBySubtabla(tipo);
                var ejemplosDto = _mapper.Map<List<EjemploDto>>(ejemplos);

                if (ejemplos.Count == 0)
                {
                    response.SetError("No se encontro nada!", HttpStatusCode.NotFound);
                    return response;
                }

                response.Data = ejemplosDto;
                return response;
            }
            catch (Exception e)
            {
                response.SetError(e.Message, HttpStatusCode.BadRequest);
                return response;
            }
        }

        public async Task<ApiResponse<EjemploDto>> Post(EjemploDto ejemploDto)
        {
            var response = new ApiResponse<EjemploDto>();

            try
            {
                var ejemplo = _mapper.Map<Ejemplo>(ejemploDto);
                await _ejemploRepository.Post(ejemplo);
                //response.Data = ejemploDto; <--- opcional devolverlo
                return response;
            }
            catch (Exception e)
            {
                response.SetError(e.Message, HttpStatusCode.BadRequest);
                return response;
            }
        }
        */
    }
}
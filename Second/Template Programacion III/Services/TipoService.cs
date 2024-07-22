using Template_Programacion_III.Interfaces.Service;


namespace Template_Programacion_III.Services
{
    public class TipoService : ITipoService
    {
        /*
        private readonly ITipoRepository _tipoRepository;
        private readonly IMapper _mapper;

        public TipoService(ITipoRepository tipoRepository, IMapper mapper)
        {
            _tipoRepository = tipoRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse<List<TipoDto>>> GetAllSubtabla()
        {
            var response = new ApiResponse<List<TipoDto>>();

            try
            {
                var tipos = await _tipoRepository.GetAllSubtabla();
                var tiposDto = _mapper.Map<List<TipoDto>>(tipos);

                if (tiposDto.Count == 0)
                {
                    response.SetError("No se encontro nada!", HttpStatusCode.NotFound);
                    return response;
                }

                response.Data = tiposDto;
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
using Template_Programacion_III.Interfaces;

namespace Template_Programacion_III.Repositories
{
    public class EjemploRepository : IEjemploRepository
    {
        /*
        private readonly TemplateExampleContext _context;

        public EjemploRepository(TemplateExampleContext context)
        {
            _context = context;
        }

        public async Task<List<Ejemplo>> GetAll()
        {
            var ejemplos = await _context.Ejemplos
                .Include(e => e.IdTipoNavigation)
                .ToListAsync();
            return ejemplos;
        }

        public async Task<List<Ejemplo>> GetAllBy(string texto)
        {
            var ejemplos = await _context.Ejemplos
                .Include(e => e.IdTipoNavigation)
                .Where(e => e.Texto == texto)
                .ToListAsync();
            return ejemplos;
        }

        public async Task<Ejemplo> GetById(Guid id)
        {
            var ejemplo = await _context.Ejemplos
                .FirstOrDefaultAsync(e => e.Id == id);
            return ejemplo;
        }

        public async Task<List<Ejemplo>> GetAllBySubtabla(string tipo)
        {
            var ejemplos = await _context.Ejemplos
                .Include(e => e.IdTipoNavigation)
                .Where(e => e.IdTipoNavigation.Tipo1 == tipo)
                .ToListAsync();

            return ejemplos;
        }

        public async Task Post(Ejemplo ejemplo)
        {
            await _context.Ejemplos.AddAsync(ejemplo);
            await _context.SaveChangesAsync();
        }
        */
    }
}
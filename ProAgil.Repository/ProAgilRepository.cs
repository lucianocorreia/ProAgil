using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProAgil.Domain;

namespace ProAgil.Repository
{
    public class ProAgilRepository : IProAgilRepository
    {
        private readonly ProAgilContext context;

        public ProAgilRepository(ProAgilContext context)
        {
            this.context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            context.Remove(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            context.Update(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await context.SaveChangesAsync()) > 0;
        }

        #region Evento

        public async Task<Evento[]> GetAllEventoAsync(bool IncludePalestrante = false)
        {
            IQueryable<Evento> query = context.Eventos
                .Include(e => e.Lotes)
                .Include(e => e.RedesSociais);

            if (IncludePalestrante)
            {
                query = query
                    .Include(e => e.PalestranteEventos)
                    .ThenInclude(p => p.Palestrante);
            }

            query = query.AsNoTracking()
                .OrderByDescending(e => e.DataEvento);

            return await query.ToArrayAsync();
        }

        public async Task<Evento[]> GetAllEventoAsyncByTema(string Tema, bool IncludePalestrante)
        {
            IQueryable<Evento> query = context.Eventos
                .Include(e => e.Lotes)
                .Include(e => e.RedesSociais);

            if (IncludePalestrante)
            {
                query = query
                    .Include(e => e.PalestranteEventos)
                    .ThenInclude(p => p.Palestrante);
            }

            query = query.AsNoTracking()
                .OrderByDescending(e => e.DataEvento)
                .Where(e => e.Tema.ToLower().Contains(Tema.ToLower()));

            return await query.ToArrayAsync();
        }

        public async Task<Evento> GetEventoAsyncById(int EventoId, bool IncludePalestrante)
        {
            IQueryable<Evento> query = context.Eventos
                .Include(e => e.Lotes)
                .Include(e => e.RedesSociais);

            if (IncludePalestrante)
            {
                query = query
                    .Include(e => e.PalestranteEventos)
                    .ThenInclude(p => p.Palestrante);
            }

            query = query.AsNoTracking()
                .OrderByDescending(e => e.DataEvento)
                .Where(e => e.Id == EventoId);

            return await query.FirstOrDefaultAsync();
        }

        #endregion

        #region Palestrante

        public async Task<Palestrante[]> GetAllPalestranteAsyncByName(string name, bool IncludeEventos = false)
        {
            IQueryable<Palestrante> query = context.Palestrantes
                .Include(e => e.RedesSociais);

            if (IncludeEventos)
            {
                query = query
                    .Include(e => e.PalestranteEventos)
                    .ThenInclude(e => e.Evento);
            }

            query = query.AsNoTracking()
                .OrderBy(e => e.Nome)
                .Where(p => p.Nome.ToLower().Contains(name.ToLower()));

            return await query.ToArrayAsync();
        }

        public async Task<Palestrante> GetPalestranteAsync(int PalestranteId, bool IncludeEventos = false)
        {
            IQueryable<Palestrante> query = context.Palestrantes
                .Include(e => e.RedesSociais);

            if (IncludeEventos)
            {
                query = query
                    .Include(e => e.PalestranteEventos)
                    .ThenInclude(e => e.Evento);
            }

            query = query.AsNoTracking()
                .OrderBy(e => e.Nome)
                .Where(p => p.Id == PalestranteId);

            return await query.FirstOrDefaultAsync();
        }

        #endregion

    }
}
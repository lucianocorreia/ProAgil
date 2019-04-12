using System.Threading.Tasks;
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
            throw new System.NotImplementedException();
        }

        public void Delete<T>(T entity) where T : class
        {
            throw new System.NotImplementedException();
        }

        public void Update<T>(T entity) where T : class
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> SaveChangesAsync()
        {
            throw new System.NotImplementedException();
        }

        #region Evento

        public Task<Evento[]> GetAllEventoAsync(bool IncludePalestrante)
        {
            throw new System.NotImplementedException();
        }

        public Task<Evento[]> GetAllEventoAsyncByTema(string Tema, bool IncludePalestrante)
        {
            throw new System.NotImplementedException();
        }

        public Task<Evento> GetEventoAsyncById(int EventoId, bool IncludePalestrante)
        {
            throw new System.NotImplementedException();
        }

        #endregion

        #region Palestrante

        public Task<Palestrante[]> GetAllPalestranteAsyncByName()
        {
            throw new System.NotImplementedException();
        }

        public Task<Palestrante> GetPalestranteAsync(int PalestranteId)
        {
            throw new System.NotImplementedException();
        }

        #endregion

    }
}
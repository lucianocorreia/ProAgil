using System.Threading.Tasks;
using ProAgil.Domain;

namespace ProAgil.Repository
{
    public interface IProAgilRepository
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;

        Task<bool> SaveChangesAsync();


        #region Eventos

        Task<Evento[]> GetAllEventoAsyncByTema(string Tema, bool IncludePalestrante);
        Task<Evento[]> GetAllEventoAsync(bool IncludePalestrante);
        Task<Evento> GetEventoAsyncById(int EventoId, bool IncludePalestrante);

        #endregion

        #region Palestrante

        Task<Palestrante[]> GetAllPalestranteAsyncByName(string name, bool IncludeEventos);
        Task<Palestrante> GetPalestranteAsync(int PalestranteId, bool IncludeEventos);

        #endregion

    }
}
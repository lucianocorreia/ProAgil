using Microsoft.AspNetCore.Mvc;
using ProAgil.Repository;

namespace ProAgil.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventoController : ControllerBase
    {
        private readonly IProAgilRepository repository;

        public EventoController(IProAgilRepository repository)
        {
            this.repository = repository;
        }

    }
}
using MediatR;
using MercadoCapitales.API.Precios.Aplicacion;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MercadoCapitales.API.Precios.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PrecioController : Controller
    {

        private readonly IMediator _mediator;

        public PrecioController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> CrearAccion(NuevoAccion.Ejecuta data)
        {
            return await _mediator.Send(data);
        }
    }
}

using MediatR;
using MercadoCapitales.API.Clientes.Aplicacion;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MercadoCapitales.API.Clientes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : Controller
    {
        private readonly IMediator _mediator;

        public ClienteController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("CrearRegistro")]
        public async Task<ActionResult<Unit>> CrearOrden(CrearRegistro.Ejecuta data)
        {
            return await _mediator.Send(data);
        }
    }
}

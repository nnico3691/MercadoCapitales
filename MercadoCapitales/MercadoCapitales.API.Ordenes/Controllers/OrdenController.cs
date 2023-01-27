using MediatR;
using MercadoCapitales.API.Ordenes.Aplicacion;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using static Primary.Api;

namespace MercadoCapitales.API.Ordenes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenController : Controller
    {
        private readonly IMediator _mediator;

        public OrdenController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("CrearOrden")]
        public async Task<ActionResult<Unit>> CrearOrden(CrearOrden.Ejecuta data)
        {
            return await _mediator.Send(data);
        }

        [HttpGet]
        [Route("GetOrderFilleds")]
        public async Task<ActionResult<GetOrderResponse>> GetOrderFilleds() => await _mediator.Send(new ConsultaOrdenesByAccount.ListaOrdenes());

    }
}

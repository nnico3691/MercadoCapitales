using MediatR;
using MercadoCapitales.API.Clientes.Aplicacion;
using MercadoCapitales.API.Clientes.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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

        [HttpGet]
        [Route("GetClientes")]
        public async Task<ActionResult<List<ClienteDto>>> GetPreciosAccion() => await _mediator.Send(new ConsultaClientes.ListaClientes());

        [HttpPost]
        [Route("CrearRegistro")]
        public async Task<ActionResult<Unit>> CrearRegistro(CrearRegistro.Ejecuta data)
        {
            return await _mediator.Send(data);
        }

        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult<Unit>> Login(LoginCliente.Ejecuta data)
        {
            return await _mediator.Send(data);
        }
    }
}

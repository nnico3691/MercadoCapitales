using MediatR;
using MercadoCapitales.API.Clientes.Aplicacion;
using MercadoCapitales.API.Clientes.Dto;
using MercadoCapitales.API.Clientes.Modelo;
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
        public async Task<ActionResult<List<ClienteDto>>> GetClientes() => await _mediator.Send(new ConsultaClientes.ListaClientes());

        [HttpPost]
        [Route("CrearRegistro")]
        public async Task<ActionResult<Unit>> CrearRegistro(CrearRegistro.Ejecuta data)
        {
            return await _mediator.Send(data);
        }

        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult<Login>> Login(LoginCliente.Ejecuta data)
        {
            return await _mediator.Send(data);
        }

        [HttpPost]
        [Route("CrearEncuestaPregunta")]
        public async Task<ActionResult<Unit>> CrearEncuestaPregunta(CrearEncuestaPregunta.Ejecuta data)
        {
            return await _mediator.Send(data);
        }

        [HttpPost]
        [Route("CrearClienteEncuestas")]
        public async Task<ActionResult<Unit>> CrearClienteEncuestas(CrearClienteEncuestas.Ejecuta data)
        {
            return await _mediator.Send(data);
        }

        [HttpGet]
        [Route("GetEncuestaPreguntasRespuestas")]
        public async Task<ActionResult<List<EncuestaPreguntaDto>>> GetEncuestaPreguntasRespuestas() => await _mediator.Send(new ConsultaEncuestaPreguntasRespuestas.ListaEncuestaPreguntasRespuestas());

        [HttpPost]
        [Route("CrearClientePerfilInversor")]
        public async Task<ActionResult<Unit>> CrearClientePerfilInversor(CrearClientePerfilInversor.Ejecuta data)
        {
            return await _mediator.Send(data);
        }

        [HttpPost]
        [Route("StartRecovery")]
        public async Task<ActionResult<Unit>> StartRecovery(StartRecovery.Ejecuta data)
        {
            return await _mediator.Send(data);
        }

        [HttpGet]
        [Route("Recovery")]
        public async Task<ActionResult<string>> Recovery(string token, string email) => await _mediator.Send(new Recovery.Ejecuta {Token = token, Email = email });

    }
}

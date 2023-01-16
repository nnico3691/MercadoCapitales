    using MediatR;
using MercadoCapitales.API.Especies.Aplicacion;
using Microsoft.AspNetCore.Mvc;
using Primary.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MercadoCapitales.API.Especies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EspecieController : Controller
    {
        private readonly IMediator _mediator;

        public EspecieController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("CrearAllInstruments")]
        public async Task<ActionResult<Unit>> CrearAllInstruments() => await _mediator.Send(new CrearAllInstruments.Ejecuta());


        [HttpPost]
        [Route("CrearProductGroup")]
        public async Task<ActionResult<Unit>> CrearProductGroup(CrearProductGroup.Ejecuta data)
        {
            return await _mediator.Send(data);
        }

    }

}

using MediatR;
using MercadoCapitales.API.Especies.Aplicacion.Instrument.Queries;
using MercadoCapitales.API.Especies.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using Primary.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MercadoCapitales.API.Especies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstrumentController : Controller
    {
        private readonly IMediator _mediator;

        public InstrumentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<InstrumentoDto>>> Get() => await _mediator.Send(new GetAllInstrumentHandler.ListaInstrumentos());
    }

}

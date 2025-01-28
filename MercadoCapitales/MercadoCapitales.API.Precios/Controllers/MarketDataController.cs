using MediatR;
using MercadoCapitales.API.Precios.Aplicacion.MarketData.Commands;
using MercadoCapitales.API.Precios.Aplicacion.MarketData.Queries;
using MercadoCapitales.API.Precios.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MercadoCapitales.API.Precios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarketDataController : ControllerBase 
    {
        private readonly IMediator _mediator;

        public MarketDataController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Post(CreateMarketDataCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(Get), new { id }, id);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MarketDataDto>>> Get()
            => await _mediator.Send(new GetAllMarketDataQuery());
        

        [HttpGet("{id}")]
        public async Task<ActionResult<MarketDataDto>> Get(Guid id)
            => await _mediator.Send(new GetMarketDataByIdQuery { Id = id });


        [HttpPut("{id}")]
        public async Task<ActionResult> Update(Guid id, [FromBody] UpdateMarketDataCommand command)
        {
            command.Id = id;
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _mediator.Send(new DeleteMarketDataCommand { Id = id });
            return NoContent();
        }
    }
}

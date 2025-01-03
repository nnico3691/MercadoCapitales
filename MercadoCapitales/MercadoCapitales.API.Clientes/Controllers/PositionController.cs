using MediatR;
using MercadoCapitales.API.Clientes.Aplicacion.Position.Commands;
using MercadoCapitales.API.Clientes.Aplicacion.Position.Queries;
using MercadoCapitales.API.Clientes.Aplicacion.PrimaryUser.Queries;
using MercadoCapitales.API.Clientes.Modelo.Dto;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MercadoCapitales.API.Clientes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PositionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // POST api/position
        [HttpPost]
        public async Task<ActionResult<Guid>> CreatePosition(CreatePositionRequest request)
        {
            var command = new CreatePositionCommand(request.Position);
            var positionId = await _mediator.Send(command);
            return CreatedAtAction(nameof(Get), new { id = positionId }, positionId);
        }


        // GET api/position
        [HttpGet("{username}")]
        public async Task<ActionResult<IEnumerable<PositionDto>>> Get(string UserName)
        {
            var user = await _mediator.Send(new GetUserByUserQuery { UserName = UserName });
            if (user == null) return NotFound();

            var positions = await _mediator.Send(new GetAllPositionsQuery(user));
            return Ok(positions);
        }

        // GET api/position/{id}
        [HttpGet("{id}/{username}")]
        public async Task<ActionResult<PositionDto>> Get(Guid id, string username)
        {
            var position = await _mediator.Send(new GetPositionByUserQuery(id, username));
            if (position == null)
            {
                return NotFound();
            }
            return Ok(position);
        }

        // PUT api/position/{id}
        [HttpPut]
        public async Task<IActionResult> UpdatePosition(UpdatePositionCommand command)
        {
            var result = await _mediator.Send(command);
            if (!result) return NotFound();

            return NoContent();
        }

        // DELETE api/position/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePosition(Guid id)
        {
            var result = await _mediator.Send(new DeletePositionCommand(id));
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}

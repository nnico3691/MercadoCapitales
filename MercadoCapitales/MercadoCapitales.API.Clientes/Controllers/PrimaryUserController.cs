using MediatR;
using Microsoft.AspNetCore.Mvc;
using MercadoCapitales.API.Clientes.Aplicacion.PrimaryUser.Commands;
using MercadoCapitales.API.Clientes.Aplicacion.PrimaryUser.Queries;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace MercadoCapitales.API.Clientes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrimaryUserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PrimaryUserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreatePrimaryUserCommand command)
        {
            var userId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), null, null);
        }

        [HttpGet("{UserName}")]
        public async Task<IActionResult> GetAll(String UserName)
        {
            var user = await _mediator.Send(new GetUserByUserQuery { UserName = UserName });
            if (user == null) return NotFound();

            return Ok(user);
        }

        [HttpGet]
        public async Task<IActionResult> GetById()
        {
            var users = await _mediator.Send(new GetAllUsersQuery());
            return Ok(users);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdatePrimaryUserCommand command)
        {
            var result = await _mediator.Send(command);
            if (!result) return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _mediator.Send(new DeletePrimaryUserCommand { UserId = id });
            if (!result) return NotFound();

            return NoContent();
        }
    }
}

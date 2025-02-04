using MediatR;
using MercadoCapitales.API.Clientes.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using MercadoCapitales.API.Clientes.Aplicacion.AccountExecutive.Queries;
using MercadoCapitales.API.Clientes.Aplicacion.AccountExecutive.Commands;
using MercadoCapitales.API.Clientes.Models.Dto;

namespace MercadoCapitales.API.Clientes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountExecutiveController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AccountExecutiveController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // 🔹 GET: api/accountexecutives
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccountExecutiveDto>>> GetAll()
        {
            var result = await _mediator.Send(new GetAllAccountExecutivesQuery());
            return Ok(result);
        }

        // 🔹 GET: api/accountexecutives/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<AccountExecutiveDto>> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetAccountExecutiveByIdQuery(id));
            if (result == null) return NotFound();
            return Ok(result);
        }

        // 🔹 POST: api/accountexecutives
        [HttpPost]
        public async Task<ActionResult<Guid>> Create(CreateAccountExecutiveCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id }, id);
        }

        // 🔹 PUT: api/accountexecutives/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, AccountExecutiveDto accountExecutive)
        {
            await _mediator.Send(new UpdateAccountExecutiveCommand(id, accountExecutive));
            return NoContent();
        }

        // 🔹 DELETE: api/accountexecutives/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _mediator.Send(new DeleteAccountExecutiveCommand(id));
            return NoContent();
        }
    }
}

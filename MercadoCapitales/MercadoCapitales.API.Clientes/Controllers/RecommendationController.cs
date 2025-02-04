using MercadoCapitales.API.Clientes.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using MediatR;
using MercadoCapitales.API.Clientes.Aplicacion.AccountExecutive.Queries;
using MercadoCapitales.API.Clientes.Aplicacion.Recommendation.Queries;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using MercadoCapitales.API.Clientes.Aplicacion.AccountExecutive.Commands;
using MercadoCapitales.API.Clientes.Models.Dto;
using MercadoCapitales.API.Clientes.Aplicacion.Recommendation.Commands;

namespace MercadoCapitales.API.Clientes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecommendationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RecommendationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/Recommendation
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RecommendationCommandDto>>> GetAll()
        {
            var result = await _mediator.Send(new GetAllRecommendationQuery());
            return Ok(result);
        }

        // GET: api/Recommendation/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<RecommendationCommandDto>> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetRecommendationByIdQuery(id));
            if (result == null) return NotFound();
            return Ok(result);
        }

        // POST: api/Recommendation
        [HttpPost]
        public async Task<ActionResult<RecommendationCommandDto>> Create(CreateRecommendationCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id }, id);
        }

        // PUT: api/Recommendation/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRecommendation(Guid id, RecommendationCommandDto recommendation)
        {
            await _mediator.Send(new UpdateRecommendationCommand(id, recommendation));
            return NoContent();
        }

        // DELETE: api/Recommendation/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _mediator.Send(new DeleteRecommendationCommand(id));
            return NoContent();
        }
    }
}

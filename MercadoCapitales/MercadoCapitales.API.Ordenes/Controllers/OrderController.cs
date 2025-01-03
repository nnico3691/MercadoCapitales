using MediatR;
using MercadoCapitales.API.Ordenes.Aplicacion;
using MercadoCapitales.API.Ordenes.Aplicacion.Order.Commands;
using MercadoCapitales.API.Ordenes.Aplicacion.Order.Queries;
using Microsoft.AspNetCore.Mvc;
using Primary.Data.Orders;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MercadoCapitales.API.Ordenes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // Crear una nueva orden (Create)
        [HttpPost]
        public async Task<ActionResult<Order>> Post(CreateOrderCommand command)
        {
            var order = await _mediator.Send(command);
            return CreatedAtAction(nameof(Get), null, null);
        }

        // Obtener todas las órdenes (Read)
        [HttpGet("{username}")]
        public async Task<ActionResult<IEnumerable<Order>>> Get(
            string username)
        {
            // Aquí podrías validar el usuario si es necesario

            var orders = await _mediator.Send(new GetOrdersQuery(username));
            return Ok(orders);
        }

        // Obtener una orden por ID (Read)
        [HttpGet("{id}/{username}")]
        public async Task<ActionResult<Order>> Get(Guid id, string username)
        {
            var order = await _mediator.Send(new GetOrderByIdQuery(id, username));

            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }

        // Actualizar una orden (Update)
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateOrderCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await _mediator.Send(command);
            return NoContent();
        }

        // Eliminar una orden (Delete)
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteOrderCommand(id));
            return NoContent();
        }

    }
}

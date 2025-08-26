using banco_api.Application.UseCases.Movements.Commands.CreateMovement;
using banco_api.Application.UseCases.Movements.Commands.DeleteMovement;
using banco_api.Application.UseCases.Movements.Commands.UpdateMovement;
using banco_api.Application.UseCases.Movements.Dtos;
using banco_api.Application.UseCases.Movements.Queries.GetAllMovements;
using banco_api.Application.UseCases.Movements.Queries.GetMovementById;
using banco_api.Application.UseCases.Movements.Queries.GetMovementsByAccountId;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace banco_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovementController : Controller
    {
        private IMediator _mediator;
        public MovementController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Crear movimiento
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> AddMovement([FromBody] CreateMovementCommand command)
        {
            var result = await _mediator.Send(command);

            if (string.IsNullOrEmpty(result))
                return BadRequest("No se completó la creación del movimiento");

            return CreatedAtAction("AddMovement", new { id = result });
        }

        /// <summary>
        /// Actualizar cuenta
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMovement(string id, [FromBody] UpdateMovementRequest request)
        {
            var command = new UpdateMovementCommand(id, request);
            var result = await _mediator.Send(command);

            if (string.IsNullOrEmpty(result))
                return BadRequest("No se completó la actualización del movimiento");

            return CreatedAtAction("UpdateMovement", new { id = result });
        }

        /// <summary>
        /// Eliminar movimiento
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovement(string id)
        {
            var command = new DeleteMovementCommand(id);
            var result = await _mediator.Send(command);

            if (string.IsNullOrEmpty(result))
                return NotFound($"No se encontró el movimiento con Id {id}");

            return Ok($"Movimiento con Id {result} eliminado correctamente");
        }

        /// <summary>
        /// Obtener movimiento por Id
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<MovementDto>> GetAccountById(string id)
        {
            var query = new GetMovementByIdQuery(id);
            var result = await _mediator.Send(query);

            if (result is null)
                return NotFound("Cuenta no encontrada");

            return Ok(result);
        }

        /// <summary>
        /// Listar todos los movimientos
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovementDto>>> GetAllMovements()
        {
            var query = new GetAllMovementsQuery();
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        /// <summary>
        /// Obtener movimientos de una cuenta
        /// </summary>
        [HttpGet("ByAccount/{accountId}")]
        public async Task<ActionResult<IEnumerable<MovementDto>>> GetMovementsByAccountId(string accountId)
        {
            var query = new GetMovementsByAccountIdQuery(accountId);
            var result = await _mediator.Send(query);

            if (result == null || !result.Any())
                return NotFound("No se encontraron movimientos para esta cuenta");

            return Ok(result);
        }

    }
}

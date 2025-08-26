using banco_api.Application.UseCases.Clients.Commands.CreateClient;
using banco_api.Application.UseCases.Clients.Commands.ToggleStatus;
using banco_api.Application.UseCases.Clients.Commands.UpdateClient;
using banco_api.Application.UseCases.Clients.Dtos;
using banco_api.Application.UseCases.Clients.Queries.GetAllClients;
using banco_api.Application.UseCases.Clients.Queries.GetClientById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace banco_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : Controller
    {
        private readonly IMediator _mediator;

        public ClientController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Crear cliente
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> AddClient([FromBody] CreateClientCommand command)
        {
            var result = await _mediator.Send(command);

            if (string.IsNullOrEmpty(result))
                return BadRequest("No se completó la creación del cliente");

            return CreatedAtAction("AddClient", new { id = result });
        }

        /// <summary>
        /// Actualizar cliente
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateClient(string id, [FromBody] UpdateClientRequest request)
        {
            var command = new UpdateClientCommand(id, request);
            var result = await _mediator.Send(command);

            if (string.IsNullOrEmpty(result))
                return BadRequest("No se completó la actualización del cliente");

            return CreatedAtAction("UpdateClient", new { id = result });
        }

        /// <summary>
        /// Obtener cliente por Id
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<ClientDto>> GetClientById(string id)
        {
            var query = new GetClientByIdQuery(id);
            var result = await _mediator.Send(query);

            if (result is null)
                return NotFound("Cliente no encontrado");

            return Ok(result);
        }

        /// <summary>
        /// Listar todos los clientes
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClientDto>>> GetAllClients()
        {
            var query = new GetAllClientsQuery();
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        /// <summary>
        /// Toggle Status
        /// </summary>
        [HttpPatch]
        public async Task<IActionResult> ToggleStatus(ToggleStatusClientCommand request)
        {
            var result = await _mediator.Send(request);

            if (string.IsNullOrEmpty(result))
                return BadRequest("No se completó la eliminación de la cuenta");

            return CreatedAtAction("ToggleStatus", new { id = result });
        }
    }
}

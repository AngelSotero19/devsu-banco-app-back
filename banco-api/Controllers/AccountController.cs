using banco_api.Application.UseCases.Accounts.Commands.CreateAccount;
using banco_api.Application.UseCases.Accounts.Commands.ToggleStatus;
using banco_api.Application.UseCases.Accounts.Commands.UpdateAccount;
using banco_api.Application.UseCases.Accounts.Dtos;
using banco_api.Application.UseCases.Accounts.Queries.GetAccountById;
using banco_api.Application.UseCases.Accounts.Queries.GetAccountByIdClient;
using banco_api.Application.UseCases.Accounts.Queries.GetAllAcounts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace banco_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        private IMediator _mediator;
        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Crear cuenta
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> AddAccount([FromBody] CreateAccountCommand command)
        {
            var result = await _mediator.Send(command);

            if (string.IsNullOrEmpty(result))
                return BadRequest("No se completó la creación de la cuenta");

            return CreatedAtAction("AddAccount", new { id = result });
        }

        /// <summary>
        /// Actualizar cuenta
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAccount(string id, [FromBody] UpdateAccountRequest request)
        {
            var command = new UpdateAccountCommand(id, request);
            var result = await _mediator.Send(command);

            if (string.IsNullOrEmpty(result))
                return BadRequest("No se completó la actualización de la cuenta");

            return CreatedAtAction("UpdateAccount", new { id = result });
        }

        /// <summary>
        /// Toggle Status
        /// </summary>
        [HttpPatch]
        public async Task<IActionResult> ToggleStatus(ToggleStatusAccountCommand request)
        {
            var result = await _mediator.Send(request);

            if (string.IsNullOrEmpty(result))
                return BadRequest("No se completó la eliminación de la cuenta");

            return CreatedAtAction("ToggleStatus", new { id = result });
        }

        /// <summary>
        /// Obtener cuenta por Id
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<AccountDto>> GetAccountById(string id)
        {
            var query = new GetAccountByIdQuery(id);
            var result = await _mediator.Send(query);

            if (result is null)
                return NotFound("Cuenta no encontrada");

            return Ok(result);
        }

        /// <summary>
        /// Listar todas las cuentas
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccountDto>>> GetAllAccounts()
        {
            var query = new GetAllAccountsQuery();
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        /// <summary>
        /// Obtener todas las cuentas de un cliente por ClientId
        /// </summary>
        [HttpGet("ByClient/{clientId}")]
        public async Task<ActionResult<IEnumerable<AccountDto>>> GetAccountByIdClient(string clientId)
        {
            var query = new GetAccountByIdClientQuery(clientId);
            var result = await _mediator.Send(query);

            if (result == null || !result.Any())
                return NotFound($"No se encontraron cuentas para el cliente con Id {clientId}");

            return Ok(result);
        }
    }
}

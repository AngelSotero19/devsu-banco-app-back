using MediatR;
using Microsoft.AspNetCore.Mvc;
using banco_api.Application.UseCases.AccountType.Dtos;
using banco_api.Application.UseCases.AccountType.Queries.GetAccountTypeById;
using banco_api.Application.UseCases.AccountType.Queries.GetAllAccountTypes;

namespace banco_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountTypeController : Controller
    {
        private readonly IMediator _mediator;

        public AccountTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Obtener tipo de cuenta por Id
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<AccountTypeDto>> GetAccountTypeById(string id)
        {
            var query = new GetAccountTypeByIdQuery(id);
            var result = await _mediator.Send(query);

            if (result is null)
                return NotFound("Tipo de cuenta no encontrado");

            return Ok(result);
        }

        /// <summary>
        /// Listar todos los tipos de cuenta
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccountTypeDto>>> GetAllAccountTypes()
        {
            var query = new GetAllAccountTypesQuery();
            var result = await _mediator.Send(query);

            return Ok(result);
        }
    }
}

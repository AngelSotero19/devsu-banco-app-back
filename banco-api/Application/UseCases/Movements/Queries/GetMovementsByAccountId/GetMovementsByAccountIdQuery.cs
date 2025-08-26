using banco_api.Application.UseCases.Movements.Dtos;
using MediatR;

namespace banco_api.Application.UseCases.Movements.Queries.GetMovementsByAccountId
{
    public class GetMovementsByAccountIdQuery : IRequest<IEnumerable<MovementDto>>
    {
        public string AccountId { get; set; }

        public GetMovementsByAccountIdQuery(string accountId)
        {
            AccountId = accountId;
        }
    }
}
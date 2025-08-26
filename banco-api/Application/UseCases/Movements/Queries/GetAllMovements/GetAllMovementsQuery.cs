using banco_api.Application.UseCases.Movements.Dtos;
using MediatR;

namespace banco_api.Application.UseCases.Movements.Queries.GetAllMovements
{
    public class GetAllMovementsQuery() : IRequest<IEnumerable<MovementDto>>;
}

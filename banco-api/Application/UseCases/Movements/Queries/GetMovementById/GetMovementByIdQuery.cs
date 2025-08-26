using banco_api.Application.UseCases.Movements.Dtos;
using MediatR;

namespace banco_api.Application.UseCases.Movements.Queries.GetMovementById
{
    public record class GetMovementByIdQuery(string Id) : IRequest<MovementDto>;
}

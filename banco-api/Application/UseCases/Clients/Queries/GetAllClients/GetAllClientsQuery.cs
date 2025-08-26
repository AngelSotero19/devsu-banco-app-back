using banco_api.Application.UseCases.Clients.Dtos;
using MediatR;

namespace banco_api.Application.UseCases.Clients.Queries.GetAllClients
{
    public record class GetAllClientsQuery : IRequest<IEnumerable<ClientDto>>;
}
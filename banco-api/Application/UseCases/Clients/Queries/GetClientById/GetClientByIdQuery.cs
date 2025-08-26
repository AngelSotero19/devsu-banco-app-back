using banco_api.Application.UseCases.Clients.Dtos;
using MediatR;

namespace banco_api.Application.UseCases.Clients.Queries.GetClientById
{
    public record class GetClientByIdQuery(string Id) : IRequest<ClientDto>;
}
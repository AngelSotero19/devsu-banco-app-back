using banco_api.Application.UseCases.Accounts.Dtos;
using MediatR;

namespace banco_api.Application.UseCases.Accounts.Queries.GetAccountById
{
    public record class GetAccountByIdQuery(string Id) : IRequest<AccountDto>;
}

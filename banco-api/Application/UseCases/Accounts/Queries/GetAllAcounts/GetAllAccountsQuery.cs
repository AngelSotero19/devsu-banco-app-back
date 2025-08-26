using banco_api.Application.UseCases.Accounts.Dtos;
using MediatR;

namespace banco_api.Application.UseCases.Accounts.Queries.GetAllAcounts
{
    public record GetAllAccountsQuery() : IRequest<IEnumerable<AccountDto>>;
}
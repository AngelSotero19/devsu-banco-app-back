using banco_api.Application.UseCases.AccountType.Dtos;
using MediatR;

namespace banco_api.Application.UseCases.AccountType.Queries.GetAccountTypeById
{
    public record class GetAccountTypeByIdQuery(string Id) : IRequest<AccountTypeDto>;
}

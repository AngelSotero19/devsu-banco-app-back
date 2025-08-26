using banco_api.Application.UseCases.AccountType.Dtos;
using MediatR;

namespace banco_api.Application.UseCases.AccountType.Queries.GetAllAccountTypes
{
    public record class GetAllAccountTypesQuery() : IRequest<IEnumerable<AccountTypeDto>>;
}

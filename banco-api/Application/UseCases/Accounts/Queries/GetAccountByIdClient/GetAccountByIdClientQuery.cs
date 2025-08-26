using banco_api.Application.UseCases.Accounts.Dtos;
using MediatR;

namespace banco_api.Application.UseCases.Accounts.Queries.GetAccountByIdClient
{
    public class GetAccountByIdClientQuery : IRequest<IEnumerable<AccountDto>>
    {
        public string ClientId { get; set; }

        public GetAccountByIdClientQuery(string clientId)
        {
            ClientId = clientId;
        }
    }
}
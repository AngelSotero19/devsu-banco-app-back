using MediatR;

namespace banco_api.Application.UseCases.Accounts.Commands.UpdateAccount
{
    public class UpdateAccountRequest : IRequest<string>
    {
        public string AccountTypeId { get; set; }

        public string ClientId { get; set; }

        public string AccountNumer { get; set; }

        public decimal? InitialBalance { get; set; }

        public bool? Status { get; set; }
    }
}

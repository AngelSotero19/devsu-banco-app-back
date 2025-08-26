using MediatR;

namespace banco_api.Application.UseCases.Accounts.Commands.UpdateAccount
{
    public class UpdateAccountCommand(string pId, UpdateAccountRequest request) : IRequest<string>
    {
        public string Id { get; set; } = pId;

        public string AccountTypeId { get; set; } = request.AccountTypeId;

        public string ClientId { get; set; } = request.ClientId;

        public string AccountNumer { get; set; } = request.AccountNumer;

        public decimal? InitialBalance { get; set; } = request.InitialBalance;

        public bool? Status { get; set; } = request.Status;
    }
}

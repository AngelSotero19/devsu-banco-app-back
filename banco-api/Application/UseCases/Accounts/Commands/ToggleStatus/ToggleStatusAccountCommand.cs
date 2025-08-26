using MediatR;

namespace banco_api.Application.UseCases.Accounts.Commands.ToggleStatus
{
    public class ToggleStatusAccountCommand : IRequest<string>
    {
        public string Id { get; set; }
        public bool NewStatus { get; set; }
    }
}

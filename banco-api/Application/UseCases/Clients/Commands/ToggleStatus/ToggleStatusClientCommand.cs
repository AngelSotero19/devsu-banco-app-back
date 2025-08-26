using MediatR;

namespace banco_api.Application.UseCases.Clients.Commands.ToggleStatus
{
    public class ToggleStatusClientCommand : IRequest<string>
    {
        public string Id { get; set; }
        public bool NewStatus { get; set; }
    }
}

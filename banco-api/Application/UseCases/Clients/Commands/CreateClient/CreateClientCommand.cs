using MediatR;

namespace banco_api.Application.UseCases.Clients.Commands.CreateClient
{
    public class CreateClientCommand : IRequest<string>
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string Credential { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        public string Password { get; set; }
        public bool Status { get; set; }
    }
}

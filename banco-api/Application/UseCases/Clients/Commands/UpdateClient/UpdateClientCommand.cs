using MediatR;

namespace banco_api.Application.UseCases.Clients.Commands.UpdateClient
{
    public class UpdateClientCommand(string pId, UpdateClientRequest request) : IRequest<string>
    {
        public string Id { get; set; } = pId;
        public string PersonId { get; set; } = request.PersonId;
        public string Name { get; set; } = request.Name;
        public string Gender { get; set; } = request.Gender;
        public int Age { get; set; } = request.Age;
        public string Credential { get; set; } = request.Credential;
        public string Address { get; set; } = request.Address;
        public string Phone { get; set; } = request.Phone;

        public string Password { get; set; } = request.Password;
        public bool Status { get; set; } = request.Status;
    }
}

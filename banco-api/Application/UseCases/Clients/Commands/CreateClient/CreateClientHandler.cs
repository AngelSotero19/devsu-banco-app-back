using AutoMapper;
using banco_api.Application.Interfaces.Repositories;
using banco_api.Domain.Models;
using MediatR;

namespace banco_api.Application.UseCases.Clients.Commands.CreateClient
{
    public class CreateClientHandler : IRequestHandler<CreateClientCommand, string>
    {
        private readonly IPersonRepository _personRepository;
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;

        public CreateClientHandler(IPersonRepository personRepository, IClientRepository clientRepository, IMapper mapper)
        {
            _personRepository = personRepository;
            _clientRepository = clientRepository;
            _mapper = mapper;
        }

        public async Task<string> Handle(CreateClientCommand request, CancellationToken cancellationToken)
        {
            var person = _mapper.Map<Person>(request);
            person.Id = Guid.NewGuid().ToString();

            await _personRepository.AddPersonAsync(person);

            var client = _mapper.Map<Client>(request);
            client.Id = Guid.NewGuid().ToString();
            client.PersonId = person.Id;

            await _clientRepository.AddClientAsync(client);

            return client.Id;
        }
    }
}

using AutoMapper;
using banco_api.Application.Interfaces.Repositories;
using banco_api.Application.UseCases.Clients.Dtos;
using MediatR;

namespace banco_api.Application.UseCases.Clients.Commands.UpdateClient
{
    public class UpdateClientHandler : IRequestHandler<UpdateClientCommand, string>
    {
        private readonly IClientRepository _clientRepository;
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;

        public UpdateClientHandler(IClientRepository clientRepository, IPersonRepository personRepository, IMapper mapper)
        {
            _clientRepository = clientRepository;
            _personRepository = personRepository;
            _mapper = mapper;
        }

        public async Task<string> Handle(UpdateClientCommand request, CancellationToken cancellationToken)
        {
            var client = _mapper.Map<ClientDto>(request);
            await _personRepository.UpdatePersonAsync(client);
            await _clientRepository.UpdateClientAsync(client);

            return client.Id;
        }
    }
}

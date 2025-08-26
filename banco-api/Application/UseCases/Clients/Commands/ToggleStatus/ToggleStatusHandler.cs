using AutoMapper;
using banco_api.Application.Interfaces.Repositories;
using banco_api.Application.UseCases.Clients.Dtos;
using banco_api.Domain.Models;
using MediatR;

namespace banco_api.Application.UseCases.Clients.Commands.ToggleStatus
{
    public class ToggleStatusHandler : IRequestHandler<ToggleStatusClientCommand, string>
    {
        private readonly IClientRepository _clientRepository;
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;

        public ToggleStatusHandler(IClientRepository clientRepository, IPersonRepository personRepository, IMapper mapper)
        {
            _clientRepository = clientRepository;
            _personRepository = personRepository;
            _mapper = mapper;
        }

        public async Task<string> Handle(ToggleStatusClientCommand request, CancellationToken cancellationToken)
        {
            var clientToggleRequest = _mapper.Map<ClientToggleRequest>(request);
            var clientId = await _clientRepository.ToggleStatusAsync(clientToggleRequest);
            return clientId;
        }
    }
}

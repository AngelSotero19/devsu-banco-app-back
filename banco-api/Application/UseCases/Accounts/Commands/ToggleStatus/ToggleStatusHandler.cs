using AutoMapper;
using banco_api.Application.Interfaces.Repositories;
using banco_api.Application.UseCases.Accounts.Dtos;
using MediatR;

namespace banco_api.Application.UseCases.Accounts.Commands.ToggleStatus
{
    public class ToggleStatusHandler : IRequestHandler<ToggleStatusAccountCommand, string>
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;

        public ToggleStatusHandler(IAccountRepository accountRepository, IMapper mapper)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
        }

        public async Task<string> Handle(ToggleStatusAccountCommand request, CancellationToken cancellationToken)
        {
            var accountToggleRequest = _mapper.Map<AccountToggleRequest>(request);
            var accountId = await _accountRepository.ToggleStatusAsync(accountToggleRequest);
            return accountId;
        }
    }
}

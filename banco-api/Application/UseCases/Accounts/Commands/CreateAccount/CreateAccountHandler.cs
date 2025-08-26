using AutoMapper;
using banco_api.Application.Interfaces.Repositories;
using MediatR;
using banco_api.Domain.Models;

namespace banco_api.Application.UseCases.Accounts.Commands.CreateAccount
{
    public class CreateAccountHandler : IRequestHandler<CreateAccountCommand, string>
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;

        public CreateAccountHandler(IAccountRepository accountRepository, IMapper mapper)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
        }

        public async Task<string> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {
            var account = _mapper.Map<Account>(request);
            account.Id = Guid.NewGuid().ToString();
            var saved = await _accountRepository.AddAccountAsync(account);
            if (string.IsNullOrEmpty(saved))
                return string.Empty;
            return saved;
        }
    }
}

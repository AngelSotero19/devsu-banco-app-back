using AutoMapper;
using banco_api.Application.Interfaces.Repositories;
using banco_api.Domain.Models;
using MediatR;

namespace banco_api.Application.UseCases.Accounts.Commands.UpdateAccount
{
    public class UpdateAccountHandler : IRequestHandler<UpdateAccountCommand, string>
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;

        public UpdateAccountHandler(IAccountRepository accountRepository, IMapper mapper)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
        }

        public async Task<string> Handle(UpdateAccountCommand request, CancellationToken cancellationToken)
        {
            var existing = await _accountRepository.GetByIdAsync(request.Id);
            if (existing is null)
                return string.Empty;

            _mapper.Map(request, existing);

            var saved = await _accountRepository.UpdateAccountAsync(existing);

            return saved;
        }
    }
}

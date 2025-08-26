using AutoMapper;
using banco_api.Application.Interfaces.Repositories;
using banco_api.Application.UseCases.Accounts.Dtos;
using MediatR;

namespace banco_api.Application.UseCases.Accounts.Queries.GetAccountById
{
    public class GetAccountByIdHandler : IRequestHandler<GetAccountByIdQuery, AccountDto>
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;

        public GetAccountByIdHandler(IAccountRepository accountRepository, IMapper mapper)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
        }

        public async Task<AccountDto> Handle(GetAccountByIdQuery request, CancellationToken cancellationToken)
        {
            var account = await _accountRepository.GetByIdAsync(request.Id);

            if (account is null)
                throw new KeyNotFoundException("No se encontro la cuenta");

            return _mapper.Map<AccountDto>(account);
        }
    }
}

using AutoMapper;
using banco_api.Application.Interfaces.Repositories;
using banco_api.Application.UseCases.Accounts.Dtos;
using banco_api.Application.UseCases.Accounts.Queries.GetAllAcounts;
using MediatR;

namespace banco_api.Application.UseCases.Accounts.Queries.GetAllAccounts
{
    public class GetAllAccountsHandler : IRequestHandler<GetAllAccountsQuery, IEnumerable<AccountDto>>
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;

        public GetAllAccountsHandler(IAccountRepository accountRepository, IMapper mapper)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AccountDto>> Handle(GetAllAccountsQuery request, CancellationToken cancellationToken)
        {
            var accounts = await _accountRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<AccountDto>>(accounts);
        }
    }
}
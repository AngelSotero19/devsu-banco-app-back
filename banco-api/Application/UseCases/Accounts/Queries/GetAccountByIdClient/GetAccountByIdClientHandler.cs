using AutoMapper;
using banco_api.Application.Interfaces.Repositories;
using banco_api.Application.UseCases.Accounts.Dtos;
using MediatR;

namespace banco_api.Application.UseCases.Accounts.Queries.GetAccountByIdClient
{
    public class GetAccountByIdClientHandler : IRequestHandler<GetAccountByIdClientQuery, IEnumerable<AccountDto>>
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;

        public GetAccountByIdClientHandler(IAccountRepository accountRepository, IMapper mapper)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AccountDto>> Handle(GetAccountByIdClientQuery request, CancellationToken cancellationToken)
        {
            var accounts = await _accountRepository.GetByClientIdAsync(request.ClientId);
            return _mapper.Map<IEnumerable<AccountDto>>(accounts);
        }
    }
}

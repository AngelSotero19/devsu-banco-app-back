using AutoMapper;
using banco_api.Application.Interfaces.Repositories;
using banco_api.Application.UseCases.AccountType.Dtos;
using MediatR;

namespace banco_api.Application.UseCases.AccountType.Queries.GetAccountTypeById
{
    public class GetAccountTypeByIdHandler : IRequestHandler<GetAccountTypeByIdQuery, AccountTypeDto>
    {
        private readonly IAccountTypeRepository _repository;
        private readonly IMapper _mapper;

        public GetAccountTypeByIdHandler(IAccountTypeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<AccountTypeDto> Handle(GetAccountTypeByIdQuery request, CancellationToken cancellationToken)
        {
            var accountType = await _repository.GetByIdAsync(request.Id);

            if (accountType is null)
                throw new KeyNotFoundException("No se encontró el tipo de cuenta");

            return _mapper.Map<AccountTypeDto>(accountType);
        }
    }
}

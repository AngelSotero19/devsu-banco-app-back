using AutoMapper;
using banco_api.Application.Interfaces.Repositories;
using banco_api.Application.UseCases.AccountType.Dtos;
using MediatR;

namespace banco_api.Application.UseCases.AccountType.Queries.GetAllAccountTypes
{
    public class GetAllAccountTypesHandler : IRequestHandler<GetAllAccountTypesQuery, IEnumerable<AccountTypeDto>>
    {
        private readonly IAccountTypeRepository _repository;
        private readonly IMapper _mapper;

        public GetAllAccountTypesHandler(IAccountTypeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AccountTypeDto>> Handle(GetAllAccountTypesQuery request, CancellationToken cancellationToken)
        {
            var accountTypes = await _repository.GetAllAsync();

            if (accountTypes is null || !accountTypes.Any())
                throw new KeyNotFoundException("No se encontraron tipos de cuenta");

            return _mapper.Map<IEnumerable<AccountTypeDto>>(accountTypes);
        }
    }
}

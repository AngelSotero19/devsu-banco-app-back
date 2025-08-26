using AutoMapper;
using banco_api.Application.Interfaces.Repositories;
using banco_api.Application.UseCases.Movements.Dtos;
using MediatR;

namespace banco_api.Application.UseCases.Movements.Queries.GetMovementsByAccountId
{
    public class GetMovementsByAccountIdHandler : IRequestHandler<GetMovementsByAccountIdQuery, IEnumerable<MovementDto>>
    {
        private readonly IMovementRepository _movementRepository;
        private readonly IMapper _mapper;

        public GetMovementsByAccountIdHandler(IMovementRepository movementRepository, IMapper mapper)
        {
            _movementRepository = movementRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MovementDto>> Handle(GetMovementsByAccountIdQuery request, CancellationToken cancellationToken)
        {
            var movements = await _movementRepository.GetByAccountIdAsync(request.AccountId);
            return _mapper.Map<IEnumerable<MovementDto>>(movements);
        }
    }
}

using AutoMapper;
using banco_api.Application.Interfaces.Repositories;
using banco_api.Application.UseCases.Movements.Dtos;
using MediatR;

namespace banco_api.Application.UseCases.Movements.Queries.GetAllMovements
{
    public class GetAllMovementsHandler : IRequestHandler<GetAllMovementsQuery, IEnumerable<MovementDto>>
    {
        private readonly IMovementRepository _movementRepository;
        private readonly IMapper _mapper;

        public GetAllMovementsHandler(IMovementRepository movementRepository, IMapper mapper)
        {
            _movementRepository = movementRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MovementDto>> Handle(GetAllMovementsQuery request, CancellationToken cancellationToken)
        {
            var accounts = await _movementRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<MovementDto>>(accounts);
        }
    }
}

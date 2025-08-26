using AutoMapper;
using banco_api.Application.Interfaces.Repositories;
using banco_api.Application.UseCases.Movements.Dtos;
using MediatR;

namespace banco_api.Application.UseCases.Movements.Queries.GetMovementById
{
    public class GetMovementByIdHandler : IRequestHandler<GetMovementByIdQuery, MovementDto>
    {
        private readonly IMovementRepository _movementRepository;
        private readonly IMapper _mapper;

        public GetMovementByIdHandler(IMovementRepository movementRepository, IMapper mapper)
        {
            _movementRepository = movementRepository;
            _mapper = mapper;
        }

        public async Task<MovementDto> Handle(GetMovementByIdQuery request, CancellationToken cancellationToken)
        {
            var account = await _movementRepository.GetByIdAsync(request.Id);

            if (account is null)
                throw new KeyNotFoundException("No se encontro el movimiento");

            return _mapper.Map<MovementDto>(account);
        }
    }
}

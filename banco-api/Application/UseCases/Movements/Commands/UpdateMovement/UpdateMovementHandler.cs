using AutoMapper;
using banco_api.Application.Interfaces.Repositories;
using MediatR;

namespace banco_api.Application.UseCases.Movements.Commands.UpdateMovement
{
    public class UpdateMovementHandler : IRequestHandler<UpdateMovementCommand, string>
    {
        private readonly IMovementRepository _movementRepository;
        private readonly IMapper _mapper;

        public UpdateMovementHandler(IMovementRepository movementRepository, IMapper mapper)
        {
            _movementRepository = movementRepository;
            _mapper = mapper;
        }

        public async Task<string> Handle(UpdateMovementCommand request, CancellationToken cancellationToken)
        {
            var existing = await _movementRepository.GetByIdAsync(request.Id);
            if (existing is null)
                return string.Empty;
            _mapper.Map(request, existing);

            var saved = await _movementRepository.UpdateMovementAsync(existing);

            return saved;
        }
    }
}
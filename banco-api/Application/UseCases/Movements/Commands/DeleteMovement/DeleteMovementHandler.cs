using AutoMapper;
using banco_api.Application.Interfaces.Repositories;
using banco_api.Infrastructure.Repositories;
using MediatR;

namespace banco_api.Application.UseCases.Movements.Commands.DeleteMovement
{
    public class DeleteMovementHandler : IRequestHandler<DeleteMovementCommand, string>
    {
        private readonly IMovementRepository _movementRepository;
        private readonly IMapper _mapper;

        public DeleteMovementHandler(IMovementRepository movementRepository, IMapper mapper)
        {
            _movementRepository = movementRepository;
            _mapper = mapper;
        }

        public async Task<string> Handle(DeleteMovementCommand request, CancellationToken cancellationToken)
        {
            var existing = await _movementRepository.GetByIdAsync(request.Id);
            if (existing is null)
                return string.Empty;

            var deleted = await _movementRepository.DeleteMovementAsync(existing);
            return deleted;
        }
    }
}

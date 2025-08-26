using AutoMapper;
using banco_api.Application.Interfaces.Repositories;
using banco_api.Domain.Models;
using MediatR;

namespace banco_api.Application.UseCases.Movements.Commands.CreateMovement
{
    public class CreateMovementHandler : IRequestHandler<CreateMovementCommand, string>
    {
        private readonly IMovementRepository _movementRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;

        public CreateMovementHandler(IMovementRepository movementRepository, IAccountRepository accountRepository, IMapper mapper)
        {
            _movementRepository = movementRepository;
            _accountRepository = accountRepository;
            _mapper = mapper;
        }

        public async Task<string> Handle(CreateMovementCommand request, CancellationToken cancellationToken)
        {
            var account = await _accountRepository.GetByIdAsync(request.AccountId);
            if (account == null)
                throw new Exception("La cuenta no existe");

            var movement = _mapper.Map<Movement>(request);
            movement.Id = Guid.NewGuid().ToString();
            movement.Date ??= DateTime.Now;

            var value = request.Value ?? 0;

            if (value <= 0)
                throw new Exception("El valor del movimiento debe ser mayor a 0");

            if (request.MovementType.ToUpper() == "DEBITO")
            {
                if (account.InitialBalance < value)
                    throw new Exception("Saldo no disponible");

                var totalDebitsToday = await _movementRepository.GetDebitsByDay(account.Id, movement.Date.Value);
                if (totalDebitsToday + value > 1000)
                    throw new Exception("Cupo diario excedido");

                account.InitialBalance -= value;
            }
            else if (request.MovementType.ToUpper() == "CREDITO")
            {
                account.InitialBalance += value;
            }
            else
            {
                throw new Exception("Tipo de movimiento inválido. Use DEBITO o CREDITO");
            }

            movement.Value = value;
            movement.Balance = account.InitialBalance;
            var saved = await _movementRepository.AddMovementAsync(movement);
            await _accountRepository.UpdateAccountAsync(account);

            return saved;
        }
    }
}

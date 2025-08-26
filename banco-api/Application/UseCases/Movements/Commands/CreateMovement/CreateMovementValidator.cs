using FluentValidation;

namespace banco_api.Application.UseCases.Movements.Commands.CreateMovement
{
    public class CreateMovementValidator : AbstractValidator<CreateMovementCommand>
    {
        public CreateMovementValidator()
        {
            RuleFor(a => a.AccountId)
                .NotEmpty().WithMessage("La cuenta es requerida.");

            RuleFor(a => a.Date)
                .NotEmpty().WithMessage("La fecha es requerida.");

            RuleFor(a => a.MovementType)
                .NotEmpty().WithMessage("El tipo de movimiento es requerido.");

            RuleFor(a => a.Value)
                .NotEmpty().WithMessage("El valor es requerido.")
                .PrecisionScale(10, 2, false);

            RuleFor(a => a.Balance)
                .NotEmpty().WithMessage("El balance es requerido.")
                .PrecisionScale(10, 2, false);
        }
    }
}

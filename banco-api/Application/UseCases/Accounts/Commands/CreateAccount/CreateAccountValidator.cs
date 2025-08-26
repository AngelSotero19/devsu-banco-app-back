using banco_api.Application.UseCases.Accounts.Dtos;
using FluentValidation;

namespace banco_api.Application.UseCases.Accounts.Commands.CreateAccount
{
    public class CreateAccountValidator : AbstractValidator<CreateAccountCommand>
    {
        public CreateAccountValidator()
        {
            RuleFor(a => a.AccountTypeId)
                .NotEmpty().WithMessage("El tipo de cuenta es requerido.");

            RuleFor(a => a.ClientId)
                .NotEmpty().WithMessage("El cliente es requerido.");

            RuleFor(a => a.AccountNumer)
                .NotEmpty().WithMessage("El numero de cuenta es requerido.");

            RuleFor(a => a.InitialBalance)
                .NotEmpty().WithMessage("El balance es requerido.")
                .PrecisionScale(10, 2, false);
        }
    }
}

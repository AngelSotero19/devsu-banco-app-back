using FluentValidation;

namespace banco_api.Application.UseCases.Clients.Commands.CreateClient
{
    public class CreateClientValidator : AbstractValidator<CreateClientCommand>
    {
        public CreateClientValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("El nombre es obligatorio");

            RuleFor(x => x.Gender)
                .NotEmpty().WithMessage("El género es obligatorio");

            RuleFor(x => x.Age)
                .GreaterThan(0).WithMessage("La edad debe ser mayor a 0");

            RuleFor(x => x.Credential)
                .NotEmpty().WithMessage("La credencial es obligatoria");

            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("La dirección es obligatoria");

            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("El teléfono es obligatorio");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("La contraseña es obligatoria");
        }
    }
}

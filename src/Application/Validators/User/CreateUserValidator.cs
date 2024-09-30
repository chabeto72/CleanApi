using Application.Database.User.Commands.CreateUser;
using FluentValidation;

namespace Application.Validators.User
{
    public class CreateUserValidator:AbstractValidator<CreateUserModel>
    {
        public CreateUserValidator()
        {
            RuleFor(x => x.Nombre).NotNull().WithMessage("No puede ser nulo").NotEmpty().MaximumLength(30);
            RuleFor(x => x.Documento).NotNull().WithMessage("No puede ser nulo").NotEmpty().MaximumLength(30);
           
        }
    }
}

using Application.Database.User.Commands.CreateUser;
using FluentValidation;

namespace Application.Validators.User
{
    public class CreateUserValidator:AbstractValidator<CreateUserModel>
    {
        public CreateUserValidator()
        {
            RuleFor(x => x.FirtsName).NotNull().WithMessage("No puede ser nulo").NotEmpty().MaximumLength(30);
            RuleFor(x => x.LastName).NotNull().WithMessage("No puede ser nulo").NotEmpty().MaximumLength(30);
            RuleFor(x => x.Code).NotNull().WithMessage("No puede ser nulo").NotEmpty().MaximumLength(10);
        }
    }
}

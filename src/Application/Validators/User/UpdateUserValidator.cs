using Application.Database.User.Commands.CreateUser;
using Application.Database.User.Commands.UpdateUser;
using FluentValidation;

namespace Application.Validators.User
{
    public class UpdateUserValidator : AbstractValidator<UpdateUserModel>
    {
        public UpdateUserValidator()
        {
            RuleFor(x => x.UserId).NotNull().GreaterThan(0);
            RuleFor(x => x.FirtsName).NotNull().WithMessage("No puede ser nulo").NotEmpty().MaximumLength(30);
            RuleFor(x => x.LastName).NotNull().WithMessage("No puede ser nulo").NotEmpty().MaximumLength(30);
            RuleFor(x => x.Code).NotNull().WithMessage("No puede ser nulo").NotEmpty().MaximumLength(10);
        }
    }
}

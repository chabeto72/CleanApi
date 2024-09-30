using Application.Database.User.Commands.CreateUser;
using Application.Database.User.Commands.UpdateUser;
using FluentValidation;

namespace Application.Validators.User
{
    public class UpdateUserValidator : AbstractValidator<UpdateUserModel>
    {
        public UpdateUserValidator()
        {
            RuleFor(x => x.Id).NotNull().GreaterThan(0);
            RuleFor(x => x.Nombre).NotNull().WithMessage("No puede ser nulo").NotEmpty().MaximumLength(30);
           
        }
    }
}

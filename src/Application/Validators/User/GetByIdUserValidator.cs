using Application.Database.User.Commands.UpdateUser;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators.User
{
    public class GetByIdUserValidator: AbstractValidator<int>
    {
        public GetByIdUserValidator()
        {
            RuleFor(x => x).NotNull().GreaterThan(0).WithMessage("el valor del usuario no puede ser cero");
        }
    }
}

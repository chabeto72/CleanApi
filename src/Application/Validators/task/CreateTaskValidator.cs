using Application.Database.User.Commands.CreateUser;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators.task
{
    public class CreateTaskValidator: AbstractValidator<CreateTaskModel>
    {
        public CreateTaskValidator()
        {
            RuleFor(x => x.Nombre_tarea).NotNull().WithMessage("No puede ser nulo").NotEmpty().MaximumLength(30);
            RuleFor(x => x.Nota).NotNull().WithMessage("No puede ser nulo").NotEmpty().MaximumLength(50);

        }
    }
}

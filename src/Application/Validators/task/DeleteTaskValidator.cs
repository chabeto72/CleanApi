using Application.Database.User.Commands.UpdateUser;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators.task
{
    public class DeleteTaskValidator: AbstractValidator<Guid>
    {
        public DeleteTaskValidator()
        {

            RuleFor(x => x)
            .NotEmpty().WithMessage("El UserId no puede estar vacío.")
            .Must(BeAValidGuid).WithMessage("El UserId debe ser un GUID válido.");



        }
        private bool BeAValidGuid(Guid guid)
        {
            return guid != Guid.Empty;
        }
    }
}

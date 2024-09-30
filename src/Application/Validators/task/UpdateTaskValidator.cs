using Application.Database.User.Commands.UpdateUser;
using Application.Validators.User;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators.task
{
    public class UpdateTaskValidator : AbstractValidator<UpdateTaskModel>
    {
        public UpdateTaskValidator()
        {
         
                RuleFor(x => x.Id).NotNull().WithMessage("No puede ser nulo").NotEmpty(); 
                RuleFor(x => x.Id_asignado).GreaterThan(0);

          

        }
    }
}

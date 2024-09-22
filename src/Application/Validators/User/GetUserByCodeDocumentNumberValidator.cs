using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators.User
{
    public class GetUserByCodeDocumentNumberValidator: AbstractValidator<(string,string)>
    {
        public GetUserByCodeDocumentNumberValidator()
        {
            RuleFor(x => x.Item1).NotNull().NotEmpty();
            RuleFor(x => x.Item2).NotNull().NotEmpty();
        }
    }
}

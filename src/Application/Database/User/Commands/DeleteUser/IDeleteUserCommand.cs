using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Database.User.Commands.DeleteUser
{
    public interface IDeleteUserCommand
    {
        Task<bool> Execute(int idUser);
    }
}

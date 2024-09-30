using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Database.User.Commands.UpdateUser
{
    public interface IUpdateTaskCommand
    {
        Task<UpdateTaskModel> Execute(UpdateTaskModel model);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Database.User.Commands.CreateUser
{
    public interface ICreateTaskCommand
    {
        Task<CreateTaskModel> Execute(CreateTaskModel model);
    }
}

using Application.Database.User.Querys.GetAllUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Database.User.Querys.GetAllTask
{
    public interface IGetAllTaskQuery
    {
        Task<List<GetAllTaskModel>> Execute();
    }
}

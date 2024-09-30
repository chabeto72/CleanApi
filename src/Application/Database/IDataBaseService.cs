//using Domain.Entities.Rol;
//using Domain.Entities.Task;
//using Domain.Entities.User;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataBase
{
    public interface IDataBaseService
    {
        DbSet<User> User { get; set; }
        DbSet<TaskUser> TaskUser { get; set; }
        DbSet<Rol> Rol { get; set; }
        Task<bool> SaveAsync();
    }
}

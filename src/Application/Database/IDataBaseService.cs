using Domain.Entities.Rol;
using Domain.Entities.Task;
using Domain.Entities.User;
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
        DbSet<UserEntity> User { get; set; }
        DbSet<TaskEntity> Task { get; set; }
        DbSet<RolEntity> Rol { get; set; }
        Task<bool> SaveAsync();
    }
}

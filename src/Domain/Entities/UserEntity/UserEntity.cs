using Domain.Entities.RolEntity;
using Domain.Entities.TaskEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.UserEntity
{
    public  class UserEntity
    {
        public int? UserId { get; set; }
        public int? RolUser { get; set; }
        public string? FirtsName { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? NumberDocument { get; set; }
        public string? Password { get; set; }
        public bool? Active { get; set; }
        //public RolEntity Rol { get; set; }
        //public ICollection<TaskEntity> Tasks { get; set; }

    }

    
}

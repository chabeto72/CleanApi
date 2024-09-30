using Domain.Entities.UserEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.TaskEntity
{
    public class TaskEntity
    {
    
        public Guid TaskID { get; set; }
        public string? Name { get; set; }
        public bool? State { get; set; }
        public DateTime? DateTask { get; set; }
        public string? Detail { get; set; }
        public int? UserTask { get; set; }
        //public UserEntity  User { get; set; }
    }
}

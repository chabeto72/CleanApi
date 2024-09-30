﻿using Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Rol
{
    public class RolEntity
    {    
        public int RolID { get; set; }
        public string? RolName { get; set; }
        public string? Code { get; set; }
        public ICollection<UserEntity> Users { get; set; }
      
    }
}

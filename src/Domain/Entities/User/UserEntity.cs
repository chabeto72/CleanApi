﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.User
{
    public  class UserEntity
    {
        public int UserId { get; set; }
        public string FirtsName { get; set; }
        public string LastName { get; set; }
        public string Code { get; set; }
        public string NumberDocument { get; set; }
        public string Password { get; set; }

    }

    
}

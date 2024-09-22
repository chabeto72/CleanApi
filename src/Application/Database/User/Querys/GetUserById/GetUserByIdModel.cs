using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Database.User.Querys.GetUserById
{
    public class GetUserByIdModel
    {
        public int UserId { get; set; }
        public string FirtsName { get; set; }
        public string LastName { get; set; }
        public string Code { get; set; }
        public string NumberDocument { get; set; }
      
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Database.User.Commands.UpdateUser
{
    public class UpdateUserModel
    {
        //public int UserId { get; set; }
        //public string FirtsName { get; set; }
        //public string LastName { get; set; }
        //public string Code { get; set; }
        //public string NumberDocument { get; set; }
        //public string Password { get; set; }
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string? Direccion { get; set; }
        public string Documento { get; set; }
        public string codigo_rol { get; set; }
        public string Rol { get; set; }
    }
}

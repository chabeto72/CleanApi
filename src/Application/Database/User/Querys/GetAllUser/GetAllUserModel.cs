using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Database.User.Querys.GetAllUser
{
    public class GetAllUserModel
    {
        public int? Id { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }
        public string Documento { get; set; }
        public string Codigo_rol { get; set; }
        public string Rol { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Database.User.Commands.UpdateUser
{
    public class UpdateTaskModel
    {
        public string Id { get; set; }
        public int Id_asignado { get; set; }
        //public string Nombre_asignado { get; set; }
        public string Nombre_tarea { get; set; }
        public bool Estado { get; set; }
        public string Nota { get; set; }
        public DateTime Fecha { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaPOPA
{
    public class UsuariosDto
    {
        public int id_usuario { get; set; }
        public string nombre { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string rol { get; set; }
        public Boolean estado { get; set; }
    }
}

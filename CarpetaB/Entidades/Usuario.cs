using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
   public class Usuario
    {
        public int idUsuario { get; set; }
        public int idPerfil { get; set; }
        public string email { get; set; }
        public string contrasena { get; set; }
        public bool estado { get; set; }
        public string nombrePerfil { get; set; }
    }
}

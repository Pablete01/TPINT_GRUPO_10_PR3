using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Negocio
{
    public class NegocioLogin
    {
        public bool validarBoton(string usuario, string contrasena)
        {
            return !string.IsNullOrWhiteSpace(usuario) && !string.IsNullOrWhiteSpace (contrasena);

        }

        public void validarLogin()
        {
// ACA VA LA LOGICA DE VALIDAR EL USUARIO
        }

    }
}

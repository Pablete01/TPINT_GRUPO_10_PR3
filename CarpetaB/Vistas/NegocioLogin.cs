using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Entidades;
using Dao;


namespace Negocio
{
    public class NegocioLogin
    {
       private UsuarioDao dao = new UsuarioDao();

        public Usuario Login(string usuario, string contrasena)
        {
           var user = dao.ValidarUsuario(usuario, contrasena);
            return user;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Dao;
using Entidades;

namespace Negocio
{
    public class NegocioLogin
    {
        private UsuarioDao dao = new UsuarioDao();
        public Usuario Login(string email, string contrasena)
        {
           var user = dao.ValidarUsuario(email, contrasena);
            return user;

        }


    }
}

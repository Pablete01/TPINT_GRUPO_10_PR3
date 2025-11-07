using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace Vistas
{
    public partial class Login : System.Web.UI.Page
    {
        NegocioLogin validar = new NegocioLogin();
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void btnLogin_Click(object sender, EventArgs e)
        {
            ValidarLogin();
        }

        protected void ValidarLogin()
        {
            if (!validar.validarBoton(tbUsuario.Text, tbContrasena.Text))
            {
                lblError.Text = "Debe completar todos los campos.";
                return;
            }
            else
            {
                lblError.Text = string.Empty;
                validar.validarLogin();
            }


        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Entidades;
using System.Runtime.InteropServices;

namespace Vistas
{
    public partial class Login : System.Web.UI.Page
    {
        NegocioLogin negocio = new NegocioLogin();
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }


        protected void btnLogin_Click(object sender, EventArgs e)
        {
            
            if (string.IsNullOrWhiteSpace(tbUsuario.Text) || string.IsNullOrWhiteSpace(tbContrasena.Text))
            {
                lblError.Text = "Por favor, ingrese email y contraseña.";
                return;
            }

            var user = negocio.Login(tbUsuario.Text, tbContrasena.Text);

            if (user == null)
            {
                lblError.Text = "Usuario o contraseña incorrectos.";
                return;
            }

            if (!user.estado)
            {
                lblError.Text = "El usuario está inactivo. Comuníquese con el administrador.";
                return;
            }

           
            Session["Usuario"] = user;

            switch (user.nombrePerfil.ToLower())
            {
            
                case "administrador":
                    Response.Redirect("Administrador.aspx");
                    break;
                case "medico":
                    Response.Redirect("Medico.aspx");
                    break;
                //case "paciente":
                //    Response.Redirect("Paciente.aspx");
                //    break;
                default:
                    lblError.Text = "Perfil no reconocido.";
                    break;
            }
        }


    }
}
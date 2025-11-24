using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vistas
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
            Response.Cache.SetExpires(DateTime.MinValue);

            if (Session["Usuario"] == null)
            {
                Response.Redirect("Login.aspx");
                return;
            }
            lblUsuario.Text =  ((Entidades.Usuario)Session["Usuario"]).email;
        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }

        protected void btnGestionarMedicos_Click(object sender, ImageClickEventArgs e)
        {
           
            Response.Redirect("GestionMedico.aspx");
        }

        protected void btnAltaPaciente_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("GestionPacientes.aspx"); 
        }

        protected void btnTurnos_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("GestionTurnos.aspx");
        }

        protected void btnInformes_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Informes.aspx");
        }
    }
}
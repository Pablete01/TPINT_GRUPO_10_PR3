using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vistas
{
    public partial class SeleccionInforme : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblUsuario.Text = ((Entidades.Usuario)Session["Usuario"]).email;
        }

        protected void btnInformeTurnosAsistencia_Click(object sender, EventArgs e)
        {
            Response.Redirect("InformeAsistenciaTurnos.aspx");
        }

        protected void btnInformeMedicos_Click(object sender, EventArgs e)
        {
            Response.Redirect("SeleccionInforme.aspx");
        }

        protected void btnInformeTurnosGeneral_Click(object sender, EventArgs e)
        {
            Response.Redirect("InformeGeneralTurnos.aspx");
        }
    }
}
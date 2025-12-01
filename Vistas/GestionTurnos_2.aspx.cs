using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Negocio;

namespace Vistas
{
    public partial class GestionTurnos_2 : System.Web.UI.Page
    {
        NegocioPacientesGT neg = new NegocioPacientesGT();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblUsuario.Text = ((Entidades.Usuario)Session["Usuario"]).email;
                CargarGrillaPacientes();
            }
        }

        private void CargarGrillaPacientes()
        {
            grdTurnosPacientes.DataSource = neg.ObtenerPacientes();
            grdTurnosPacientes.DataBind();
        }

        protected void grdTurnosPacientes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Gestionar")
            {
                int idPaciente = Convert.ToInt32(e.CommandArgument); 
                Response.Redirect("GestionTurnoPaciente.aspx?ID=" + idPaciente);
            }
        }

        protected void btnInicio_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Administrador.aspx");
        }

        protected void grdTurnosPacientes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdTurnosPacientes.PageIndex = e.NewPageIndex;
            CargarGrillaPacientes(); 
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vistas
{
    public partial class PacientesAgendados : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblUsuario.Text = ((Entidades.Usuario)Session["Usuario"]).email;
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {

        }

        protected void ddlFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void grdPacientes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdPacientes.PageIndex = e.NewPageIndex;

        }

        protected void grdPacientes_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdPacientes.EditIndex = -1;   // cancela edición


        }

        protected void grdPacientes_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdPacientes.EditIndex = e.NewEditIndex; // habilita edición

        }

        protected void grdPacientes_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            // Aquí vas a poner la lógica para actualizar médicos,
            // por ahora solo cancelamos y recargamos para evitar errores
            grdPacientes.EditIndex = -1;

        }

        protected void grdPacientes_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void grdPacientes_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Entidades;
using System.Data;


namespace Vistas
{
    public partial class GestionMedico : System.Web.UI.Page
    {
        NegocioMedicos negocioMedicos = new NegocioMedicos();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)  
            {
               lblUsuario.Text = ((Entidades.Usuario)Session["Usuario"]).email;
               MostrarMedicos();
            }
        }

        private void MostrarMedicos()
        {
            DataTable dt = negocioMedicos.cargarGrillaMedicos();
            grdMedico.DataSource = dt;
            grdMedico.DataBind();
        }



        protected void btnAgregarMedico_Click(object sender, EventArgs e)
        {

        }

        protected void ddlFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void grdMedico_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdMedico.PageIndex = e.NewPageIndex;
            MostrarMedicos(); // vuelve a cargar la grilla
        }

        protected void grdMedico_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdMedico.EditIndex = -1;   // cancela edición
            MostrarMedicos();           // recarga datos

        }

        protected void grdMedico_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdMedico.EditIndex = e.NewEditIndex; // habilita edición
            MostrarMedicos();                     // recarga datos
        }

        protected void grdMedico_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            // Aquí vas a poner la lógica para actualizar médicos,
            // por ahora solo cancelamos y recargamos para evitar errores
            grdMedico.EditIndex = -1;
            MostrarMedicos();
        }

        protected void grdMedico_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {

        }
    }
}
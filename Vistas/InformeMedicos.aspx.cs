using Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vistas
{
    public partial class InformeMedicos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblUsuario.Text = ((Entidades.Usuario)Session["Usuario"]).email;
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            DateTime desde, hasta;
            LimpiarDatos();
            
            if (!DateTime.TryParse(txtDesde.Text, out desde) || !DateTime.TryParse(txtHasta.Text, out hasta))
            {
                lblMensajeError.Text = "Ingrese fechas válidas.";
                return;
            }

            if (desde > hasta)
            {
                lblMensajeError.Text = "La fecha inicial no puede ser mayor que final.";
                return;
            }

            CargarGv(desde, hasta);

        }

        private void CargarGv(DateTime desde, DateTime hasta)
        {
            NegocioMedicos negocioMedicos = new NegocioMedicos();
            DataTable dt = negocioMedicos.ObtenerInformeTrabajoMedicos(desde, hasta);

            if (dt.Rows.Count > 0)
            {
                GridViewPersonas.DataSource = dt;
                GridViewPersonas.DataBind();
                lblMensajeError.Text = "";
            }
            else
            {
                GridViewPersonas.DataSource = null;
                GridViewPersonas.DataBind();
                lblMensajeError.Text = "No se encontraron medicos con turnos en ese rango.";
            }
        }

        protected void GridViewPersonas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewPersonas.PageIndex = e.NewPageIndex;
            DateTime desde = DateTime.Parse(txtDesde.Text);
            DateTime hasta = DateTime.Parse(txtHasta.Text);
            CargarGv(desde, hasta);
        }

        private void LimpiarDatos()
        {
            lblMensajeError.Text = "";

            GridViewPersonas.DataSource = null;
            GridViewPersonas.DataBind();
        }
    }
}
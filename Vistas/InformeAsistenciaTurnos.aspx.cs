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
    public partial class InformeAsistenciaTurnos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblUsuario.Text = ((Entidades.Usuario)Session["Usuario"]).email;
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            DateTime desde, hasta;
            LimpiarDatosYOcultarControles();
            ddlControlFiltros.SelectedIndex = 0;

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
            NegocioEstadisticas negocioEstadisticas= new NegocioEstadisticas();

            int cantPresentes = negocioEstadisticas.ContabilizarTurnosPorEstado(desde, hasta, 4);
            int cantAusentes = negocioEstadisticas.ContabilizarTurnosPorEstado(desde, hasta, 5);

            int total = cantAusentes + cantPresentes;

            var cultura = new System.Globalization.CultureInfo("es-ES");

            string fechaDesdeFormateada = desde.ToString("dddd d 'de' MMMM 'del' yyyy", cultura);
            string fechaHastaFormateada = hasta.ToString("dddd d 'de' MMMM 'del' yyyy", cultura);

            lblInforme.Text = $"Desde el {fechaDesdeFormateada} hasta el {fechaHastaFormateada} se obtuvo el siguiente registro de turnos:<br/><br/>";
            lblInforme.Text += $"Presentes: <b>{calcularPorcentajeString(total, cantPresentes)}</b><br/>";
            lblInforme.Text += $"Ausentes: <b>{calcularPorcentajeString(total, cantAusentes)}</b><br/><br/>";

            MostrarControles();

            CargarGv(desde, hasta, 0);
        }

        public string calcularPorcentajeString(int total, int valor)
        {
            if (total == 0)
            {
                return valor + " (0%)";
            }
            float porcentaje = (float)valor / total * 100;
            return valor + " (" + porcentaje.ToString("0.00") + "%)";
        }

        private void LimpiarDatosYOcultarControles()
        {
            lblInforme.Text = "";
            lblDetalleDeTurnos.Text = "Detalle de Turnos";
            lblMensajeError.Text = "";

            GridViewPersonas.DataSource = null;
            GridViewPersonas.DataBind();

            GridViewPersonas.Visible = false;
            lblInforme.Visible = false;
            lblDetalleDeTurnos.Visible = false;

            Label2.Visible = false;
            ddlControlFiltros.Visible = false;
            btnControlDDL.Visible = false;
        }

        private void MostrarControles()
        {
            lblInforme.Visible = true;
            lblDetalleDeTurnos.Visible = true;

            Label2.Visible = true;
            ddlControlFiltros.Visible = true;
            btnControlDDL.Visible = true;

            GridViewPersonas.Visible = true;
        }

        private void CargarGv(DateTime desde, DateTime hasta, int estado)
        {
            NegocioEstadisticas negocioEstadisticas = new NegocioEstadisticas();

            DataTable dt;
            if (estado == 0)
                dt = negocioEstadisticas.ObtenerInformeTurnosPresentesAusentes(desde, hasta);
            else
                dt = negocioEstadisticas.ObtenerInformeTurnosPorEstado(desde, hasta, estado);

            if (dt.Rows.Count > 0)
            {
                GridViewPersonas.DataSource = dt;
                GridViewPersonas.DataBind();
                lblDetalleDeTurnos.Text = $"Detalle de Turnos ({dt.Rows.Count})";
                lblMensajeError.Text = "";
            }
            else
            {
                GridViewPersonas.DataSource = null;
                GridViewPersonas.DataBind();
                lblDetalleDeTurnos.Text = "Detalle de Turnos (0)";
                lblMensajeError.Text = "No se encontraron turnos en ese rango.";
            }
        }

        protected void GridViewPersonas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewPersonas.PageIndex = e.NewPageIndex;

            DateTime desde = DateTime.Parse(txtDesde.Text);
            DateTime hasta = DateTime.Parse(txtHasta.Text);

            int estado = int.Parse(ddlControlFiltros.SelectedValue);

            CargarGv(desde, hasta, estado);
        }

        protected void btnControlDDL_Click(object sender, EventArgs e)
        {
            DateTime desde = DateTime.Parse(txtDesde.Text);
            DateTime hasta = DateTime.Parse(txtHasta.Text);

            int estado = int.Parse(ddlControlFiltros.SelectedValue);

            CargarGv(desde, hasta, estado);
        }
    }
}
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
            NegocioTurnos negocioTurnos = new NegocioTurnos();

            int cantPresentes = negocioTurnos.ContabilizarTurnosPorEstado(desde, hasta, 4);
            int cantAusentes = negocioTurnos.ContabilizarTurnosPorEstado(desde, hasta, 5);

            int total = cantAusentes + cantPresentes;

            lblAusentes.Text += calcularPorcentajeString(total, cantAusentes);
            lblPresentes.Text += calcularPorcentajeString(total, cantPresentes);

            lblDetalleDeTurnos.Text += " (" + total + ")";

            CargarGv(desde, hasta);
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

        private void LimpiarDatos()
        {
            lblAusentes.Text = "Ausentes: ";
            lblPresentes.Text = "Presentes: ";
            lblDetalleDeTurnos.Text = "Detalle de Turnos";
            lblMensajeError.Text = "";

            GridViewPersonas.DataSource = null;
            GridViewPersonas.DataBind();
        }

        private void CargarGv(DateTime desde, DateTime hasta)
        {
            NegocioTurnos negocioTurnos = new NegocioTurnos();
            DataTable dt = negocioTurnos.ObtenerInformeTurnosPresentesAusentes(desde, hasta);

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
                lblMensajeError.Text = "No se encontraron turnos en ese rango.";
            }
        }

        protected void GridViewPersonas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewPersonas.PageIndex = e.NewPageIndex;
            DateTime desde = DateTime.Parse(txtDesde.Text);
            DateTime hasta = DateTime.Parse(txtHasta.Text);
            CargarGv(desde, hasta);
        }
    }
}
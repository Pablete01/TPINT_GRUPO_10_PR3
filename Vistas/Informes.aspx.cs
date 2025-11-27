using Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vistas
{
    public partial class Informes : System.Web.UI.Page
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
            int cantReservados = negocioTurnos.ContabilizarTurnosPorEstado(desde, hasta, 1);
            int cantCancelados = negocioTurnos.ContabilizarTurnosPorEstado(desde, hasta, 2);
            int cantReprogramados = negocioTurnos.ContabilizarTurnosPorEstado(desde, hasta, 3);
            int cantPresentes = negocioTurnos.ContabilizarTurnosPorEstado(desde, hasta, 4);
            int cantAusentes = negocioTurnos.ContabilizarTurnosPorEstado(desde, hasta, 5);

            int total = cantReservados + cantCancelados + cantReprogramados + cantAusentes + cantPresentes;

            lblAusentes.Text += calcularPorcentajeString(total, cantAusentes);
            lblPresentes.Text += calcularPorcentajeString(total, cantPresentes);
            lblReservados.Text += calcularPorcentajeString(total, cantReservados);
            lblReprogramados.Text += calcularPorcentajeString(total, cantReprogramados);
            lblCancelado.Text += calcularPorcentajeString(total, cantCancelados);

            lblDetalleDePacientes.Text += " (" + total + ")";

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
            lblReservados.Text = "Reservados: ";
            lblReprogramados.Text = "Reprogramados: ";
            lblCancelado.Text = "Cancelados: ";
            lblDetalleDePacientes.Text = "Detalle de Pacientes";
            lblMensajeError.Text = "";

            GridViewPersonas.DataSource = null;
            GridViewPersonas.DataBind();
        }

        protected void GridViewPersonas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewPersonas.PageIndex = e.NewPageIndex;
            DateTime desde = DateTime.Parse(txtDesde.Text);
            DateTime hasta = DateTime.Parse(txtHasta.Text);
            CargarGv(desde, hasta);
        }

        private void CargarGv(DateTime desde, DateTime hasta) 
        {
            NegocioTurnos negocioTurnos = new NegocioTurnos();
            DataTable dt = negocioTurnos.ObtenerInformeTurnos(desde, hasta);

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
    }
}
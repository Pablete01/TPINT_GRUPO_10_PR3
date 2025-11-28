using Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vistas
{
    public partial class InformeMedicos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblUsuario.Text = ((Entidades.Usuario)Session["Usuario"]).email;
            if (!IsPostBack)
            { 
            CargarEspecialidades();
            }
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            int idEsp = int.Parse(ddlEspecialidad.SelectedValue);
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
            if (idEsp == 0)
            {
                lblMensajeError.Text += "Por favor seleccione una especialidad.";
                return;
            }


            NegocioEstadisticas neg = new NegocioEstadisticas();

            CargarGv(desde, hasta);
            DataTable dtCantTurnosEspecialidad = neg.ObtenerCantidadTurnosPorEspecialidad(idEsp, desde, hasta);
            DataTable dtMasHoras = neg.EspecialidadMasHoras();
            DataTable dtMasJornadas = neg.EspecialidadMasJornadas();

            lblInforme.Text = "";
            lblInforme.Text = "Desde el " + txtDesde.Text + " hasta el " + txtHasta.Text + " obtenemos la siguiente informacion <br/><br/>";

            if (dtCantTurnosEspecialidad.Rows.Count > 0) 
            {
                lblInforme.Text += $"La especialidad <b>{dtCantTurnosEspecialidad.Rows[0]["Especialidad"]}</b> cuenta con {dtCantTurnosEspecialidad.Rows[0]["CantidadTurnos"]} turnos asignados.<br/><br/>";
            }
            lblInforme.Text += "Dando un vistazo a la <b>informacion general</b> tenemos los siguientes datos. <br/><br/>";
            if (dtMasJornadas.Rows.Count > 0)
            { 
                lblInforme.Text += $"La especialidad con más jornadas es <b>{dtMasJornadas.Rows[0]["NombreEspecialidad"]}</b> con {dtMasJornadas.Rows[0]["CantidadJornadas"]} jornadas.<br/><br/>";
            }
            if (dtMasHoras.Rows.Count > 0)
            { 
            lblInforme.Text += $"La especialidad con más horas trabajadas es <b>{dtMasHoras.Rows[0]["NombreEspecialidad"]}</b> con {Convert.ToDecimal(dtMasHoras.Rows[0]["HorasTotales"]).ToString("0")} horas.<br/><br/>";
            }

            LimpiarControles();
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
        private void CargarEspecialidades()
        {
            NegocioMedicos negocioMedicos = new NegocioMedicos();
            DataTable dtEspecialidades = negocioMedicos.GetEspecialidades();
            ddlEspecialidad.DataSource = dtEspecialidades;
            ddlEspecialidad.DataTextField = "NombreEspecialidad";
            ddlEspecialidad.DataValueField = "ID_Especialidad";
            ddlEspecialidad.DataBind();
            ddlEspecialidad.Items.Insert(0, new ListItem("-- Seleccione una especialidad --", "0"));
        }

        private void LimpiarControles()
        {
            txtDesde.Text = "";
            txtHasta.Text = "";

            ddlEspecialidad.SelectedIndex = 0;

            lblMensajeError.Text = "";
        }
    }
}
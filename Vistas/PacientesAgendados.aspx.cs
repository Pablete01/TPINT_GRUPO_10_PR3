using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Negocio;

namespace Vistas
{
    public partial class PacientesAgendados : System.Web.UI.Page
    {
        NegocioTurnoPaciente neg = new NegocioTurnoPaciente();
        NegocioMedicos negMed = new NegocioMedicos();

        protected void Page_Load(object sender, EventArgs e)

        {
            if (!IsPostBack)
            {
                MedicoAdm medicoAdm = negMed.ObtenerMedicoPorIDUsuario(((Usuario)Session["Usuario"]).idUsuario);
                string nombreMedico = medicoAdm.Nombre + " " + medicoAdm.Apellido;
                lblUsuario.Text = ((Entidades.Usuario)Session["Usuario"]).email;
                lblNombreMedico.Text = "Pacientes agendados de " + nombreMedico;
                CargarGrillaTurnos();
            }
        }

        private void CargarGrillaTurnos()
        {
            MedicoAdm medicoAdm = negMed.ObtenerMedicoPorIDUsuario(((Usuario)Session["Usuario"]).idUsuario);
            int idMedico = medicoAdm.ID_Medico;

            DataTable dt = neg.ObtenerTurnosxMedico(idMedico);
            gvTurnos.DataSource = dt;
            gvTurnos.DataBind();
            if (dt.Rows.Count == 0)
            {
                lblMensaje.Text = "No hay turnos agendados para este médico.";
                gvTurnos.Visible = false;
            }
            else
            {
                lblMensaje.Text = string.Empty;
                gvTurnos.Visible = true;
            }
        }

        public string ObtenerEstado(object estado)
        {
            switch (estado.ToString())
            {
                case "4": return "Presente";
                case "5": return "Ausente";
                default: return "Agendado";
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBuscar.Text))
            {
                txtDesde.Text = "";
                txtHasta.Text = "";
                CargarGrillaTurnos();
                return;
            }
            DataTable dt = neg.BuscarPacientesxTurno(txtBuscar.Text.Trim());
            gvTurnos.DataSource = dt;
            gvTurnos.DataBind();
            txtDesde.Text = "";
            txtHasta.Text = "";
            if (dt.Rows.Count == 0)
            {
                lblMensaje.Text = "No se encontraron pacientes con ese criterio.";
                gvTurnos.Visible = false;
            }
            else
            {
                lblMensaje.Text = string.Empty;
                gvTurnos.Visible = true;
            }
        }

        protected void ddlEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            gvTurnos.EditIndex = ((GridViewRow)((Control)sender).NamingContainer).RowIndex;

            CargarGrillaTurnos(); 
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void grdPacientes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvTurnos.PageIndex = e.NewPageIndex;

        }

        protected void grdPacientes_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvTurnos.EditIndex = -1;  
            txtDesde.Text = "";
            txtHasta.Text = "";
            CargarGrillaTurnos();


        }

        protected void grdPacientes_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvTurnos.EditIndex = e.NewEditIndex; 
            CargarGrillaTurnos();

        }

        protected void grdPacientes_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = gvTurnos.Rows[e.RowIndex];

            DropDownList ddlEstado = (DropDownList)row.FindControl("ddlEstado");
            TextBox txtObs = (TextBox)row.FindControl("txtObservaciones");

            int idTurno = Convert.ToInt32(gvTurnos.DataKeys[e.RowIndex].Value);
            int idEstado = int.Parse(ddlEstado.SelectedValue);
            string observaciones = txtObs.Text;

            bool estadoActualizado = neg.ActualizarEstadoPaciente(idTurno, idEstado, observaciones);
            string mensaje = string.Empty;

            if (estadoActualizado)
            {
                mensaje = "El turno se actualizó correctamente.";

            }
            else
            {
                mensaje = "No se pudo actualizar el turno.";

            }

            gvTurnos.EditIndex = -1;
            CargarGrillaTurnos(); 
            lblMensaje.Text = mensaje;

        }

        protected void grdPacientes_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow &&
        (e.Row.RowState & DataControlRowState.Edit) > 0)
            {
                string estado = DataBinder.Eval(e.Row.DataItem, "ID_Estado").ToString();
                DropDownList ddl = (DropDownList)e.Row.FindControl("ddlEstado");
                if (ddl != null)
                {
                    ddl.SelectedValue = estado;
                }
            }
        }

        protected void grdPacientes_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {

        }

        private void CargarGrillaTurnosFecha(DateTime desde, DateTime hasta)
        {
            MedicoAdm medicoAdm = negMed.ObtenerMedicoPorIDUsuario(((Usuario)Session["Usuario"]).idUsuario);
            int idMedico = medicoAdm.ID_Medico;

            DataTable dt = neg.ObtenerTurnosxMedico_Fecha(idMedico, desde, hasta);

            gvTurnos.DataSource = dt;
            gvTurnos.DataBind();

            lblMensaje.Text = dt.Rows.Count == 0 ? "No hay turnos en ese rango de fechas." : "";
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDesde.Text) || string.IsNullOrEmpty(txtHasta.Text))
            {
                lblMensaje.Text = "Debe ingresar ambas fechas para filtrar.";
                return;
            }

            DateTime desde = DateTime.Parse(txtDesde.Text);
            DateTime hasta = DateTime.Parse(txtHasta.Text);

            if (desde > hasta)
            {
                lblMensaje.Text = "La fecha 'Desde' no puede ser mayor que 'Hasta'.";
                return;
            }

            CargarGrillaTurnosFecha(desde, hasta);
        }

        protected void btnQuitarFiltro_Click(object sender, EventArgs e)
        {
            txtDesde.Text = "";
            txtHasta.Text = "";
            CargarGrillaTurnos();
        }
    }
}
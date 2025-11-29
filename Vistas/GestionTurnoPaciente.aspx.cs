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
    public partial class GestionTurnoPaciente : System.Web.UI.Page
    {
        public static List<int> diasJornada = new List<int>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblUsuario.Text = ((Entidades.Usuario)Session["Usuario"]).email;
                if (Request.QueryString["ID"] != null)
                {
                    int idPaciente = Convert.ToInt32(Request.QueryString["ID"]);
                    CargarTurnos(idPaciente);
                    CargarEspecialidades();
                }
                else
                {
                    // Si no llega el ID, volver a pantalla anterior
                    Response.Redirect("GestionTurnos_2.aspx");
                }
            }
        }




        private void CargarTurnos(int idPaciente)
        {
            NegocioTurnoPaciente neg = new NegocioTurnoPaciente();
            grdTurnosPaciente.DataSource = neg.ObtenerTurnosPaciente(idPaciente);
            grdTurnosPaciente.DataBind();
        }

        private void CargarEspecialidades()
        {
            NegocioTurnoPaciente neg = new NegocioTurnoPaciente();

            ddlEspecialidad.DataSource = neg.ObtenerEspecialidades();
            ddlEspecialidad.DataTextField = "NombreEspecialidad";
            ddlEspecialidad.DataValueField = "ID_Especialidad";
            ddlEspecialidad.DataBind();

            ddlEspecialidad.Items.Insert(0, new ListItem("-- Seleccione Especialidad --", "0"));
        }


        protected void grdTurnosPaciente_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Cancelar")
            {
                int idTurno = Convert.ToInt32(e.CommandArgument);

                NegocioTurnoPaciente neg = new NegocioTurnoPaciente();
                string r = neg.CancelarTurnoPaciente(idTurno);

                if (r == "OK")
                {
                    lblMensaje.Text = "Turno cancelado correctamente.";
                    CargarTurnos(Convert.ToInt32(Request.QueryString["ID"]));
                }
                else
                {
                    lblMensaje.Text = r;
                }
            }
        }

        protected void btnInicio_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("GestionTurnos_2.aspx");
        }

        protected void btnAgregarTurno_Click(object sender, EventArgs e)
        {
            panelTurno.Visible = true;
        }

        protected void btnCancelarTurno_Click(object sender, EventArgs e)
        {
            panelTurno.Visible = false;
        }


        private void CargarMedicos(int idEspecialidad)
        {
            NegocioTurnoPaciente neg = new NegocioTurnoPaciente();

            ddlMedico.DataSource = neg.ObtenerMedicosPorEspecialidad(idEspecialidad);
            ddlMedico.DataTextField = "NombreCompleto";
            ddlMedico.DataValueField = "ID_Medico";
            ddlMedico.DataBind();

            ddlMedico.Items.Insert(0, new ListItem("-- Seleccione Médico --", "0"));
        }


        protected void ddlEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idEspecialidad = Convert.ToInt32(ddlEspecialidad.SelectedValue);

            if (idEspecialidad > 0)
            {
                CargarMedicos(idEspecialidad);
            }
            else
            {
                ddlMedico.Items.Clear();
                ddlMedico.Items.Insert(0, new ListItem("-- Seleccione Médico --", "0"));
            }
        }

        protected void ddlMedico_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idMedico = Convert.ToInt32(ddlMedico.SelectedValue);

            if (idMedico > 0)
            {
                NegocioTurnoPaciente neg = new NegocioTurnoPaciente();
                diasJornada = neg.ObtenerDiasJornada(idMedico);

                // reseteamos calendario
                calTurno.VisibleDate = DateTime.Today;
                calTurno.SelectedDates.Clear();
            }
        }

        protected void calTurno_DayRender(object sender, DayRenderEventArgs e)
        {
            DateTime hoy = DateTime.Today;

            // ✖ bloquear fechas pasadas
            if (e.Day.Date < hoy)
            {
                e.Day.IsSelectable = false;
                e.Cell.ForeColor = System.Drawing.Color.LightGray;
                return;
            }

            // día semana: 1 lunes → 7 domingo
            int diaSemana = (int)e.Day.Date.DayOfWeek;
            if (diaSemana == 0) diaSemana = 7;

            // ✖ no está en jornada
            if (!diasJornada.Contains(diaSemana))
            {
                e.Day.IsSelectable = false;
                e.Cell.ForeColor = System.Drawing.Color.LightGray;
                return;
            }

            // ✔ día válido
            e.Cell.BackColor = System.Drawing.Color.LightGreen;
        }

        protected void calTurno_SelectionChanged(object sender, EventArgs e)
        {
            DateTime fecha = calTurno.SelectedDate;
            int idMedico = int.Parse(ddlMedico.SelectedValue);
            int idPaciente = Convert.ToInt32(Request.QueryString["ID"]);

            NegocioTurnoPaciente neg = new NegocioTurnoPaciente();

            ddlHorario.DataSource = neg.ObtenerHorariosDisponibles(idMedico, fecha, idPaciente);
            ddlHorario.DataTextField = "HorarioTexto";
            ddlHorario.DataValueField = "Hora";
            ddlHorario.DataBind();
        }

        protected void btnGuardarTurno_Click(object sender, EventArgs e)
        {
            if (ddlMedico.SelectedIndex == 0 || ddlEspecialidad.SelectedIndex == 0 ||
    calTurno.SelectedDate == DateTime.MinValue || ddlHorario.SelectedIndex == -1)
            {
                lblMensaje.Text = "Debe seleccionar todos los campos.";
                return;
            }

            TurnoInsert t = new TurnoInsert();
            t.ID_Paciente = Convert.ToInt32(Request.QueryString["ID"]);
            t.ID_Medico = int.Parse(ddlMedico.SelectedValue);
            t.Fecha = calTurno.SelectedDate;
            t.Hora = TimeSpan.Parse(ddlHorario.SelectedValue);

            NegocioTurnoPaciente neg = new NegocioTurnoPaciente();
            string r = neg.InsertarTurnoPaciente(t);

            if (r == "OK")
            {
                lblMensaje.Text = "Turno asignado correctamente.";
                CargarTurnos(t.ID_Paciente);
                panelTurno.Visible = false;
            }
            else
            {
                lblMensaje.Text = r;
            }
        }
    }
}
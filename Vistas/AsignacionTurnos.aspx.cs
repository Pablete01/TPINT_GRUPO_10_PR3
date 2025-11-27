using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Negocio;

namespace Vistas
{ //saludos
    public partial class AsignacionTurnos : System.Web.UI.Page
    {
        NegocioTurnos negocioTurnos = new NegocioTurnos();
        NegocioMedicos negocioMedicos = new NegocioMedicos();
        protected void Page_Init(object sender, EventArgs e)
        {
            // Reconstruir tabla en cada postback si hay datos guardados
            if (ViewState["FechaSeleccionada"] != null && ViewState["HorasOcupadas"] != null)
            {
                DateTime fecha = (DateTime)ViewState["FechaSeleccionada"];
                List<string> horasOcupadas = (List<string>)ViewState["HorasOcupadas"];
                GenerarTablaHorarios(fecha);
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblUsuario.Text = ((Entidades.Usuario)Session["Usuario"]).email;
                txtFecha.Attributes["min"] = DateTime.Today.ToString("yyyy-MM-dd");
                txtFecha.Text = DateTime.Now.ToString("yyyy-MM-dd");
                CargarEspecialidades();
            }
            else
            {
                // ⚡ Reconstruir tabla antes de que se ejecute cualquier evento
                if (ViewState["FechaSeleccionada"] != null && ViewState["HorasOcupadas"] != null)
                {
                    DateTime fecha = (DateTime)ViewState["FechaSeleccionada"];
                    List<string> horasOcupadas = (List<string>)ViewState["HorasOcupadas"];
                    GenerarTablaHorarios(fecha);
                }
            }
        }

        protected void btnCargarHorarios_Click(object sender, EventArgs e)
        {
            if(ddlEspecialidad.SelectedValue == "0" || ddlMedico.SelectedValue == "0")
            {
                lblFecha.Text = string.Empty;
                lblSeleccion.Text = "Por favor, seleccione una especialidad y un médico.";
                return;
            }
            DateTime fechaSeleccionada;
            if (DateTime.TryParse(txtFecha.Text, out fechaSeleccionada))
            {
                lblSeleccion.Text = "Fecha seleccionada: " + fechaSeleccionada.ToString("dd/MM/yyyy");

                List<string> horasOcupadas;
                if (fechaSeleccionada.Day % 2 == 0)
                    horasOcupadas = new List<string> { "09:00", "11:00", "14:00" };
                else
                    horasOcupadas = new List<string> { "10:00", "12:00", "15:00" };

                ViewState["FechaSeleccionada"] = fechaSeleccionada;
                ViewState["HorasOcupadas"] = horasOcupadas;

                GenerarTablaHorarios(fechaSeleccionada);
            }
        }

        private void GenerarTablaHorarios(DateTime fecha)
        {
            tblHorarios.Rows.Clear();

            // Obtener turnos ocupados desde la base ACA FALTA AGREGAR EL ID DEL MEDICO
            int idMedico = int.Parse(ddlMedico.SelectedValue);
            DataTable dt = negocioTurnos.ObtenerTurnosMedicoFecha(idMedico, fecha);

            DataTable jm = negocioTurnos.ObtenerHorarioMedico(idMedico);

            int diaSemana = (int)fecha.DayOfWeek; // 0=Domingo, 1=Lunes, ..., 6=Sábado

            DataRow[] filasDia = jm.Select("DiaSemana = " + diaSemana);
            if (filasDia.Length == 0)
            {
                // No hay horario para este día
                lblSeleccion.Text += " - El médico no trabaja este día.";
                return;
            }

            DataRow fila = filasDia[0];


            TimeSpan horaInicio = (TimeSpan)fila[1];
            TimeSpan horaFin = (TimeSpan)fila[2];

            // Convertir horas ocupadas a TimeSpan para comparar correctamente
            List<TimeSpan> horasOcupadas = dt.AsEnumerable()
                .Select(r => TimeSpan.Parse(r["Hora"].ToString()))
                .ToList();

            // Lista de todas las horas que querés mostrar
            List<TimeSpan> todasHoras = new List<TimeSpan>();
            for (TimeSpan h = horaInicio; h <= horaFin; h = h.Add(TimeSpan.FromHours(1))) // sumar 1 hora
            {
                todasHoras.Add(h);
            }
            // Recorrer las horas de 2 en 2 para hacer 2 columnas
            for (int i = 0; i < todasHoras.Count; i += 2)
            {
                TableRow row = new TableRow();

                // Primer botón
                TableCell cell1 = new TableCell();
                Button btn1 = new Button();
                btn1.Text = todasHoras[i].ToString(@"hh\:mm");
                btn1.CommandArgument = btn1.Text;
                btn1.CausesValidation = false;

                if (horasOcupadas.Contains(todasHoras[i]))
                    btn1.Enabled = false;
                else
                {
                    btn1.Enabled = true;
                    btn1.Click += BtnHora_Click;
                }

                cell1.Controls.Add(btn1);
                row.Cells.Add(cell1);

                // Segundo botón (si existe)
                if (i + 1 < todasHoras.Count)
                {
                    TableCell cell2 = new TableCell();
                    Button btn2 = new Button();
                    btn2.Text = todasHoras[i + 1].ToString(@"hh\:mm");
                    btn2.CommandArgument = btn2.Text;
                    btn2.CausesValidation = false;

                    if (horasOcupadas.Contains(todasHoras[i + 1]))
                        btn2.Enabled = false;
                    else
                    {
                        btn2.Enabled = true;
                        btn2.Click += BtnHora_Click;
                    }

                    cell2.Controls.Add(btn2);
                    row.Cells.Add(cell2);
                }

                tblHorarios.Rows.Add(row);
            }
        }



        protected void BtnHora_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string horaSeleccionada = btn.CommandArgument;

            // Mostrar hora seleccionada
            lblHoraSeleccionada.Text = "Hora seleccionada: " + horaSeleccionada;
            txtHoraSeleccionada.Text = horaSeleccionada;

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("AsignacionTurnos.aspx");
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            NegocioPacientes pacientes = new NegocioPacientes();
            int idPaciente = pacientes.GetIDPacientePorDNI(txtDNIPaciente.Text);

            if (idPaciente == -1)
            {
                lblMensajes.Text = "El paciente no existe";
                return;
            }
            else
            {
                Turno t = new Turno();
                t.idPaciente = idPaciente;
                t.idProfesional = int.Parse(ddlMedico.SelectedValue);
                t.fechaTurno = DateTime.Parse(txtFecha.Text);
                t.horaTurno = TimeSpan.Parse(txtHoraSeleccionada.Text);
                t.estado = 1;
                t.observaciones = "";

                int verificar = negocioTurnos.AgregarTurno(t);
                if (verificar > 0)
                {
                    lblMensajes.Text = "Turno registrado correctamente.";
                    LimpiarControlores();
                }
                else
                {
                    lblMensajes.Text = "Error al registrar el turno";
                }
            }
        }

        private void CargarMedicos(int idEspecialidad)
        {

            DataTable dtMedicos = negocioMedicos.ObtenerMedicoPorEspecialidad(idEspecialidad);
            dtMedicos.Columns.Add("NombreApellido", typeof(string), "Nombre + ' ' + Apellido");
            ddlMedico.DataSource = dtMedicos;
            ddlMedico.DataTextField = "NombreApellido";
            ddlMedico.DataValueField = "ID_Medico";
            ddlMedico.DataBind();
            ddlMedico.Items.Insert(0, new ListItem("-- Seleccione un médico --", "0"));
        }

        private void CargarEspecialidades()
        {
            DataTable dtEspecialidades = negocioMedicos.GetEspecialidades();
            ddlEspecialidad.DataSource = dtEspecialidades;
            ddlEspecialidad.DataTextField = "NombreEspecialidad";
            ddlEspecialidad.DataValueField = "ID_Especialidad";
            ddlEspecialidad.DataBind();
            ddlEspecialidad.Items.Insert(0, new ListItem("-- Seleccione una especialidad --", "0"));
        }

        protected void ddlMedico_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idEspecialidad = int.Parse(ddlEspecialidad.SelectedValue);
            CargarMedicos(idEspecialidad);
        }

        private void LimpiarControlores()
        {
            ddlEspecialidad.SelectedIndex = 0;
            ddlMedico.Items.Clear();
            ddlMedico.Items.Insert(0, new ListItem("- Seleccionar -", "0"));
            
            txtDNIPaciente.Text = "";
            txtFecha.Text = DateTime.Now.ToString("yyyy-MM-dd");

            lblSeleccion.Text = "";
            lblHoraSeleccionada.Text = "";

            txtHoraSeleccionada.Text = "";
            tblHorarios.Rows.Clear();

            ViewState["FechaSeleccionada"] = null;
            ViewState["HorasOcupadas"] = null;
        }

    }
}
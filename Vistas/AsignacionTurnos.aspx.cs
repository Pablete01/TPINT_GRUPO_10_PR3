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

            // Convertir "12:00:00" -> "12:00"
            List<string> horasOcupadas = dt.AsEnumerable()
                .Select(r => DateTime.Parse(r["Hora"].ToString()).ToString("HH:mm"))
                .ToList();

            // Lista de todas las horas que querés mostrar
            List<string> todasHoras = new List<string>();
            for (int h = 8; h <= 17; h++)
                todasHoras.Add($"{h:00}:00");

            // Recorrer las horas de 2 en 2 para hacer 2 columnas
            for (int i = 0; i < todasHoras.Count; i += 2)
            {
                TableRow row = new TableRow();

                // Primer botón
                TableCell cell1 = new TableCell();
                Button btn1 = new Button();
                btn1.Text = todasHoras[i];
                btn1.CommandArgument = todasHoras[i];
                btn1.CausesValidation = false;

                if (horasOcupadas.Contains(todasHoras[i]))
                {
                    btn1.Enabled = false;
                }
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
                    btn2.Text = todasHoras[i + 1];
                    btn2.CommandArgument = todasHoras[i + 1];
                    btn2.CausesValidation = false;

                    if (horasOcupadas.Contains(todasHoras[i + 1]))
                    {
                        btn2.Enabled = false;
                    }
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
            Turno t = new Turno();
            t.idPaciente = idPaciente;
            t.idProfesional = int.Parse(ddlMedico.SelectedValue);
            t.fechaTurno = DateTime.Parse(txtFecha.Text);
            t.horaTurno = TimeSpan.Parse(txtHoraSeleccionada.Text);
            t.estado = 1;
            t.observaciones = "";

            int verificar = negocioTurnos.AgregarTurno(t);

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
    }
}
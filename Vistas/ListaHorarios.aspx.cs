using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace Vistas
{
    public partial class ListaHorarios : System.Web.UI.Page
    {
        NegocioTurnos negocioTurnos = new NegocioTurnos();
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
                txtFecha.Text = DateTime.Now.ToString("yyyy-MM-dd");
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

            // Obtener turnos ocupados desde la base
            DataTable dt = negocioTurnos.ObtenerTurnosMedicoFecha(1, fecha);

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

           
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("AsignacionTurnos.aspx");
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {

        }
    }
}

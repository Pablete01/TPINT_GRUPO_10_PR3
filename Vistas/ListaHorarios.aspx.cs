using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vistas
{
    public partial class ListaHorarios : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            // Reconstruir tabla en cada postback si hay datos guardados
            if (ViewState["FechaSeleccionada"] != null && ViewState["HorasOcupadas"] != null)
            {
                DateTime fecha = (DateTime)ViewState["FechaSeleccionada"];
                List<string> horasOcupadas = (List<string>)ViewState["HorasOcupadas"];
                GenerarTablaHorarios(fecha, horasOcupadas);
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
                    GenerarTablaHorarios(fecha, horasOcupadas);
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

                GenerarTablaHorarios(fechaSeleccionada, horasOcupadas);
            }
        }

        private void GenerarTablaHorarios(DateTime fecha, List<string> horasOcupadas)
        {
            tblHorarios.Rows.Clear();

            for (int h = 8; h <= 17; h++)
            {
                TableRow row = new TableRow();
                TableCell cell = new TableCell();
                string hora = h.ToString("D2") + ":00";

                Button btnHora = new Button
                {
                    Text = hora,
                    CommandArgument = hora
                };

                if (horasOcupadas.Contains(hora))
                {
                    btnHora.Enabled = false;
                    btnHora.CssClass = "ocupado";
                }
                else
                {
                    btnHora.CssClass = "disponible";
                    btnHora.Click += BtnHora_Click;
                }

                cell.Controls.Add(btnHora);
                row.Cells.Add(cell);
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
    }
}

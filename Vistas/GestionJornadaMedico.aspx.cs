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
    public partial class GestionJornadaMedico : System.Web.UI.Page
    {
        NegocioJornadas negocio = new NegocioJornadas();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) // SOLO PRIMERA VEZ
            {
                if (Request.QueryString["ID_Medico"] != null)
                {
                    int idMedico = Convert.ToInt32(Request.QueryString["ID_Medico"]);
                    CargarJornadas(idMedico);
                }
            }
        }

        private void CargarJornadas(int idMedico)
        {
            grdJornadaMedico.DataSource = negocio.ObtenerJornadasMedico(idMedico);
            grdJornadaMedico.DataBind();
        }

        protected void btnInicio_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("GestionMedico.aspx");
        }

        protected void btnAceptarNuevaJornada_Click(object sender, EventArgs e)
        {
            int idMedico = Convert.ToInt32(Request.QueryString["ID_Medico"]);
            int diaSemana = Convert.ToInt32(ddlDiaSemana.SelectedValue);
            string horaEntrada = txtEntrada.Text;
            string horaSalida = txtSalida.Text;
            int duracion = Convert.ToInt32(txtDuracion.Text);

            bool ok = negocio.AgregarJornada(idMedico, diaSemana, horaEntrada, horaSalida, duracion);

            if (ok)
            {
                lblMsg.Text = "Jornada agregada correctamente.";
                lblMsg.ForeColor = System.Drawing.Color.Green;

                PanelAgregar.Visible = false;
                CargarJornadas(idMedico);
            }
            else
            {
                lblMsg.Text = "No se pudo agregar la jornada (superposición o error).";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnCancelarNuevaJornada_Click(object sender, EventArgs e)
        {
            PanelAgregar.Visible = false;
        }

        protected void btnAgregarJornada_Click(object sender, EventArgs e)
        {
            PanelAgregar.Visible = true;   // Mostrar formulario
        }


    }
    
}
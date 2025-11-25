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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int idPaciente = Convert.ToInt32(Session["ID_Pacientes"]);
                CargarTurnos(idPaciente);
            }
        }


        private void CargarTurnos(int idPaciente)
        {
            NegocioTurnoPaciente neg = new NegocioTurnoPaciente();
            grdTurnosPaciente.DataSource = neg.ObtenerTurnosPaciente(idPaciente);
            grdTurnosPaciente.DataBind();
        }

        protected void grdTurnosPaciente_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            // Convertimos directamente el CommandArgument a int
            int idTurno = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "Cancelar")
            {
                // Lógica para cancelar turno
                Response.Redirect("CancelarTurno.aspx?ID=" + idTurno);
            }

            if (e.CommandName == "Reprogramar")
            {
                // Lógica para reprogramar turno
                Response.Redirect("ReprogramarTurno.aspx?ID=" + idTurno);
            }
        }

        protected void btnInicio_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("GestionTurnos_2.aspx");
        }

        protected void btnAgregarTurno_Click(object sender, EventArgs e)
        {

        }


    }
}
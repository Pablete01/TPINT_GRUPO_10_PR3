using Entidades;
using Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vistas
{
    public partial class GestionJornadaMedico : System.Web.UI.Page
    {
        NegocioJornadas negocio = new NegocioJornadas();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {
                if (Request.QueryString["ID_Medico"] != null)
                {
                    lblUsuario.Text = ((Entidades.Usuario)Session["Usuario"]).email;
                    int idMedico = Convert.ToInt32(Request.QueryString["ID_Medico"]);
                    CargarJornadas(idMedico);

                   
                    NegocioMedicos neg = new NegocioMedicos();
                    Entidades.MedicoAdm medico = neg.ObtenerMedicoPorID(idMedico);

                    if (medico != null)
                    {
                       
                        lblNombre.Text = medico.Nombre;
                        lblApellido.Text = medico.Apellido;
                      
                    }
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
            JornadaMedico j = new JornadaMedico();

            j.ID_Medico = Convert.ToInt32(Request.QueryString["ID_Medico"]);
            j.DiaSemana = Convert.ToInt32(ddlDiaSemana.SelectedValue);
            j.HoraEntrada = TimeSpan.Parse(txtEntrada.Text);
            j.HoraSalida = TimeSpan.Parse(txtSalida.Text);
            j.Duracion = Convert.ToInt32(txtDuracion.Text);

            bool ok = negocio.AgregarJornada(j);

            if (ok)
            {
                lblMsg.Text = "Jornada agregada correctamente.";
                lblMsg.ForeColor = System.Drawing.Color.Green;

                PanelAgregar.Visible = false;
                CargarJornadas(j.ID_Medico);
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
            PanelAgregar.Visible = true;  
        }

        protected void grdJornadaMedico_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Eliminar")
            {
                int idJornada = Convert.ToInt32(e.CommandArgument);

                bool ok = negocio.EliminarJornada(idJornada);

                if (ok)
                {
                    lblMsg.Text = "Jornada eliminada correctamente.";
                    lblMsg.ForeColor = System.Drawing.Color.Green;

                    int idMedico = Convert.ToInt32(Request.QueryString["ID_Medico"]);
                    CargarJornadas(idMedico); 
                }
                else
                {
                    lblMsg.Text = "Error al eliminar la jornada.";
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                }
            }
        }

        protected string GetNombreDia(int dia)
        {
            switch (dia)
            {
                case 1: return "Lunes";
                case 2: return "Martes";
                case 3: return "Miércoles";
                case 4: return "Jueves";
                case 5: return "Viernes";
                case 6: return "Sábado";
                case 7: return "Domingo";
            }
            return "";
        }

    }

}
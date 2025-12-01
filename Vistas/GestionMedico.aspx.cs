using Entidades;
using Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Vistas
{
    public partial class GestionMedico : System.Web.UI.Page
    {
        NegocioMedicos negocioMedicos = new NegocioMedicos();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblUsuario.Text = ((Entidades.Usuario)Session["Usuario"]).email;
                MostrarMedicos(OrdenActual());
            }
        }

        private void MostrarMedicos(string orden = "predeterminado")
        {
            DataTable dt = negocioMedicos.ObtenerMedicosOrdenados(orden);
            grdMedico.DataSource = dt;
            grdMedico.DataBind();
        }

        private string OrdenActual()
        {
            return ddlFiltro.SelectedValue;
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void grdMedico_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdMedico.PageIndex = e.NewPageIndex;
            MostrarMedicos(OrdenActual()); 
        }

        protected void grdMedico_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdMedico.EditIndex = -1;   
            MostrarMedicos(OrdenActual());          

        }

        protected void grdMedico_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdMedico.EditIndex = e.NewEditIndex;
            MostrarMedicos(OrdenActual());                    
        }

        protected void grdMedico_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            grdMedico.EditIndex = -1;
            MostrarMedicos(OrdenActual());
        }

        protected void grdMedico_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string txt = txtBuscar.Text.Trim();
            DataTable dt = negocioMedicos.BuscarMedicos(txt);

            if (dt.Rows.Count > 0)
            {
                string orden = OrdenActual();

                switch (orden)
                {
                    case "nombre":
                        dt.DefaultView.Sort = "Nombre ASC";
                        break;
                    case "apellido":
                        dt.DefaultView.Sort = "Apellido ASC";
                        break;
                    case "especialidad":
                        dt.DefaultView.Sort = "NombreEspecialidad ASC";
                        break;
                    default:
                        dt.DefaultView.Sort = "ID_Medico ASC";
                        break;
                }
                dt = dt.DefaultView.ToTable();
            }
            grdMedico.DataSource = dt;
            grdMedico.DataBind();

        }

        protected void btnAgregarMedico_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormularioAddMedico.aspx");
        }

        protected void btnInicio_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Administrador.aspx");
        }

        protected void grdMedico_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Modificar")
            {
                string id = e.CommandArgument.ToString();
                Response.Redirect("FormularioAddMedico.aspx?ID_Medico=" + id);
            }

            if (e.CommandName == "Eliminar")
            {
                int id = Convert.ToInt32(e.CommandArgument);

                NegocioMedicos neg = new NegocioMedicos();

                bool resultado = neg.BajaLogicaMedico(id);

                if (resultado)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(),
                        "ok", "alert('Médico eliminado correctamente.');", true);
                    MostrarMedicos(OrdenActual()); 
                }
                else
                {
                   
                    ScriptManager.RegisterStartupScript(this, GetType(),
                        "alerta", "alert('No se pudo eliminar el registro.');", true);
                }
            }

            if (e.CommandName == "Jornadas")
            {
                string idMedico = e.CommandArgument.ToString();
                Response.Redirect("GestionJornadaMedico.aspx?ID_Medico=" + idMedico);

            }

        }

        protected void ddlFiltro_SelectedIndexChanged1(object sender, EventArgs e)
        {
            string texto = txtBuscar.Text.Trim();

            if (!string.IsNullOrEmpty(texto))
            {
                btnBuscar_Click(null, null);
            }
            else
            {
                MostrarMedicos(OrdenActual());
            }
        }
    }
}
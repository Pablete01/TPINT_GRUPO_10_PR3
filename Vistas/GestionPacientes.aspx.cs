using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Entidades;
using System.Data;


namespace Vistas
{
    public partial class GestionPacientes : System.Web.UI.Page
    {
        NegocioPacientes negocioPacientes = new NegocioPacientes();
        NegocioLocalidades negocioLocalidad = new NegocioLocalidades();
        NegocioProvincia negocioProvincia = new NegocioProvincia();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)  
            {
               lblUsuario.Text = ((Entidades.Usuario)Session["Usuario"]).email;
               MostrarPacientes();
            }
        }

        private void MostrarPacientes()
        {
            lblMensaje.Text = string.Empty;
            DataTable dt = negocioPacientes.cargarGrillaPacientes();
            grdPacientes.DataSource = dt;
            grdPacientes.DataBind();
        }

        private void EliminarPaciente(int idPaciente)
        {
            bool eliminado = negocioPacientes.EliminarPaciente(idPaciente);
            if (eliminado)
            {
                lblMensaje.Text = "Paciente eliminado correctamente";
            }
            else
            {
                lblMensaje.Text = "Error al eliminar el paciente";
            }

        }







        protected void ddlFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void gdrPacientes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void grdPacientes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdPacientes.PageIndex = e.NewPageIndex;
            MostrarPacientes(); // vuelve a cargar la grilla
        }

        protected void grdPacientes_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            lblMensaje.Text = string.Empty;
            grdPacientes.EditIndex = -1;   
            MostrarPacientes();          

        }

        protected void grdPacientes_RowEditing(object sender, GridViewEditEventArgs e)
        {
            lblMensaje.Text = string.Empty;
            grdPacientes.EditIndex = e.NewEditIndex; 
            MostrarPacientes();                     
        }

        protected void grdPacientes_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            GridViewRow row = grdPacientes.Rows[e.RowIndex];

            int idPaciente = Convert.ToInt32(grdPacientes.DataKeys[e.RowIndex].Value);

            string nombre = ((TextBox)row.FindControl("lbl_eit_nombre")).Text;
            string apellido = ((TextBox)row.FindControl("lbl_eit_apellido")).Text;
            string dni = ((Label)row.FindControl("lbl_eit_dni")).Text;
            RadioButtonList rblSexo = (RadioButtonList)row.FindControl("rbl_eit_sexo");
            string sexo = rblSexo.SelectedValue;
            string nacionalidad = ((TextBox)row.FindControl("lbl_eit_nacionalidad")).Text;
            string fechaNacimiento = ((TextBox)row.FindControl("lbl_eit_fechaNacimiento")).Text;
            string telefono = ((TextBox)row.FindControl("lbl_eit_telefono")).Text;
            string direccion = ((TextBox)row.FindControl("lbl_eit_direccion")).Text;
            string email = ((TextBox)row.FindControl("lbl_eit_email")).Text;
  
            DropDownList ddlProv = (DropDownList)row.FindControl("ddl_eit_provincia");
            DropDownList ddlLoc = (DropDownList)row.FindControl("ddl_eit_Localidad");

            int idProvincia = int.Parse(ddlProv.SelectedValue);
            int idLocalidad = int.Parse(ddlLoc.SelectedValue);

            int paciente = negocioPacientes.ActualizarPaciente(new Entidades.Paciente

            {
                idPaciente = idPaciente,
                nombre = nombre,
                apellido = apellido,
                dni = int.Parse(dni),
                sexo = sexo,
                nacionalidad = nacionalidad,
                fechaNacimiento = DateTime.Parse(fechaNacimiento),
                telefono = int.Parse(telefono),
                direccion = direccion,
                email = email,
                provincia = idProvincia,
                localidad = idLocalidad,
                estado = 3,
                perfil = 1
            }
            );
            if(paciente == 0)
            {
                lblMensaje.Text = "Error al actualizar el paciente.";
            }
            else 
            { lblMensaje.Text = "Paciente actualizado correctamente."; 
            }


            grdPacientes.EditIndex = -1;
            MostrarPacientes();
        }

        protected void grdPacientes_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState.HasFlag(DataControlRowState.Edit))
            {

                TextBox txtFecha = (TextBox)e.Row.FindControl("lbl_eit_fechaNacimiento");

                if (txtFecha != null)
                {
                    object fechaValue = DataBinder.Eval(e.Row.DataItem, "fechaNacimiento");
                    if (fechaValue != DBNull.Value)
                    {
                        txtFecha.Text = ((DateTime)fechaValue).ToString("yyyy-MM-dd");
                    }
                }
                RadioButtonList rblSexo = (RadioButtonList)e.Row.FindControl("rbl_eit_sexo");
                if (rblSexo != null)
                {
                    string sexo = DataBinder.Eval(e.Row.DataItem, "Sexo").ToString();
                    rblSexo.SelectedValue = sexo;

                    ListItem item = rblSexo.Items.FindByValue(sexo);
                    if (item != null)
                    {
                        rblSexo.ClearSelection();
                        item.Selected = true;
                    }
                }
                DropDownList ddlProv = (DropDownList)e.Row.FindControl("ddl_eit_provincia");
                ddlProv.DataSource = negocioProvincia.cargarProvincias();
                ddlProv.DataValueField = "ID_Provincia";
                ddlProv.DataTextField = "NombreProvincia";
                ddlProv.DataBind();

                ddlProv.SelectedValue = DataBinder.Eval(e.Row.DataItem, "ID_Provincia").ToString();

                DropDownList ddlLoc = (DropDownList)e.Row.FindControl("ddl_eit_Localidad");
                int idProv = int.Parse(ddlProv.SelectedValue);
                ddlLoc.DataSource = negocioLocalidad.cargarLocalidades(idProv);
                ddlLoc.DataTextField = "NombreLocalidad";
                ddlLoc.DataValueField = "ID_Localidad";
                ddlLoc.DataBind();

                ddlLoc.SelectedValue = DataBinder.Eval(e.Row.DataItem, "ID_Localidad").ToString();
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            DataTable dt = negocioPacientes.BuscarPacientes(txtBuscar.Text.Trim());
            grdPacientes.DataSource = dt;
            grdPacientes.DataBind();
            if (dt.Rows.Count == 0)
            {
                lblMensaje.Text = "No se encontraron pacientes con ese criterio.";
                grdPacientes.Visible = false;
            }
            else
            {
                lblMensaje.Text = string.Empty;
                grdPacientes.Visible = true;
            }
        }

        protected void btnAgregarPaciente_Click(object sender, EventArgs e)
        {
            lblMensaje.Text = string.Empty;
            Response.Redirect("RegistrarPaciente.aspx");
        }

        protected void grdPacientes_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int idPaciente = Convert.ToInt32(grdPacientes.DataKeys[e.RowIndex].Value);
            EliminarPaciente(idPaciente);
            MostrarPacientes();
        }

        protected void ddlProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddlProv = (DropDownList)sender;
            GridViewRow row = (GridViewRow)ddlProv.NamingContainer;

            DropDownList ddlLoc = (DropDownList)row.FindControl("ddl_eit_Localidad");

            int idProvincia = int.Parse(ddlProv.SelectedValue);
            ddlLoc.DataSource = negocioLocalidad.cargarLocalidades(idProvincia);
            ddlLoc.DataTextField = "NombreLocalidad";
            ddlLoc.DataValueField = "ID_Localidad";
            ddlLoc.DataBind();
        }

        protected void grdPacientes_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {
            grdPacientes.EditIndex = -1;
            MostrarPacientes();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Datos;
using Entidades;
using Negocio;

namespace Vistas
{
    public partial class FormularioAddMedico : System.Web.UI.Page
    {
        NegocioProvincia negocioProvincia = new NegocioProvincia();
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            if (!IsPostBack)
            {
                lblUsuario.Text = ((Entidades.Usuario)Session["Usuario"]).email;
                CargarSexo();
                CargarEspecialidades();
                CargarProvincias();
            }

        }

        private void CargarSexo()
        {
            ddlSexo.Items.Clear();
            ddlSexo.Items.Add("Masculino");
            ddlSexo.Items.Add("Femenino");
        }

        private void CargarEspecialidades()
        {
            NegocioMedicos neg = new NegocioMedicos();
            ddlEspecialidad.DataSource = neg.GetEspecialidades();   // DataTable
            ddlEspecialidad.DataTextField = "NombreEspecialidad";   // columna de la BD
            ddlEspecialidad.DataValueField = "ID_Especialidad";     // columna PK
            ddlEspecialidad.DataBind();
        }

        private void CargarProvincias()
        {
            NegocioMedicos neg = new NegocioMedicos();
            ddlProvincia.DataSource = negocioProvincia.cargarProvincias();
            ddlProvincia.DataValueField = "ID_Provincia";
            ddlProvincia.DataTextField = "NombreProvincia";
            ddlProvincia.DataBind();
            ddlProvincia.Items.Insert(0, new ListItem("--Seleccione una provincia--", "0"));
        }



        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            MedicoAdm m = new MedicoAdm
            {
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                DNI = txtDNI.Text,
                Sexo = ddlSexo.SelectedItem.Text,
                Nacionalidad = txtNacionalidad.Text,
                FechaNacimiento = DateTime.Parse(txtFechaNac.Text),
                Telefono = txtTelefono.Text,
                Direccion = txtDireccion.Text,
                ID_Localidad = int.Parse(ddlLocalidad.SelectedValue),
                // 🔹 Nuevos campos requeridos
                Email = txtEmail.Text,
                Contrasena = txtDNI.Text, // CONTRASEÑA = DNI
                ID_Especialidad = int.Parse(ddlEspecialidad.SelectedValue)
            };

            NegocioMedicos neg = new NegocioMedicos();
            bool ok = neg.RegistrarMedico(m);

            if (ok)
                Response.Write("<script>alert('Médico dado de alta  con éxito');</script>");
            else
                Response.Write("<script>alert('Error al insertar');</script>");

        }

        protected void ddlProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarLocalidades();
        }

        private void CargarLocalidades()
        {
            int idProv = int.Parse(ddlProvincia.SelectedValue);
            ddlLocalidad.Items.Clear();
            if (ddlProvincia.SelectedValue != "0")
            {
                NegocioLocalidades negocioLocalidad = new NegocioLocalidades();
                ddlLocalidad.DataSource = negocioLocalidad.cargarLocalidades(int.Parse(ddlProvincia.SelectedValue));
                ddlLocalidad.DataValueField = "ID_Localidad";
                ddlLocalidad.DataTextField = "NombreLocalidad";
                ddlLocalidad.DataBind();
                ddlLocalidad.Items.Insert(0, new ListItem("--Seleccione una localidad--", "0"));
            }
        }

        protected void btnInicio_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("GestionMedico.aspx");
        }
    }
}
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
        protected void Page_Init(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            //ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            if (!IsPostBack)
            {
                lblUsuario.Text = ((Entidades.Usuario)Session["Usuario"]).email;
                CargarSexo();
                CargarEspecialidades();
                CargarProvincias();  

                if (Request.QueryString["ID_Medico"] != null)
                {
                    CargarMedico(int.Parse(Request.QueryString["ID_Medico"]));
                }
            }

        }

        private void CargarMedico(int idMedico)
        {
            NegocioMedicos neg = new NegocioMedicos();
            MedicoAdm m = neg.ObtenerMedicoPorID(idMedico);

            if (m != null)
            {
                txtNombre.Text = m.Nombre;
                txtApellido.Text = m.Apellido;
                txtDNI.Text = m.DNI;
                ddlSexo.SelectedValue = m.Sexo;
                txtNacionalidad.Text = m.Nacionalidad;
                txtFechaNac.Text = m.FechaNacimiento.ToString("yyyy-MM-dd");
                txtTelefono.Text = m.Telefono;
                txtDireccion.Text = m.Direccion;

                // 🔹 Asignar provincia después de haber llamado a CargarProvincias() en Page_Load
                ddlProvincia.SelectedValue = m.ID_Provincia.ToString();

                // 🔹 Cargar localidades de ESA provincia
                CargarLocalidades();

                // 🔹 Recién ahora seleccionar la localidad del médico
                ddlLocalidad.SelectedValue = m.ID_Localidad.ToString();

                // 🔹 Usuario
                txtEmail.Text = m.Email;
                txtUsuario.Text = m.Usuario;
                txtContrasena.Text = m.Contrasena;

                // 🔹 Especialidad
                ddlEspecialidad.SelectedValue = m.ID_Especialidad.ToString();

                hiddenIdMedico.Value = m.ID_Medico.ToString();
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
            NegocioProvincia negocioProvincia = new NegocioProvincia();
            ddlProvincia.DataSource = negocioProvincia.cargarProvincias();
            ddlProvincia.DataValueField = "ID_Provincia";
            ddlProvincia.DataTextField = "NombreProvincia";
            ddlProvincia.DataBind();
            ddlProvincia.Items.Insert(0, new ListItem("--Seleccione una provincia--", "0"));
           
        }



        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                MedicoAdm m = new MedicoAdm
                {
                    ID_Medico = string.IsNullOrEmpty(hiddenIdMedico.Value) ? 0 : int.Parse(hiddenIdMedico.Value),
                    Nombre = txtNombre.Text,
                    Apellido = txtApellido.Text,
                    DNI = txtDNI.Text,
                    Sexo = ddlSexo.SelectedItem.Text,
                    Nacionalidad = txtNacionalidad.Text,
                    FechaNacimiento = DateTime.Parse(txtFechaNac.Text),
                    Telefono = txtTelefono.Text,
                    Direccion = txtDireccion.Text,
                    ID_Localidad = int.Parse(ddlLocalidad.SelectedValue),
                    Email = txtEmail.Text,
                    Usuario = txtUsuario.Text,
                    Contrasena = txtContrasena.Text,
                    ID_Especialidad = int.Parse(ddlEspecialidad.SelectedValue)
                };

                NegocioMedicos neg = new NegocioMedicos();
                bool ok;

                if (m.ID_Medico > 0) // modo edición
                    ok = neg.ModificarMedico(m);
                else // modo alta
                    ok = neg.RegistrarMedico(m);

                if (ok)
                {
                    lblMensaje.Text = "Medico guardado con éxito.";
                    btnCancelar.Text = "Cerrar";
                    LimpiarControles();
                    btnAceptar.Visible = false;
                }
                else
                    lblMensaje.Text = "Error al guardar el médico. DNI o email o usuario ya registrado.";
            }
            catch (Exception ex)
            {
                lblMensaje.Text = ex.Message;// "Error: Verifique los datos ingresados";
            }
        }

        protected void ddlProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ddlProvincia.SelectedValue != "0")
            {
                CargarLocalidades();
            }
              
        }

        private void CargarLocalidades()
        {
            int idProv = int.Parse(ddlProvincia.SelectedValue);

            NegocioLocalidades negocioLocalidad = new NegocioLocalidades();
            ddlLocalidad.DataSource = negocioLocalidad.cargarLocalidades(int.Parse(ddlProvincia.SelectedValue));
            ddlLocalidad.DataValueField = "ID_Localidad";
            ddlLocalidad.DataTextField = "NombreLocalidad";
            ddlLocalidad.DataBind();
            ddlLocalidad.Items.Insert(0, new ListItem("--Seleccione una localidad--", "0"));
        }

        protected void btnInicio_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("GestionMedico.aspx");
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("GestionMedico.aspx");
        }

        private void LimpiarControles()
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtEmail.Text = "";
            txtDNI.Text = "";
            txtTelefono.Text = "";
            txtFechaNac.Text = "";
            txtNacionalidad.Text = "";
            txtDireccion.Text = "";

            ddlProvincia.SelectedIndex = 0;
            ddlLocalidad.Items.Clear();
            ddlLocalidad.Items.Insert(0, new ListItem("--Seleccione una localidad--", "0"));

            ddlSexo.SelectedIndex = 0;
            ddlEspecialidad.SelectedIndex = 0;

            hiddenIdMedico.Value = "";
        }
    }
}
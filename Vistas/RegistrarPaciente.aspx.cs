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
    public partial class GestionPaciente : System.Web.UI.Page
    {
        NegocioProvincia negocioProvincia = new NegocioProvincia();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblUsuario.Text = ((Usuario)Session["Usuario"]).email;
                DropDlistProv.DataSource = negocioProvincia.cargarProvincias();
                DropDlistProv.DataValueField = "ID_Provincia";
                DropDlistProv.DataTextField = "NombreProvincia";
                DropDlistProv.DataBind();
                DropDlistProv.Items.Insert(0, new ListItem("--Seleccione una provincia--", "0"));
            }

        }

        protected void BtAceptar_Click(object sender, EventArgs e)
        {
            InsertarPaciente();
        }

        private void InsertarPaciente()
        {
            string sexo = "";
            if(rbFemenino.Checked)
            {
                sexo = "Femenino";
            }
            else if(rbMasculino.Checked)
            {
                sexo = "Masculino";
            }
            

            Paciente paciente = new Paciente();
            paciente.dni = int.Parse(TxtDni.Text);
            paciente.nombre = txtNombre.Text;
            paciente.apellido = txtApellido.Text;
            paciente.sexo = sexo; 
            paciente.nacionalidad = TxtNacionalidad.Text;
            paciente.fechaNacimiento = DateTime.Parse(txtFechaNacimiento.Text);
            paciente.telefono = int.Parse(txtTelefono.Text);
            paciente.direccion = txtDireccion.Text;
            paciente.localidad = int.Parse(ddlLocalidades.SelectedValue);
            paciente.email = txtEmail.Text;
            paciente.perfil = 3; 
            paciente.estado = 1; 

            string mensaje = "";
            Negocio.NegocioPacientes negocioPacientes = new Negocio.NegocioPacientes();
            int filasAfectadas = negocioPacientes.InsertarPaciente(paciente, out mensaje);

            if(filasAfectadas > 0)
            {
                lblMensaje.Text = "Paciente registrado con éxito";
                btnCancelar.Text = "Cerrar";
                BtAceptar.Visible = false;
                LimpiarControles();
            }
            else
            {
                lblMensaje.Text = mensaje;
            }
        }

        protected void DropDlistProv_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlLocalidades.Items.Clear();
            if (DropDlistProv.SelectedValue != "0")
            {
                NegocioLocalidades negocioLocalidad = new NegocioLocalidades();
                ddlLocalidades.DataSource = negocioLocalidad.cargarLocalidades(int.Parse(DropDlistProv.SelectedValue));
                ddlLocalidades.DataValueField = "ID_Localidad";
                ddlLocalidades.DataTextField = "NombreLocalidad";
                ddlLocalidades.DataBind();
                ddlLocalidades.Items.Insert(0, new ListItem("--Seleccione una localidad--", "0"));
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("GestionPacientes.aspx");
        }

        private void LimpiarControles()
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            TxtDni.Text = "";
            TxtNacionalidad.Text = "";
            txtFechaNacimiento.Text = "";
            txtDireccion.Text = "";
            txtEmail.Text = "";
            txtTelefono.Text = "";

            rbFemenino.Checked = false;
            rbMasculino.Checked = false;

            DropDlistProv.SelectedIndex = 0;

            ddlLocalidades.Items.Clear();
            ddlLocalidades.Items.Insert(0, new ListItem("--Seleccione una localidad--", "0"));
        }
    }
}
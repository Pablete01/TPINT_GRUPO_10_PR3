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
    public partial class ListadoTurnos : System.Web.UI.Page
    {
        NegocioTurnos negocioTurnos = new NegocioTurnos();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)  
            {
               lblUsuario.Text = ((Entidades.Usuario)Session["Usuario"]).email;
               MostrarTurnos();
            }
        }

        private void MostrarTurnos()
        {
            DataTable dt = negocioTurnos.CargarGrillaTurnos();
            // MOSTRAR NOMBRES DE COLUMNAS EN LA CONSOLA DE DEBUG
            foreach (DataColumn col in dt.Columns)
            {
                System.Diagnostics.Debug.WriteLine("Columna: " + col.ColumnName);
            }
            gvTurnos.DataSource = dt;
            gvTurnos.DataBind();
        }




        protected void grdPacientes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvTurnos.PageIndex = e.NewPageIndex;
            MostrarTurnos(); // vuelve a cargar la grilla
        }

        
    }
}
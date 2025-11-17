using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace Dao
{
     class AccesoDatos
     {
        String rutaDBClinica = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=DBClinica_Grupo10;Integrated Security=True;Encrypt=False";

        public AccesoDatos()
        {

        }
        public SqlConnection ObtenerConexion()
        {
            SqlConnection cn = new SqlConnection(rutaDBClinica);
            return cn;

        }

        public SqlDataAdapter ObtenerAdaptador(String consultaSql, SqlConnection cn)
        {
            SqlDataAdapter adaptador;
            adaptador = new SqlDataAdapter(consultaSql, cn);
            return adaptador;
      
        }
        public DataTable ObtenerTabla(String NombreTabla, String Sql)
        {
            DataSet ds = new DataSet();
            SqlConnection Conexion = ObtenerConexion();
            SqlDataAdapter adp = ObtenerAdaptador(Sql, Conexion);
            adp.Fill(ds, NombreTabla);
            Conexion.Close();
            return ds.Tables[NombreTabla];
        }

        public DataTable ObtenerTablaSP(string nombreTabla, string nombreSP, SqlParameter[] parametros)
        {
            SqlConnection conexion = ObtenerConexion();
            SqlCommand comando = new SqlCommand(nombreSP, conexion);
            comando.CommandType = CommandType.StoredProcedure;

            if (parametros != null)
                comando.Parameters.AddRange(parametros);

            SqlDataAdapter da = new SqlDataAdapter(comando);
            DataTable tabla = new DataTable(nombreTabla);
            da.Fill(tabla);
            conexion.Close();

            return tabla;
        }


     }
}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Runtime.Remoting.Messaging;


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
            try
            {
                cn.Open();
                return cn;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public SqlDataAdapter ObtenerAdaptador(String consultaSql, SqlConnection cn)
        {
            SqlDataAdapter adaptador;
            adaptador = new SqlDataAdapter(consultaSql, cn);
            return adaptador;

        }
        public DataTable ObtenerTabla(String NombreTabla, String StoredProcedure)
        {
            DataSet ds = new DataSet();
            SqlConnection Conexion = ObtenerConexion();
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand(StoredProcedure, Conexion);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            adp.Fill(ds, NombreTabla);
            Conexion.Close();
            return ds.Tables[NombreTabla];
        }

        public int AgregarPaciente(SqlCommand comandoSQL, string spInsertarPaciente, out string mensaje)
        {
            mensaje = "";
            SqlConnection cn = ObtenerConexion();
            try
            {
                comandoSQL.Connection = cn;
                comandoSQL.CommandType = CommandType.StoredProcedure;
                comandoSQL.CommandText = spInsertarPaciente;
                int filasAfectadas = comandoSQL.ExecuteNonQuery();

                return filasAfectadas;
            }
            catch (SqlException ex)
            {

                if (ex.Number == 2627 || ex.Number == 2601)
                {

                    mensaje = "Ya existe un registro con ese DNI o Email.";
                }
                else
                {
                    mensaje = "Error al insertar: " + ex.Message;
                }
                return 0;
            }
            finally
            {
                cn.Close();
            }
        }

        public int ActualizarPaciente(SqlCommand comandoSQL, string spActualizarPaciente)
        {
           
            SqlConnection cn = ObtenerConexion();
            try
            {
                comandoSQL.Connection = cn;
                comandoSQL.CommandType = CommandType.StoredProcedure;
                comandoSQL.CommandText = spActualizarPaciente;
                int filasAfectadas = comandoSQL.ExecuteNonQuery();
                return filasAfectadas;
            }
            catch (SqlException ex)
            {
                throw;
              // return 0;
            }
            finally
            {
                cn.Close();
            }
        }

        public int EliminarPaciente(SqlCommand comandoSQL, string spEliminarPaciente)
        {
            SqlConnection cn = ObtenerConexion();
            try
            {
                comandoSQL.Connection = cn;
                comandoSQL.CommandType = CommandType.StoredProcedure;
                comandoSQL.CommandText = spEliminarPaciente;
                int filasAfectadas = comandoSQL.ExecuteNonQuery();
                return filasAfectadas;
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al eliminar el paciente: " + ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }

        public DataTable ObtenerProvincias()
        {
            DataTable dt = new DataTable();
            SqlConnection cn = ObtenerConexion();
            SqlDataAdapter adp = new SqlDataAdapter("SELECT ID_Provincia, NombreProvincia FROM Provincia", cn);
            adp.Fill(dt);
            return dt;
        }

        public DataTable ObtenerLocalidades(int idProvincia)
        {
            DataTable dt = new DataTable();
            SqlConnection cn = ObtenerConexion();
            SqlDataAdapter adp = new SqlDataAdapter("SELECT ID_Localidad, NombreLocalidad, ID_Provincia FROM Localidad WHERE ID_Provincia = @ID_Prov", cn);
            adp.SelectCommand.Parameters.AddWithValue("@ID_Prov", idProvincia);
            adp.Fill(dt);
            return dt;
        }


    }
}

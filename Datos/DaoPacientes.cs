using Dao;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DaoPacientes
    {
        AccesoDatos dm = new AccesoDatos();

        public DataTable GetTablaPacientes()
        {
            string consulta = "SP_ListarPacientesParaPersAdmin";
            return dm.ObtenerTabla("Pacientes", consulta);
        }

        public DataTable BuscarPacientes(string valor)
        {
            SqlCommand comando = new SqlCommand();
            comando.Parameters.AddWithValue("@texto", valor);
            string spBuscarPacientes = "SP_BuscarPacientes";
            return dm.ObtenerBusquedaPacientes("PacientesBuscados", spBuscarPacientes, comando);
        }


        public int InsertarPaciente(Paciente paciente, out string mensaje)
        {
            SqlCommand comando = new SqlCommand();
          //  comando.Parameters.AddWithValue("@ID_Pacientes", paciente.idPaciente);
            comando.Parameters.AddWithValue("@DNI", paciente.dni);
            comando.Parameters.AddWithValue("@Nombre", paciente.nombre);
            comando.Parameters.AddWithValue("@Apellido", paciente.apellido);
            comando.Parameters.AddWithValue("@Sexo", paciente.sexo);
            comando.Parameters.AddWithValue("@Nacionalidad", paciente.nacionalidad);
            comando.Parameters.AddWithValue("@FechaNacimiento", paciente.fechaNacimiento);
            comando.Parameters.AddWithValue("@Telefono", paciente.telefono);
            comando.Parameters.AddWithValue("@Direccion", paciente.direccion);
            comando.Parameters.AddWithValue("@ID_Localidad", paciente.localidad);
            comando.Parameters.AddWithValue("@Email", paciente.email);
            comando.Parameters.AddWithValue("@ID_Perfil", paciente.perfil);
            comando.Parameters.AddWithValue("@Estado", paciente.estado);

            string spInsertarPaciente = "SP_InsertarPaciente";
            return dm.AgregarPaciente(comando, spInsertarPaciente, out mensaje);
        }

        public int ActualizarPaciente(Paciente paciente)
        {
            SqlCommand comando = new SqlCommand();
            comando.Parameters.AddWithValue("@ID_Pacientes", paciente.idPaciente);
            comando.Parameters.AddWithValue("@DNI", paciente.dni);
            comando.Parameters.AddWithValue("@Nombre", paciente.nombre);
            comando.Parameters.AddWithValue("@Apellido", paciente.apellido);
            comando.Parameters.AddWithValue("@Sexo", paciente.sexo);
            comando.Parameters.AddWithValue("@Nacionalidad", paciente.nacionalidad);
            comando.Parameters.AddWithValue("@FechaNacimiento", paciente.fechaNacimiento);
            comando.Parameters.AddWithValue("@Telefono", paciente.telefono);
            comando.Parameters.AddWithValue("@Direccion", paciente.direccion);
            comando.Parameters.AddWithValue("@ID_Localidad", paciente.localidad);
            comando.Parameters.AddWithValue("@Email", paciente.email);
            comando.Parameters.AddWithValue("@ID_Perfil", paciente.perfil);
            comando.Parameters.AddWithValue("@Estado", paciente.estado);
            string spActualizarPaciente = "SP_ActualizarPaciente";
            return dm.ActualizarPaciente(comando, spActualizarPaciente);

        }

        public bool EliminarPaciente(int idPaciente)
        {
            SqlCommand comando = new SqlCommand();
            comando.Parameters.AddWithValue("@ID_Paciente", idPaciente);
            string spEliminarPaciente = "SP_EliminarPaciente";
            int filasAfectadas = dm.EliminarPaciente(comando, spEliminarPaciente);
            if (filasAfectadas == 0)
            {
                return false; 
            }
            return true; 
        }

        public int ObtenerIDPacientePorDNI(string DNI)
        {
            SqlConnection cn = dm.ObtenerConexion();
            SqlCommand cmd = new SqlCommand(@"
            SELECT p.ID_Pacientes
            FROM Pacientes p
            INNER JOIN Persona per ON per.ID_Persona = p.ID_Persona
            WHERE per.DNI = @DNI", cn);

            cmd.Parameters.AddWithValue("@DNI", DNI);

            if (cn.State != ConnectionState.Open)
                cn.Open();

            object result = cmd.ExecuteScalar();

            cn.Close();

            if (result != null)
                return Convert.ToInt32(result);

            return -1;
        }
        public DataTable ObtenerPacientesConParametros(string texto, string orden)
        {
            SqlConnection cn = dm.ObtenerConexion();
            SqlCommand cmd = new SqlCommand("SP_ListarPacientesConParametros", cn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@texto", string.IsNullOrEmpty(texto) ? (object)DBNull.Value : texto);
            cmd.Parameters.AddWithValue("@orden", string.IsNullOrEmpty(orden) ? (object)DBNull.Value : orden);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            cn.Close();
            return dt;
        }



        //public DataTable cargarGrillaPacientesCompletosxMedico(int idMedico)
        //{
        //    string consulta = "SP_ListarPacientesPorMedico";
        //    SqlCommand comando = new SqlCommand();
        //    comando.Parameters.AddWithValue("@ID_Medico", idMedico);
        //    return dm.ObtenerTablaPacientesCompletosxMedico(consulta, comando, "PacientesPorMedico");
        //}
    }
}

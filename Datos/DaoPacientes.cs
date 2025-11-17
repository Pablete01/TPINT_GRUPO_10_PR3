using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dao;
using Entidades;

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

        public int InsertarPaciente(Paciente paciente, out string mensaje)
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
            comando.Parameters.AddWithValue("@ID_Provincia", paciente.provincia);
            comando.Parameters.AddWithValue("@Email", paciente.email);
            comando.Parameters.AddWithValue("@ID_Perfil", paciente.perfil);
            comando.Parameters.AddWithValue("@Estado", paciente.estado);

            string spInsertarPaciente = "spInsertarPaciente";
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
            comando.Parameters.AddWithValue("@ID_Provincia", paciente.provincia);
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
                return false; // devuelve false si no se eliminó ningún registro
            }
            return true; // devuelve true si se eliminó correctamente
        }
    }
}

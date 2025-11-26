using Dao;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DaoTurnoPaciente
    {
        AccesoDatos ds = new AccesoDatos();

        public DataTable ObtenerTurnosPaciente(int idPaciente)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@ID_Paciente", idPaciente)
            };

            return ds.ObtenerTablaSP("TurnosPaciente", "SP_ListarTurnosPacienteGestionTurnos", parametros);
        }

        public DataTable ObtenerTurnosxMedico(int idMedico)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@ID_Medico", idMedico)
            };

            return ds.ObtenerTablaSP("TurnosxMedico", "SP_ListarTurnosPacientexMedico", parametros);
        }

        public bool ActualizarEstadoPaciente(int idTurno, int estado, string observaciones)
        {
            SqlCommand comando = new SqlCommand();
            comando.Parameters.AddWithValue("@ID_Turno", idTurno);
            comando.Parameters.AddWithValue("@ID_Estado", estado);
            comando.Parameters.AddWithValue("@Observaciones", observaciones);
            string spEliminarPaciente = "SP_ActualizarEstadoPaciente";
            int filasAfectadas = ds.ActualizarEstadoPaciente(comando, spEliminarPaciente);
            if (filasAfectadas == 0)
            {
                return false;
            }
            return true;
        }

    }
}

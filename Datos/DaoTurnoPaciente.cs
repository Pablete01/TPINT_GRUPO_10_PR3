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

        public DataTable ObtenerEspecialidades()
        {
            string consulta = "SELECT ID_Especialidad, NombreEspecialidad FROM Especialidad";
            return ds.ObtenerTablaSQL("Especialidad", consulta);
        }

        public DataTable ObtenerMedicosPorEspecialidad(int idEspecialidad)
        {
            SqlParameter[] parametros = {
                new SqlParameter("@ID_Especialidad", idEspecialidad)
            };

            return ds.ObtenerTablaSP("Medicos", "sp_ObtenerMedicosPorEspecialidad", parametros);
        }

        public List<int> ObtenerDiasJornadaMedico(int idMedico)
        {
            List<int> dias = new List<int>();
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@ID_Medico", idMedico)
            };
            DataTable tabla = ds.ObtenerTablaSP(
                "DiasJornada",
                "SP_ObtenerDiasJornadaMedico",
                parametros
            );

            // recorres resultados
            foreach (DataRow row in tabla.Rows)
            {
                dias.Add(Convert.ToInt32(row["DiaSemana"]));
            }

            return dias;
        }

        public DataTable ObtenerHorariosDisponibles(int idMedico, DateTime fecha, int idPaciente)
        {
            AccesoDatos ad = new AccesoDatos();

            SqlParameter[] parametros = new SqlParameter[3];
            parametros[0] = new SqlParameter("@ID_Medico", idMedico);
            parametros[1] = new SqlParameter("@Fecha", fecha);
            parametros[2] = new SqlParameter("@ID_Paciente", idPaciente);

            return ad.ObtenerTablaSP("Horarios", "SP_ObtenerHorariosDisponibles", parametros);
        }

        public int InsertarTurno(TurnoInsert t)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.Parameters.AddWithValue("@ID_Paciente", t.ID_Paciente);
            cmd.Parameters.AddWithValue("@ID_Medico", t.ID_Medico);
            cmd.Parameters.AddWithValue("@Fecha", t.Fecha);
            cmd.Parameters.AddWithValue("@Hora", t.Hora);
            return ds.EjecutarSPNonQuery("SP_InsertarTurnoPaciente", cmd);
        }

        public int CancelarTurno(int idTurno)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@ID_Turno", idTurno);
            return ds.EjecutarSPNonQuery("SP_CancelarTurnoPaciente", cmd);
        }



        public DataTable ObtenerTurnosxMedico(int idMedico)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@ID_Medico", idMedico),
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

        public DataTable BuscarPacientesxTurno(string texto)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@texto", texto)
            };

            return ds.ObtenerTablaSP("BuscarPacientesxTurno", "SP_BuscarPacientesxTurno", parametros);
        }

        public DataTable ObtenerTurnosxMedico_Fecha(int idMedico, DateTime desde, DateTime hasta)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@ID_Medico", idMedico),
                new SqlParameter("@Desde", desde),
                new SqlParameter("@Hasta", hasta)
            };

            return ds.ObtenerTablaSP("TurnosxMedicoFecha", "SP_ListarTurnosPacientexMedico_Fecha", parametros);
        }


    }
}

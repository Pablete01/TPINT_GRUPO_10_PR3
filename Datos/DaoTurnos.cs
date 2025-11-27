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
    public class DaoTurnos
    {
        AccesoDatos dm = new AccesoDatos();

        public DataTable GetTablaTurnos()
        {
            string consulta = "SP_ListarTurnos";
            return dm.ObtenerTabla("Turnos", consulta);
        }

        public DataTable GetTurnosMedicoFecha(int idMedico, DateTime fecha)
        {
            SqlParameter[] parametros =
                {
                new SqlParameter("@IdMedico", idMedico),
                new SqlParameter("@Fecha", fecha.Date)
        };

            string consulta = "SP_ListarTurnosPorFecha";
            return dm.ObtenerTablaSP("Fechas", consulta, parametros);
        }

        public DataTable GetHorarioMedico(int idMedico)
        {
            SqlParameter[] parametros =
            {
                new SqlParameter("IdMedico", idMedico)
            };
            string consulta = "SP_ListarHorarioMedico";




            return dm.ObtenerTablaSP("JornadasMedicos", consulta, parametros);
        }

        public int AgregarTurno(Turno t)
        {
            using (SqlConnection cn = new SqlConnection(dm.ObtenerConexion().ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_AgregarTurno", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ID_Pacientes", t.idPaciente);
                cmd.Parameters.AddWithValue("@ID_Medico", t.idProfesional);
                cmd.Parameters.AddWithValue("@Fecha", t.fechaTurno);
                cmd.Parameters.AddWithValue("@Hora", t.horaTurno);
                cmd.Parameters.AddWithValue("@ID_Estado", t.estado);
                cmd.Parameters.AddWithValue("@Observaciones", t.observaciones);

                cn.Open();
                object result = cmd.ExecuteScalar();
                cn.Close();

                return (result != null) ? Convert.ToInt32(result) : -1;
            }
        }

        public DataTable ObtenerTurnosPorFecha(DateTime desde, DateTime hasta)
        {
            SqlConnection cn = dm.ObtenerConexion();
            SqlCommand cmd = new SqlCommand("sp_ObtenerInformeTurnos", cn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Desde", desde);
            cmd.Parameters.AddWithValue("@Hasta", hasta);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            cn.Close();
            return dt;
        }

        public int ContabilizarTurnosPorEstado(DateTime desde, DateTime hasta, int estado) 
        {
            SqlConnection cn = dm.ObtenerConexion();
            SqlCommand cmd = new SqlCommand(@"
                SELECT COUNT(*) 
                FROM Turnos 
                WHERE Fecha BETWEEN @Desde AND @Hasta 
                  AND ID_Estado = @Estado", cn);

            cmd.Parameters.AddWithValue("@Desde", desde);
            cmd.Parameters.AddWithValue("@Hasta", hasta);
            cmd.Parameters.AddWithValue("@Estado", estado);

            int resultado = (int)cmd.ExecuteScalar();
            cn.Close();
            return resultado;
        }
    }
}

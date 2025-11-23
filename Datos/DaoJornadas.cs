using Dao;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DaoJornadas
    {
        AccesoDatos ds = new AccesoDatos();

        public DataTable ObtenerJornadasMedico(int idMedico)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
            new SqlParameter("@ID_Medico", idMedico)
            };

            return ds.ObtenerTablaSP("JornadasMedico", "sp_ObtenerJornadasMedico", parametros);
        }

        public bool AgregarJornada(int idMedico, int diaSemana, string horaEntrada, string horaSalida, int duracion)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.Parameters.AddWithValue("@ID_Medico", idMedico);
            cmd.Parameters.AddWithValue("@DiaSemana", diaSemana);
            cmd.Parameters.AddWithValue("@HoraEntrada", horaEntrada);
            cmd.Parameters.AddWithValue("@HoraSalida", horaSalida);
            cmd.Parameters.AddWithValue("@Duracion", duracion);

            int resultado = ds.EjecutarSPNonQuery("sp_AgregarJornadaMedico", cmd);

            return resultado == 1;  // true si insertó, false si NO insertó
        }

    }
}

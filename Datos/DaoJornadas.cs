using Dao;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

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

        public int AgregarJornada(JornadaMedico j)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.Parameters.AddWithValue("@ID_Medico", j.ID_Medico);
            cmd.Parameters.AddWithValue("@DiaSemana", j.DiaSemana);
            cmd.Parameters.AddWithValue("@HoraEntrada", j.HoraEntrada);
            cmd.Parameters.AddWithValue("@HoraSalida", j.HoraSalida);
            cmd.Parameters.AddWithValue("@Duracion", j.Duracion);

            // Ejecutar y devolver INT (1 ok, -1 error)
            return ds.EjecutarSPNonQuery("sp_AgregarJornadaMedico", cmd);
        }

    }
}

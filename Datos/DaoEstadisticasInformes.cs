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
    public class DaoEstadisticasInformes
    {
        AccesoDatos dm = new AccesoDatos();

        public DataTable EspecialidadMasHoras()
        {
            SqlConnection cn = dm.ObtenerConexion();
            SqlCommand cmd = new SqlCommand("sp_EspecialidadMasHoras", cn);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            cn.Close();
            return dt;
        }

        public DataTable EspecialidadMasJornadas()
        {
            SqlConnection cn = dm.ObtenerConexion();
            SqlCommand cmd = new SqlCommand("sp_EspecialidadMasJornadas", cn);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            cn.Close();
            return dt;
        }

        public DataTable CantidadTurnosPorEspecialidad(int idEspecialidad, DateTime desde, DateTime hasta)
        {
            SqlConnection cn = dm.ObtenerConexion();
            SqlCommand cmd = new SqlCommand("sp_CantidadTurnosPorEspecialidad", cn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@IDEspecialidad", idEspecialidad);
            cmd.Parameters.AddWithValue("@Desde", desde);
            cmd.Parameters.AddWithValue("@Hasta", hasta);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            cn.Close();
            return dt;
        }

    }
}

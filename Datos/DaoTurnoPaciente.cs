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

    }
}

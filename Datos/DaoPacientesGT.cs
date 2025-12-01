using Dao;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DaoPacientesGT
    {
        AccesoDatos ds = new AccesoDatos();

        public DataTable ObtenerPacientes()
        {
            return ds.ObtenerTablaSP(
                "PacientesGT",
                "SP_ListarPacientes_GestionTurnos",
                null
            );
        }
    }
}

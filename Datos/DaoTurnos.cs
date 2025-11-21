using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dao;

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
    }
}

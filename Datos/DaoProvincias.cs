using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dao;

namespace Datos
{
    public class DaoProvincias
    {
        AccesoDatos dm = new AccesoDatos();

        public DataTable GetProvincias()
        {          
            return dm.ObtenerProvincias();
        }
    }
}

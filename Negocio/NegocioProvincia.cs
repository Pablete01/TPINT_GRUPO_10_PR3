using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Negocio
{
    public class NegocioProvincia
    {
       DaoProvincias dao = new DaoProvincias();
        public DataTable cargarProvincias()
        {
            DataTable dt = dao.GetProvincias();
            return dt;
        }

    }
}

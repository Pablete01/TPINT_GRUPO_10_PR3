using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Negocio
{
    public  class NegocioTurnos
    {
       DaoTurnos dao = new DaoTurnos();
        
       public DataTable CargarGrillaTurnos()
       {
           DataTable dt = dao.GetTablaTurnos();
           return dt;
        }
    }
}

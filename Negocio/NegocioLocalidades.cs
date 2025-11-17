using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Negocio
{
    public class NegocioLocalidades
    {
        DaoLocalidades dao = new DaoLocalidades();
        public DataTable cargarLocalidades(int idProvincia)
        {
           
            DataTable dt = dao.GetLocalidades(idProvincia);
            return dt;
        }
    }
}

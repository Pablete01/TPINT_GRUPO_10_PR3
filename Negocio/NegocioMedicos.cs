using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using Dao;
using Datos;
using Entidades;

namespace Negocio
{
    public class NegocioMedicos
    {
        DaoMedicos dao = new DaoMedicos();

        public DataTable cargarGrillaMedicos()
        {
            DataTable dt = dao.GetTablaMedicos();
            return dt;
        }
    }  

    


}


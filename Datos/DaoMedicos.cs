using Dao;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Datos
{
    public class DaoMedicos
    {
        AccesoDatos dm = new AccesoDatos(); 

        public DataTable GetTablaMedicos()
        {
            string consulta = "SP_ListarMedicosParaPersAdmin";
            return dm.ObtenerTabla("Medicos", consulta); 
        }

    }
}

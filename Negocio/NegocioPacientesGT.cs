using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Negocio
{
    public class NegocioPacientesGT
    {
        DaoPacientesGT dao = new DaoPacientesGT();


        public DataTable ObtenerPacientes()
        {
            return dao.ObtenerPacientes();
        }
    }
}

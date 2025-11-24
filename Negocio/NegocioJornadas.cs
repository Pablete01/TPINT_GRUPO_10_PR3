using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dao;
using Datos;
using Entidades;
namespace Negocio
{
    public class NegocioJornadas
    {
        DaoJornadas dao = new DaoJornadas();

        public DataTable ObtenerJornadasMedico(int idMedico)
        {
            return dao.ObtenerJornadasMedico(idMedico);
        }

        public bool AgregarJornada(JornadaMedico jornada)
        {
            int resultado = dao.AgregarJornada(jornada);

            // SP: 1 = OK, -1 = superposición, 0 = error
            return resultado == 1;
        }
    }
}

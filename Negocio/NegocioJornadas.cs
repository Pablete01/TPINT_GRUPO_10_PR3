using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dao;
using Datos;

namespace Negocio
{
    public class NegocioJornadas
    {
        DaoJornadas dao = new DaoJornadas();

        public DataTable ObtenerJornadasMedico(int idMedico)
        {
            return dao.ObtenerJornadasMedico(idMedico);
        }

        public bool AgregarJornada(int id, int dia, string hIn, string hOut, int dur)
        {
            return dao.AgregarJornada(id, dia, hIn, hOut, dur);
        }
    }
}

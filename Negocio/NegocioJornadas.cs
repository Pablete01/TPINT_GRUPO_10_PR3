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
            return resultado == 1;
        }

        public bool EliminarJornada(int idJornada)
        {
            DaoJornadas dao = new DaoJornadas();
            return dao.BajaLogicaJornadaYTurnos(idJornada);
        }
    }
}

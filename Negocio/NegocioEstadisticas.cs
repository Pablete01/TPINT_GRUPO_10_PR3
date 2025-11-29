using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using Dao;
using Datos;
using Entidades;

namespace Negocio
{
    public class NegocioEstadisticas
    {
        DaoEstadisticasInformes dao = new DaoEstadisticasInformes();

        public DataTable EspecialidadMasHoras()
        {
            return dao.EspecialidadMasHoras();
        }

        public DataTable EspecialidadMasJornadas()
        {
            return dao.EspecialidadMasJornadas();
        }

        public DataTable ObtenerCantidadTurnosPorEspecialidad(int idEsp, DateTime desde, DateTime hasta)
        {
            return dao.CantidadTurnosPorEspecialidad(idEsp, desde, hasta);
        }

        public DataTable ObtenerInformeTurnos(DateTime desde, DateTime hasta)
        {
            return dao.ObtenerTurnosPorFecha(desde, hasta);
        }

        public DataTable ObtenerInformeTurnosPresentesAusentes(DateTime desde, DateTime hasta)
        {
            return dao.ObtenerTurnosPresentesAusentesPorFecha(desde, hasta);
        }

        public int ContabilizarTurnosPorEstado(DateTime desde, DateTime hasta, int estado)
        {
            return dao.ContabilizarTurnosPorEstado(desde, hasta, estado);
        }

        public DataTable ObtenerInformeTurnosPorEstado(DateTime desde, DateTime hasta, int estado)
        {
            return dao.ObtenerTurnosPorEstado(desde, hasta, estado);
        }

    }
}

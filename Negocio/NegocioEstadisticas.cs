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
    }
}

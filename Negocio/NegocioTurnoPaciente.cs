using Dao;
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
    public class NegocioTurnoPaciente
    {
        DaoTurnoPaciente dao = new DaoTurnoPaciente();

        public DataTable ObtenerTurnosPaciente(int idPaciente)
        {
            return dao.ObtenerTurnosPaciente(idPaciente);
        }

        public DataTable ObtenerTurnosxMedico(int idMedico)
        {
            return dao.ObtenerTurnosxMedico(idMedico);
        }

        public bool ActualizarEstadoPaciente(int idTurno, int idEstado, string observaciones)
        {
            return dao.ActualizarEstadoPaciente(idTurno, idEstado, observaciones);
        }

        public DataTable BuscarPacientesxTurno(string texto)
        {
            return dao.BuscarPacientesxTurno(texto);
        }
    }
}

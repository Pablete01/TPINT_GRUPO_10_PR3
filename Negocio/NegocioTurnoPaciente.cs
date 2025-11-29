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


        public DataTable ObtenerEspecialidades()
        {

            return dao.ObtenerEspecialidades();
        }

        public DataTable ObtenerMedicosPorEspecialidad(int idEspecialidad)
        {

            return dao.ObtenerMedicosPorEspecialidad(idEspecialidad);
        }

        public List<int> ObtenerDiasJornada(int idMedico)
        {
            return dao.ObtenerDiasJornadaMedico(idMedico);
        }

        public DataTable ObtenerHorariosDisponibles(int idMedico, DateTime fecha, int idPaciente)
        {
            return dao.ObtenerHorariosDisponibles(idMedico, fecha, idPaciente);
        }

        public string InsertarTurnoPaciente(TurnoInsert t)
        {
            int r = dao.InsertarTurno(t);

            switch (r)
            {
                case -1: return "El médico no tiene jornada configurada para ese día.";
                case -2: return "El médico ya tiene un turno reservado en ese horario.";
                case -3: return "El paciente ya tiene un turno con este médico ese día.";
                case -4: return "El paciente ya tiene un turno en ese horario con otro médico.";
                case 1: return "OK";
                default: return "Error desconocido.";
            }
        }

        public string CancelarTurnoPaciente(int idTurno)
        {
            DaoTurnoPaciente dao = new DaoTurnoPaciente();
            int r = dao.CancelarTurno(idTurno);

            switch (r)
            {
                case 1:
                    return "OK";
                case -1:
                    return "El turno no existe.";
                case -2:
                    return "El turno ya estaba cancelado.";
                default:
                    return "Error desconocido al cancelar.";
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Turno
    {
        private int _idTurno;
        private DateTime _fechaTurno;
        private int _horaTurno;
        private int _idPaciente;
        private int _idMedico;
        private int _idEspecialidad;
        private int _estado;
        private string _observaciones;
        public Turno()
        {
        }
        public Turno(int idTurno, DateTime fechaTurno, int horaTurno, int idPaciente, int idMedico, int idEspecialidad, int estado, string observaciones)
        {
            _idTurno = idTurno;
            _fechaTurno = fechaTurno;
            _horaTurno = horaTurno;
            _idPaciente = idPaciente;
            _idMedico = idMedico;
            _idEspecialidad = idEspecialidad;
            _estado = estado;
            _observaciones = observaciones;
        }
        public int idTurno
        {
            get { return _idTurno; }
            set { _idTurno = value; }
        }
        public DateTime fechaTurno
        {
            get { return _fechaTurno; }
            set { _fechaTurno = value; }
        }
        public int horaTurno
        {
            get { return _horaTurno; }
            set { _horaTurno = value; }
        }
        public int idPaciente
        {
            get { return _idPaciente; }
            set { _idPaciente = value; }
        }
        public int idProfesional
        {
            get { return _idMedico; }
            set { _idMedico = value; }
        }
        public int idEspecialidad
        {
            get { return _idEspecialidad; }
            set { _idEspecialidad = value; }
        }
        public int estado
        {
            get { return _estado; }
            set { _estado = value; }
        }

        public string observaciones
        {
            get { return _observaciones; }
            set { _observaciones = value; }
        }
    }
}

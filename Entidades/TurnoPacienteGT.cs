using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class TurnoPacienteGT
    {
        public int ID_Turno { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan Hora { get; set; }
        public string Profesional { get; set; }
        public string Especialidad { get; set; }
        public string Estado { get; set; }
    }
}

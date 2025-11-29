using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class TurnoInsert
    {
        public int ID_Turno { get; set; }
        public int ID_Paciente { get; set; }
        public int ID_Medico { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan Hora { get; set; }
        public int ID_Estado { get; set; }
        public string Observaciones { get; set; }
    }
}

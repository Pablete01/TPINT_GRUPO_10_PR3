using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class JornadaMedico
    {
        public int ID_Jornada { get; set; }
        public int ID_Medico { get; set; }
        public int DiaSemana { get; set; }
        public TimeSpan HoraEntrada { get; set; }
        public TimeSpan HoraSalida { get; set; }
        public int Duracion { get; set; }
        public bool Estado { get; set; }

        public JornadaMedico() { }
    }
}

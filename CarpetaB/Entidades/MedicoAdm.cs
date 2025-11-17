using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class MedicoAdm
    {
        // Datos de Persona
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string DNI { get; set; }
        public string Sexo { get; set; }
        public string Nacionalidad { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public int ID_Localidad { get; set; }

        // Datos de Usuario
        public string Email { get; set; }
        public string Contrasena { get; set; }   // ← será igual al DNI

        // Datos de Médico
        public int ID_Especialidad { get; set; }
        public string Legajo { get; set; }       // ← se completa con M + ID_Persona
    }
}

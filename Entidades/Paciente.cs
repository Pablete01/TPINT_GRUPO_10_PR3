using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Paciente
    {
        private int _idPaciente;
        private string _nombre;
        private string _apellido;
        private int _dni;
        private string _sexo;
        private string _nacionalidad;
        private DateTime _fechaNacimiento;
        private int _telefono;
        private string _direccion;
        private int _Localidad;
        private int _Provincia;
        private string _Email;
        private int _perfil;
        private int _estado;


        public Paciente()
        {

        }

        public Paciente(int idPaciente, int DNI, string nombre, string apellido, string sexo, string nacionalidad, DateTime fechaNacimiento, int telefono, string direccion, int localidad, int provincia, string email, int perfil, int estado)
        {
            _idPaciente = idPaciente;
            _dni = DNI;
            _nombre = nombre;
            _apellido = apellido;
            _sexo = sexo;
            _nacionalidad = nacionalidad;
            _fechaNacimiento = fechaNacimiento;
            _telefono = telefono;
            _direccion = direccion;
            _Localidad = localidad;
            _Provincia = provincia;
            _Email = email;
            _perfil = perfil;
            _estado = estado;
        }
        public int idPaciente
        {
            get { return _idPaciente; }
            set { _idPaciente = value; }
        }
        public string nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        public string apellido
        {
            get { return _apellido; }
            set { _apellido = value; }
        }
        public int dni
        {
            get { return _dni; }
            set { _dni = value; }
        }
        public string sexo
        {
            get { return _sexo; }
            set { _sexo = value; }
        }
        public string nacionalidad
        {
            get { return _nacionalidad; }
            set { _nacionalidad = value; }
        }
        public DateTime fechaNacimiento
        {
            get { return _fechaNacimiento; }
            set { _fechaNacimiento = value; }
        }
        public int telefono
        {
            get { return _telefono; }
            set { _telefono = value; }
        }
        public string direccion
        {
            get { return _direccion; }
            set { _direccion = value; }
        }
        public int localidad
        {
            get { return _Localidad; }
            set { _Localidad = value; }
        }

        public int provincia
        {
            get { return _Provincia; }
            set { _Provincia = value; }
        }
        public string email
        {
            get { return _Email; }
            set { _Email = value; }
        }
        public int perfil
        {
            get { return _perfil; }
            set { _perfil = value; }
        }
        public int estado
        {
            get { return _estado; }
            set { _estado = value; }
        }
    }
 }

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Negocio
{
    public class NegocioPacientes
    {
        DaoPacientes dao = new DaoPacientes();

        public DataTable cargarGrillaPacientes()
        {
            DataTable dt = dao.GetTablaPacientes();
            return dt;
        }



        public int InsertarPaciente(Entidades.Paciente paciente, out string mensaje)
        {
            DaoPacientes daoPacientes = new DaoPacientes();
            int filasAfectadas = daoPacientes.InsertarPaciente(paciente, out mensaje);
            return filasAfectadas;
        }

        public int ActualizarPaciente(Entidades.Paciente paciente)
        {
            DaoPacientes daoPacientes = new DaoPacientes();
            int filasAfectadas = daoPacientes.ActualizarPaciente(paciente);
            return filasAfectadas;
        }

        public bool EliminarPaciente(int idPaciente)
        {
            DaoPacientes daoPacientes = new DaoPacientes();
            bool filasAfectadas = daoPacientes.EliminarPaciente(idPaciente);
            if(!filasAfectadas)
            {
                return false; 
            }
            return true; 
        }

        public DataTable BuscarPacientes(string valor)
        {
            return dao.BuscarPacientes(valor);
        }

        public int GetIDPacientePorDNI(string DNI)
        {
            return dao.ObtenerIDPacientePorDNI(DNI);
        }

        public DataTable ObtenerPacientesConParametros(string texto, string orden)
        {
            return dao.ObtenerPacientesConParametros(texto, orden);
        }

        //public int cargarGrillaPacientesxMedico(int idMedico)
        //{
        //    return dao.cargarGrillaPacientesxMedico(idMedico);
        //}
    }
}

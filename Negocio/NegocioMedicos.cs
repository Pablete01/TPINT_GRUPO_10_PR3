using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using Dao;
using Datos;
using Entidades;

namespace Negocio
{
    public class NegocioMedicos
    {
        DaoMedicos dao = new DaoMedicos();

        public DataTable cargarGrillaMedicos()
        {
            DataTable dt = dao.GetTablaMedicos();
            return dt;
        }

        public DataTable BuscarMedicos(string texto)
        {
            return dao.BuscarMedicos(texto);
        }

        public DataTable GetEspecialidades()
        {
            DaoMedicos dao = new DaoMedicos();
            return dao.GetTablaEspecialidades();
        }

        public DataTable GetProvincias()
        {
            DaoMedicos dao = new DaoMedicos();
            return dao.GetTablaProvincias();
        }

        public DataTable GetLocalidadesPorProvincia(int idProvincia)
        {
            DaoMedicos dao = new DaoMedicos();
            return dao.GetTablaLocalidadesPorProvincia(idProvincia);
        }

        public int AgregarMedico(MedicoAdm m)
        {
            // Cálculo de valores automáticos

            // 1) Contrasena = DNI
            //m.Contrasena = m.DNI;

            // 2) Legajo inicial (lo completará el SP con M10 + ID_Persona)
            m.Legajo = "TEMP";

            DaoMedicos dm = new DaoMedicos();
            return dm.AgregarMedico(m);
        }

        public bool ModificarMedico(MedicoAdm m)
        {
            DaoMedicos dao = new DaoMedicos();
            return dao.ModificarMedico(m);  // Delego al DAO
        }

        public bool BajaLogicaMedico(int idMedico)
        {
            DaoMedicos dao = new DaoMedicos();
            return dao.BajaLogicaMedico(idMedico);
        }

        public bool AgregarPersona(MedicoAdm m)
        {
            DaoMedicos datos = new DaoMedicos();
            return datos.InsertarPersona(m);
        }

        public bool AgregarPersonaYUsuario(MedicoAdm m)
        {
            DaoMedicos dat = new DaoMedicos();
            return dat.InsertarPersonaYUsuario(m);
        }

        public bool RegistrarMedico(MedicoAdm m)
        {
            DaoMedicos datos = new DaoMedicos();
            return datos.AgregarMedicoCompleto(m);
        }

        public MedicoAdm ObtenerMedicoPorID(int id)
        {
            DaoMedicos datos = new DaoMedicos();
            return datos.MedicoPorID(id);
        }

        public DataTable ObtenerMedicoPorEspecialidad(int idEspecialidad)
        {
            DaoMedicos datos = new DaoMedicos();
            return datos.MedicoPorEspecialidad (idEspecialidad);
        }


    }




}


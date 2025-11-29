using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Entidades;

namespace Negocio
{
    public class NegocioTurnos
    {
        DaoTurnos dao = new DaoTurnos();

        public DataTable CargarGrillaTurnos()
        {
            DataTable dt = dao.GetTablaTurnos();
            return dt;
        }


        public DataTable ObtenerTurnosMedicoFecha(int idMedico, DateTime fecha)
        {
            DataTable dt = dao.GetTurnosMedicoFecha(idMedico, fecha);

            foreach (DataRow row in dt.Rows)
            {
                System.Diagnostics.Debug.WriteLine(
                    "Hora: " + row["Hora"].ToString()
                );
            }
            return dt;
        }

        public int AgregarTurno(Turno t)
        {
            return dao.AgregarTurno(t);
        }

        public DataTable ObtenerHorarioMedico(int idMedico)
        {
            return dao.GetHorarioMedico(idMedico);
        }

        
    }
}

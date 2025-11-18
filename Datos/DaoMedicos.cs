using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dao;
using Entidades;

namespace Datos
{
    public class DaoMedicos
    {
        AccesoDatos dm = new AccesoDatos();

        public int AgregarMedico(MedicoAdm m)
        {
            SqlConnection cn = dm.ObtenerConexion();
            SqlCommand cmd = new SqlCommand("SP_AgregarMedicoGM", cn);
            cmd.CommandType = CommandType.StoredProcedure;

            // Parámetros del SP
            cmd.Parameters.AddWithValue("@Nombre", m.Nombre);
            cmd.Parameters.AddWithValue("@Apellido", m.Apellido);
            cmd.Parameters.AddWithValue("@DNI", m.DNI);
            cmd.Parameters.AddWithValue("@Sexo", m.Sexo);
            cmd.Parameters.AddWithValue("@Nacionalidad", m.Nacionalidad);
            cmd.Parameters.AddWithValue("@FechaNacimiento", m.FechaNacimiento);
            cmd.Parameters.AddWithValue("@Telefono", m.Telefono);
            cmd.Parameters.AddWithValue("@Direccion", m.Direccion);
            cmd.Parameters.AddWithValue("@ID_Localidad", m.ID_Localidad);
            cmd.Parameters.AddWithValue("@Email", m.Email);
            cmd.Parameters.AddWithValue("@Contrasena", m.Contrasena);
            cmd.Parameters.AddWithValue("@ID_Especialidad", m.ID_Especialidad);
            cmd.Parameters.AddWithValue("@Legajo", m.Legajo);  // aunque no se usa en el SP

            cn.Open();
            object result = cmd.ExecuteScalar();
            cn.Close();

            return (result != null) ? Convert.ToInt32(result) : -1;
        }

        public bool InsertarPersona(MedicoAdm m)
        {
            SqlConnection cn = dm.ObtenerConexion();
            SqlCommand cmd = new SqlCommand("SP_AgregarSoloPersona", cn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@DNI", m.DNI);
            cmd.Parameters.AddWithValue("@Nombre", m.Nombre);
            cmd.Parameters.AddWithValue("@Apellido", m.Apellido);
            cmd.Parameters.AddWithValue("@Sexo", m.Sexo);
            cmd.Parameters.AddWithValue("@Nacionalidad", m.Nacionalidad);
            cmd.Parameters.AddWithValue("@FechaNacimiento", m.FechaNacimiento);
            cmd.Parameters.AddWithValue("@Telefono", m.Telefono);
            cmd.Parameters.AddWithValue("@Direccion", m.Direccion);
            cmd.Parameters.AddWithValue("@ID_Localidad", m.ID_Localidad);

            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();

            return true;
        }

        public bool InsertarPersonaYUsuario(MedicoAdm m)
        {
            SqlConnection cn = dm.ObtenerConexion();
            SqlCommand cmd = new SqlCommand("SP_InsertarPersonaYUsuario", cn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@DNI", m.DNI);
            cmd.Parameters.AddWithValue("@Nombre", m.Nombre);
            cmd.Parameters.AddWithValue("@Apellido", m.Apellido);
            cmd.Parameters.AddWithValue("@Sexo", m.Sexo);
            cmd.Parameters.AddWithValue("@Nacionalidad", m.Nacionalidad);
            cmd.Parameters.AddWithValue("@FechaNacimiento", m.FechaNacimiento);
            cmd.Parameters.AddWithValue("@Telefono", m.Telefono);
            cmd.Parameters.AddWithValue("@Direccion", m.Direccion);
            cmd.Parameters.AddWithValue("@ID_Localidad", m.ID_Localidad);
            cmd.Parameters.AddWithValue("@Email", m.Email);
            cmd.Parameters.AddWithValue("@Contrasena", m.Contrasena);

            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            bool ok = false;

            if (dr.Read())
            {
                int idPersona = Convert.ToInt32(dr["ID_PersonaCreado"]);
                int idUsuario = Convert.ToInt32(dr["ID_UsuarioCreado"]);

                ok = (idPersona > 0 && idUsuario > 0);
            }

            cn.Close();
            return ok;
        }


        public bool AgregarMedicoCompleto(MedicoAdm m)
        {
            SqlConnection cn = dm.ObtenerConexion();
            SqlCommand cmd = new SqlCommand("SP_AgregarMedicoCompleto", cn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@DNI", m.DNI);
            cmd.Parameters.AddWithValue("@Nombre", m.Nombre);
            cmd.Parameters.AddWithValue("@Apellido", m.Apellido);
            cmd.Parameters.AddWithValue("@Sexo", m.Sexo);
            cmd.Parameters.AddWithValue("@Nacionalidad", m.Nacionalidad);
            cmd.Parameters.AddWithValue("@FechaNacimiento", m.FechaNacimiento);
            cmd.Parameters.AddWithValue("@Telefono", m.Telefono);
            cmd.Parameters.AddWithValue("@Direccion", m.Direccion);
            cmd.Parameters.AddWithValue("@ID_Localidad", m.ID_Localidad);
            cmd.Parameters.AddWithValue("@Email", m.Email);
            cmd.Parameters.AddWithValue("@Contrasena", m.Contrasena);
            cmd.Parameters.AddWithValue("@ID_Especialidad", m.ID_Especialidad);

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                int resultado = Convert.ToInt32(dr["Resultado"]);
                return resultado == 1;
            }

            return false;

        }

        public bool ModificarMedico(MedicoAdm m)
        {
            try
            {
                SqlConnection cn = dm.ObtenerConexion();
                SqlCommand cmd = new SqlCommand("SP_ModificarMedico", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ID_Medico", m.ID_Medico);
                cmd.Parameters.AddWithValue("@Nombre", m.Nombre);
                cmd.Parameters.AddWithValue("@Apellido", m.Apellido);
                cmd.Parameters.AddWithValue("@DNI", m.DNI);
                cmd.Parameters.AddWithValue("@Sexo", m.Sexo);
                cmd.Parameters.AddWithValue("@Nacionalidad", m.Nacionalidad);
                cmd.Parameters.AddWithValue("@FechaNacimiento", m.FechaNacimiento);
                cmd.Parameters.AddWithValue("@Telefono", m.Telefono);
                cmd.Parameters.AddWithValue("@Direccion", m.Direccion);
                cmd.Parameters.AddWithValue("@ID_Localidad", m.ID_Localidad);
                cmd.Parameters.AddWithValue("@Email", m.Email);

              //  cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al modificar médico: " + ex.Message, ex);
            }
        }



        public DataTable GetTablaMedicos()
        {
            string consulta = "SP_ListarMedicosParaPersAdmin";
            return dm.ObtenerTabla("Medicos", consulta);
        }

        public DataTable BuscarMedicos(string texto)
        {
            AccesoDatos ad = new AccesoDatos();

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@texto", texto)
            };

            return ad.ObtenerTablaSP("Medicos", "SP_BuscarMedicosGM", parametros);
        }

        public DataTable GetTablaEspecialidades()
        {
            AccesoDatos ad = new AccesoDatos();
            return ad.ObtenerTabla("Especialidad", "sp_GetEspecialidades");
        }

        public DataTable GetTablaProvincias()
        {
            AccesoDatos ad = new AccesoDatos();
            return ad.ObtenerTabla("Provincias", "sp_GetProvincias");
        }

        public DataTable GetTablaLocalidadesPorProvincia(int idProvincia)
        {
            AccesoDatos ad = new AccesoDatos();
            SqlParameter[] parametros = new SqlParameter[]
            {
        new SqlParameter("@IdProvincia", idProvincia)
            };
            return ad.ObtenerTabla("Localidad", "sp_GetLocalidadesPorProvincia");
        }

        public MedicoAdm MedicoPorID(int id)
        {

            SqlConnection cn = dm.ObtenerConexion();
            SqlCommand cmd = new SqlCommand("SP_ObtenerMedicoCompletoPorID", cn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ID_Medico", id);

         //   cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            MedicoAdm med = null;

            if (dr.Read())
            {
                med = new MedicoAdm();
                med.ID_Medico = Convert.ToInt32(dr["ID_Medico"]);
                med.ID_Persona = Convert.ToInt32(dr["ID_Persona"]);
                med.Nombre = dr["Nombre"].ToString();
                med.Apellido = dr["Apellido"].ToString();
                med.DNI = dr["DNI"].ToString();
                med.Contrasena = dr["Contrasena"].ToString();  // = DNI
                med.ID_Especialidad = Convert.ToInt32(dr["ID_Especialidad"]);
                med.Email = dr["Email"].ToString();
                med.Telefono = dr["Telefono"].ToString();
                med.Direccion = dr["Direccion"].ToString();
                med.Nacionalidad = dr["Nacionalidad"].ToString();
                med.Sexo = dr["Sexo"].ToString();
                med.FechaNacimiento = Convert.ToDateTime(dr["FechaNacimiento"]);
                med.ID_Localidad = Convert.ToInt32(dr["ID_Localidad"]);
                //med.ID_Provincia = Convert.ToInt32(dr["ID_Provincia"]);
            }

            dr.Close();
            return med;

        }

    }
}

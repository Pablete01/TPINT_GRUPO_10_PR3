using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data;
using System.Data.SqlClient;

namespace Dao
{
  
    public class UsuarioDao
    {
        AccesoDatos ds = new AccesoDatos();

        public Usuario ValidarUsuario(string usuario, string contrasena)
        {
            SqlConnection conexion = ds.ObtenerConexion();
       //     conexion.Open();
            string consulta = @"
                    SELECT 
                        u.ID_Usuario,
                        u.Email,
                        u.Contrasena,
                        u.Estado,
                        p.ID_Perfil,
                        p.NombrePerfil
                    FROM Usuarios u
                    INNER JOIN Perfil p ON u.ID_Perfil = p.ID_Perfil
                    WHERE u.Email = @Email AND u.Contrasena = @Contrasena";

            SqlCommand comando = new SqlCommand(consulta, conexion);
               comando.Parameters.AddWithValue("@Email", usuario);
               comando.Parameters.AddWithValue("@Contrasena", contrasena);
               SqlDataReader dr = comando.ExecuteReader();

               if (dr.Read())
                {
                   return new Usuario
                     {
                       idUsuario = Convert.ToInt32(dr["ID_Usuario"]),
                       email = dr["Email"].ToString(),
                       contrasena = dr["Contrasena"].ToString(),
                       estado = Convert.ToBoolean(dr["Estado"]),
                       idPerfil = Convert.ToInt32(dr["ID_Perfil"]),
                       nombrePerfil = dr["NombrePerfil"].ToString()
                   };
                }
            conexion.Close();
                    
           
            return null;
        }

    }
}

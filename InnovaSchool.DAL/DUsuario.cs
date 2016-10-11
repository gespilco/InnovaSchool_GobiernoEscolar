using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using InnovaSchool.Entity;

namespace InnovaSchool.DAL
{
    public class DUsuario
    {
        SqlConnection cn = new SqlConnection(ConexionUtil.Get_Connection());

        public EUsuario VerificarUsuario_DAL(EUsuario EUsuario)
        {
            EUsuario retval = null;
            cn.Open();
            using (SqlCommand cmd = new SqlCommand("SP_GE_VerificarUsuario", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Usuario", EUsuario.Usuario));
                cmd.Parameters.Add(new SqlParameter("@UPassword", EUsuario.UPassword));
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    var result = reader.MapToList<EUsuario>();
                    retval = result.FirstOrDefault();

                    //if (reader.Read())
                    //{
                    //    retval = new EUsuario()
                    //    {
                    //        IdUsuario = int.Parse(reader["IdUsuario"].ToString()),
                    //        Usuario = reader["Usuario"].ToString(),
                    //        Rol = reader["Rol"].ToString()
                    //    };
                    //}
                }
            }
            cn.Close();
            return retval;
        }

        public int RegistrarUsuario_DAL(EUsuario objEN)
        {            
            try
            {
                SqlCommand cmd = new SqlCommand("SP_GE_RegistrarUsuario", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@IdUsuario", objEN.IdUsuario);
                cmd.Parameters.AddWithValue("@Usuario", objEN.Usuario);
                cmd.Parameters.AddWithValue("@Email", objEN.Email);
                cmd.Parameters.AddWithValue("@UPassword", objEN.UPassword);
                cmd.Parameters.AddWithValue("@IdPregunta", objEN.IdPregunta);
                cmd.Parameters.AddWithValue("@Respuesta", objEN.Respuesta);
                cmd.Parameters.AddWithValue("@Estado", objEN.Estado);
                cmd.Parameters.AddWithValue("@UsuCreacion", objEN.UsuCreacion);
                //cmd.Parameters.AddWithValue("@FecCreacion", objEN.FecCreacion);
                //cmd.Parameters.AddWithValue("@UsuModificacion", objEN.UsuModificacion);
                //cmd.Parameters.AddWithValue("@FecModificacion", objEN.FecModificacion);
                cmd.Parameters.AddParameter("@idRol", objEN.idRol);
                cmd.Parameters.AddParameter("@idPersona", objEN.idPersona);

                cn.Open();
                var result = cmd.ExecuteScalar();
                cn.Close();

                return int.Parse(result.ToString());
            }
            catch (Exception)
            {
                if (cn.State == ConnectionState.Open)
                    cn.Close();
                throw;
            }
        }

    }
}

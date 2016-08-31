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

        public EUsuario VerificarUsuario(EUsuario EUsuario)
        {
            EUsuario retval = null;
            cn.Open();
            using (SqlCommand cmd = new SqlCommand("SP_VerificarUsuario", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Usuario", EUsuario.Usuario));
                cmd.Parameters.Add(new SqlParameter("@UPassword", EUsuario.UPassword));
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        retval = new EUsuario()
                        {
                            IdUsuario = int.Parse(reader["IdUsuario"].ToString()),
                            Usuario = reader["Usuario"].ToString()
                        };
                    }
                }
            }
            cn.Close();
            return retval;
        }

        public List<EUsuario> Login(EUsuario EUsuario) 
        {
            List<EUsuario> retval = new List<EUsuario>();         
            cn.Open();
            using (SqlCommand cmd = new SqlCommand("SP_VerificarUsuario", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Usuario", EUsuario.Usuario));
                cmd.Parameters.Add(new SqlParameter("@UPassword", EUsuario.UPassword));
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        retval.Add(new EUsuario
                        {
                            IdUsuario = int.Parse(reader["IdUsuario"].ToString()),
                            Usuario = reader["Usuario"].ToString()
                        });
                    }
                }
                cn.Close();
            }
            return retval;
        }

    }
}

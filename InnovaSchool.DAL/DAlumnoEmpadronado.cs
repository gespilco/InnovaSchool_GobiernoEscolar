using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InnovaSchool.Entity;
using System.Data;

namespace InnovaSchool.DAL  ///DConexion.cn_SGE_BD
{
    public class DAlumnoEmpadronado
    {
        static SqlConnection cn = new SqlConnection(ConexionUtil.Get_Connection());

        public DataTable ListarAlumnosEmpadronados_DAL(EAlumnoEmpadronado objEN)
        {
            SqlCommand cmd = new SqlCommand("SP_ListarAlumnosEmpadronados", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idaluemp", objEN.idaluemp);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable tbl = new DataTable();
            da.Fill(tbl);
            return tbl;
        }


        public int RegistrarAlumnoEmpadronado_DAL(EAlumnoEmpadronado objEN)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_RegistrarAlumnoEmpadronado", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idaluemp", objEN.idaluemp);
                cmd.Parameters.AddWithValue("@codaluemp", objEN.codaluemp);
                cmd.Parameters.AddWithValue("@estadovotador", objEN.estadovotador);
                cmd.Parameters.AddWithValue("@anioescolar", objEN.añoescolar);
               

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                cn.Open();
                int n = cmd.ExecuteNonQuery();
                cn.Close();
                return n;
            }
            catch (Exception)
            {
                throw;
            }

        }
        public int ActualizarAlumnoEmpadronado_DAL(EAlumnoEmpadronado objEN)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_ActualizarAlumnoEmpadronado", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idaluemp", objEN.idaluemp);
                cmd.Parameters.AddWithValue("@codaluemp", objEN.codaluemp);
                cmd.Parameters.AddWithValue("@estadovotador", objEN.estadovotador);
                cmd.Parameters.AddWithValue("@anioescolar", objEN.añoescolar);


                SqlDataAdapter da = new SqlDataAdapter(cmd);
                cn.Open();
                int n = cmd.ExecuteNonQuery();
                cn.Close();
                return n;
            }
            catch (Exception)
            {
                throw;
            }

        }
        public int EliminarAlumnoEmpadronadp_DAL(EAlumnoEmpadronado objEN)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_EliminarAlumnoEmpadronado", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idaluemp", objEN.idaluemp);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                cn.Open();
                int n = cmd.ExecuteNonQuery();
                cn.Close();
                return n;
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}

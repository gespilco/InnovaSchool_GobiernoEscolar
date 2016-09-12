using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InnovaSchool.Entity;
using System.Data;

namespace InnovaSchool.DAL
{
    public class DCargo
    {
     
        static SqlConnection cn = new SqlConnection(ConexionUtil.Get_Connection());

        public List<ECargo> ListarCargos_DAL(int anoAcademico)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_GE_ListarCargos", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@anoAcademico", anoAcademico);
                cn.Open();
                SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);
                var result = drd.MapToList<ECargo>();
                cn.Close();
                drd.Close();

                return result.ToList();
            }
            catch (Exception ex)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }

                throw;
            }            
        }

        //public int RegistrarCargo_DAL(ECargo objEN)
        //{
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand("SP_GE_RegistrarCargo", cn);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@CargoID", objEN.CargoID);
        //        cmd.Parameters.AddWithValue("@TipoCargo", objEN.TipoCargo);
        //        cmd.Parameters.AddWithValue("@AnioAcademico", objEN.AñoAcadmico);
                
               

        //        SqlDataAdapter da = new SqlDataAdapter(cmd);
        //        cn.Open();
        //        int n = cmd.ExecuteNonQuery();
        //        cn.Close();
        //        return n;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }

        //}
        //public int ActualizarCargo_DAL(ECargo objEN)
        //{
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand("SP_GE_ActualizarCargo", cn);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@CargoID", objEN.CargoID);
        //        cmd.Parameters.AddWithValue("@TipoCargo", objEN.TipoCargo);
        //        cmd.Parameters.AddWithValue("@AnioAcademico", objEN.AñoAcadmico);


        //        SqlDataAdapter da = new SqlDataAdapter(cmd);
        //        cn.Open();
        //        int n = cmd.ExecuteNonQuery();
        //        cn.Close();
        //        return n;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }

        //}
        //public int EliminarCargo_DAL(ECargo objEN)
        //{
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand("SP_GE_EliminarCargo", cn);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@CargoID", objEN.CargoID);
        //        SqlDataAdapter da = new SqlDataAdapter(cmd);
        //        cn.Open();
        //        int n = cmd.ExecuteNonQuery();
        //        cn.Close();
        //        return n;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }

        //}
    }
    
}

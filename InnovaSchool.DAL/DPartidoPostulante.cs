using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InnovaSchool.Entity;
using System.Data;
using InnovaSchool.Entity.Result;

namespace InnovaSchool.DAL
{
    public class DPartidoPostulante
    {
        static SqlConnection cn = new SqlConnection(ConexionUtil.Get_Connection());

        public List<SP_ListarPartidoPostulante_Result> ListarPartidoPostulante_DAL()
        {
            SqlCommand cmd = new SqlCommand("SP_ListarPartidoPostulante", cn);            
            cmd.CommandType = CommandType.StoredProcedure;

            cn.Open();
            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);
            List<SP_ListarPartidoPostulante_Result> list = drd.MapToList<SP_ListarPartidoPostulante_Result>();
            drd.Close();

            cn.Close();

            return list;
        }

        public int RegistrarPartidoPostulante_DAL(EPartidoPostulante objEN)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_RegistrarPartido", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PartidoID", objEN.PartidoID);
                cmd.Parameters.AddWithValue("@Nombre", objEN.Nombre);
                cmd.Parameters.AddWithValue("@Estado", objEN.Estado);
                cmd.Parameters.AddWithValue("@Logo", objEN.Logo);
                cmd.Parameters.AddWithValue("@FechaReg", objEN.FechaReg);
                cmd.Parameters.AddWithValue("@idvoto", objEN.idvoto);
                cmd.Parameters.AddWithValue("@idplan", objEN.idplan);
              
                //SqlDataAdapter da = new SqlDataAdapter(cmd);
                //cn.Open();
                //int n = cmd.ExecuteNonQuery();
                //cn.Close();
                //return n;

                cn.Open();
                int Id = (int)cmd.ExecuteScalar();
                cn.Close();
                return Id;
            }
            catch (Exception)
            {
                throw;
            }

        }
        public int ActualizarPartidoPostulante_DAL(EPartidoPostulante objEN)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_ActualizarPartido", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PartidoID", objEN.PartidoID);
                cmd.Parameters.AddWithValue("@Nombre", objEN.Nombre);
                cmd.Parameters.AddWithValue("@Estado", objEN.Estado);
                cmd.Parameters.AddWithValue("@FechaReg", objEN.FechaReg);
                cmd.Parameters.AddWithValue("@idvoto", objEN.idvoto);
                cmd.Parameters.AddWithValue("@idplan", objEN.idplan);
            

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
        public int EliminarPartidoPostulante_DAL(EPartidoPostulante objEN)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_EliminarPartido", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PartidoID", objEN.PartidoID);
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

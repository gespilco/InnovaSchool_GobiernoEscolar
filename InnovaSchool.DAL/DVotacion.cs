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
    public class DVotacion
    {
        static SqlConnection cn = new SqlConnection(ConexionUtil.Get_Connection());

        public bool RegistrarVotacion_DAL(int idAlumno, int? idPartido)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_GE_RegistrarVotacion", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idAlumno", idAlumno);
                cmd.Parameters.AddParameter("@idPartido", idPartido);                                

                cn.Open();
                var result = cmd.ExecuteNonQuery();
                cn.Close();
                return result > 0;
            }
            catch (Exception)
            {
                if (cn.State == ConnectionState.Open)
                    cn.Close();
                return false;
            }
        }

        public List<SP_GE_ListarPartidoPostulante_Result> ListarPartidosVotacion_DAL()
        {
            SqlCommand cmd = new SqlCommand("SP_GE_ListarPartidosVotacion", cn);
            cmd.CommandType = CommandType.StoredProcedure;

            cn.Open();
            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);
            List<SP_GE_ListarPartidoPostulante_Result> list = drd.MapToList<SP_GE_ListarPartidoPostulante_Result>();
            drd.Close();

            cn.Close();

            return list;
        }

    }
}

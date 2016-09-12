using InnovaSchool.Entity.Result;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovaSchool.DAL
{
    public class DResultados
    {
        static SqlConnection cn = new SqlConnection(ConexionUtil.Get_Connection());

        public List<SP_GE_ListarResultadosVotos_Result> ListarResultadosVotos_DAL(int anyo)
        {
            SqlCommand cmd = new SqlCommand("SP_GE_ListarResultadosVotos", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@anyo", anyo);

            cn.Open();
            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);
            var result = drd.MapToList<SP_GE_ListarResultadosVotos_Result>();
            drd.Close();

            cn.Close();

            return result;
        }

        public SP_GE_ListarConteoVotos_Result ListarConteoVotos_DAL(int anyo)
        {
            SqlCommand cmd = new SqlCommand("SP_GE_ListarConteoVotos", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@anyo", anyo);

            cn.Open();
            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);
            var result = drd.MapToList<SP_GE_ListarConteoVotos_Result>();
            drd.Close();

            cn.Close();

            return result.FirstOrDefault();
        }

    }
}

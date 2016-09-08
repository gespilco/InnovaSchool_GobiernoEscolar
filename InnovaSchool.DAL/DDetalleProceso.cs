using InnovaSchool.Entity;
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
    public class DDetalleProceso
    {
        static SqlConnection cn = new SqlConnection(ConexionUtil.Get_Connection());

        public EDetalleProceso ObtenerProceso_DAL(string proceso)
        {
            SqlCommand cmd = new SqlCommand("SP_GE_ObtenerProceso", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@proceso", proceso);            

            cn.Open();
            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);
            var result = drd.MapToList<EDetalleProceso>();
            drd.Close();
            cn.Close();

            return result.FirstOrDefault();
        }
    }
}

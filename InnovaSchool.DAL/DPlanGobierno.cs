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
    public class DPlanGobierno
    {
        static SqlConnection cn = new SqlConnection(ConexionUtil.Get_Connection());

        public EPlanGobierno SP_PlanGobiernoPartido_DAL(int idPartido)
        {
            SqlCommand cmd = new SqlCommand("SP_GE_PlanGobiernoPartido", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idPartido", idPartido);

            cn.Open();
            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);
            var list = drd.MapToList<EPlanGobierno>();
            drd.Close();
            cn.Close();

            return list.FirstOrDefault();
        }

        public List<SP_GE_ListarActividadesPlanGobierno_Result> SP_ListarActividadesPlanGobierno_DAL(int idPlan)
        {
            SqlCommand cmd = new SqlCommand("SP_GE_ListarActividadesPlanGobierno", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idPlan", idPlan);

            cn.Open();
            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);
            List<SP_GE_ListarActividadesPlanGobierno_Result> list = drd.MapToList<SP_GE_ListarActividadesPlanGobierno_Result>();
            drd.Close();
            cn.Close();

            return list.ToList();
        }

        public List<SP_GE_ListarSubActividadesPlanGobierno_Result> SP_ListarSubActividadesPlanGobierno_DAL(int idActividad)
        {
            SqlCommand cmd = new SqlCommand("SP_GE_ListarSubActividadesPlanGobierno", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idActividad", idActividad);

            cn.Open();
            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);
            var list = drd.MapToList<SP_GE_ListarSubActividadesPlanGobierno_Result>();
            drd.Close();
            cn.Close();

            return list.ToList();
        }

        public List<SP_GE_ListarInstrumentosPlanGobierno_Result> SP_ListarInstrumentosPlanGobierno_DAL(int idPlan)
        {
            SqlCommand cmd = new SqlCommand("SP_GE_ListarInstrumentosPlanGobierno", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idPlan", idPlan);

            cn.Open();
            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);
            List<SP_GE_ListarInstrumentosPlanGobierno_Result> list = drd.MapToList<SP_GE_ListarInstrumentosPlanGobierno_Result>();
            drd.Close();
            cn.Close();

            return list.ToList();
        }

        public int SP_GuardarObservacion_DAL(EObservacion objEN, int idPlanGobierno)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_GE_PlanGobiernoGuardarObservacion", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddParameter("@Descripcion", objEN.Descripcion);
                cmd.Parameters.AddParameter("@NivelObservacion", objEN.NivelObservacion);
                cmd.Parameters.AddParameter("@idInstrumento", objEN.idInstrumento);
                cmd.Parameters.AddParameter("@idActividadPropuesta", objEN.idActividadPropuesta);
                cmd.Parameters.AddParameter("@idactPlan", objEN.idactPlan);
                cmd.Parameters.AddWithValue("@idPlanGobierno", idPlanGobierno);

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

        public List<EObservacion> SP_VerObservacionesDetalle_DAL(int id, string tipo)
        {
            SqlCommand cmd = new SqlCommand("SP_GE_PlanGobiernoVerObservacionesDetalle", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@tipo", tipo);

            cn.Open();
            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);
            List<EObservacion> list = drd.MapToList<EObservacion>();
            cn.Close();
            drd.Close();
            return list;
        }

        public bool SP_PlanGobiernoEliminarObservacion_DAL(int idObservacion)
        {
            SqlCommand cmd = new SqlCommand("SP_GE_PlanGobiernoEliminarObservacion", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idObservacion", idObservacion);            

            cn.Open();
            var result = cmd.ExecuteNonQuery();
            cn.Close();
            
            return result != 0;
        }

        public List<EObservacion> SP_VerTodasObservacionesPlan_DAL(int idPlan)
        {
            SqlCommand cmd = new SqlCommand("SP_GE_VerTodasObservacionesPlan", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idPlan", idPlan);            

            cn.Open();
            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);
            List<EObservacion> list = drd.MapToList<EObservacion>();
            cn.Close();
            drd.Close();
            return list;
        }

        public int SP_AprobarPlanGobierno_DAL(int idPlan)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_GE_AprobarPlanGobierno", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idPlan", idPlan);                

                cn.Open();
                var result = cmd.ExecuteNonQuery();
                cn.Close();
                return result;
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

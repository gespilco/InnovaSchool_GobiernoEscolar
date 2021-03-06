﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InnovaSchool.Entity;
using System.Data;
using InnovaSchool.Entity.Result;

namespace InnovaSchool.DAL  ///DConexion.cn_SGE_BD
{
    public class DAlumnoEmpadronado
    {
        static SqlConnection cn = new SqlConnection(ConexionUtil.Get_Connection());

        public List<SP_GE_ListarAlumnosPadronElectoral_Result> ListarAlumnosEmpadronados_DAL(int annio)
        {
            SqlCommand cmd = new SqlCommand("SP_GE_ListarAlumnosEmpadronados", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@annio", annio);

            cn.Open();
            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);
            List<SP_GE_ListarAlumnosPadronElectoral_Result> list = drd.MapToList<SP_GE_ListarAlumnosPadronElectoral_Result>();
            drd.Close();
            cn.Close();

            return list.ToList();
        }
        
        public List<SP_GE_ListarAlumnosPadronElectoral_Result> ListarAlumnosPadronElectoral_DAL(int annio)
        {
            SqlCommand cmd = new SqlCommand("SP_GE_ListarAlumnosPadronElectoral", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@annio", annio);

            cn.Open();
            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);
            List<SP_GE_ListarAlumnosPadronElectoral_Result> list = drd.MapToList<SP_GE_ListarAlumnosPadronElectoral_Result>();
            drd.Close();
            cn.Close();

            return list.ToList();
        }        

        public int RegistrarAlumnoPadronElectoral_DAL(EAlumnoEmpadronado objEN)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_GE_RegistrarAlumnoPadronElectoral", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@idalumnoempadronado", objEN.idalumnoempadronado);
                //cmd.Parameters.AddWithValue("@codalumnoempadronado", objEN.codalumnoempadronado);
                cmd.Parameters.AddWithValue("@estado", objEN.estado);
                cmd.Parameters.AddWithValue("@añoescolar", objEN.añoescolar);
                cmd.Parameters.AddWithValue("@idAlumno", objEN.idAlumno);
                cmd.Parameters.AddWithValue("@idProceso", objEN.idProceso);                

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

        public int GenerarCredencialAlumno_DAL(EAlumnoEmpadronado objEN)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_GE_GenerarCredencialAlumno", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idAlumno", objEN.idAlumno);
                cmd.Parameters.AddWithValue("@usuario", objEN.usuario);
                cmd.Parameters.AddWithValue("@claveAcceso", objEN.claveAcceso);
                
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

        public SP_GE_ObtenerCredencialesVotacion_Result ObtenerCredencialesVotacion_DAL(string usuario, string claveAcceso)
        {
            SqlCommand cmd = new SqlCommand("SP_GE_ObtenerCredencialesVotacion", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@usuario", usuario);
            cmd.Parameters.AddWithValue("@claveAcceso", claveAcceso);

            cn.Open();
            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);
            var result = drd.MapToList<SP_GE_ObtenerCredencialesVotacion_Result>();
            drd.Close();
            cn.Close();

            return result.FirstOrDefault();
        }
    }
}

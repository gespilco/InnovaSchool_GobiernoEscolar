﻿using InnovaSchool.Entity.Result;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace InnovaSchool.DAL
{
    public class DAlumno
    {
        static SqlConnection cn = new SqlConnection(ConexionUtil.Get_Connection());

        public SP_GE_ListarAlumnoById_Result ListarAlumno_DAL(int idAlumno)
        {
            SqlCommand cmd = new SqlCommand("SP_GE_ListarAlumnoById", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idAlumno", idAlumno);

            cn.Open();
            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);
            List<SP_GE_ListarAlumnoById_Result> list = drd.MapToList<SP_GE_ListarAlumnoById_Result>();
            drd.Close();
            cn.Close();

            return list.FirstOrDefault();
        }
    }
}

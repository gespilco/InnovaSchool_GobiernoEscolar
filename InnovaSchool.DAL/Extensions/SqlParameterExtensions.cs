using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovaSchool.DAL
{
    public static class SqlParameterExtensions
    {
        public static SqlParameter AddWithNullable<T>(this SqlParameterCollection parms, string parameterName, T? nullable) where T : struct
        {
            if (nullable.HasValue)
                return parms.AddWithValue(parameterName, nullable.Value);
            else
                return parms.AddWithValue(parameterName, DBNull.Value);
        }        
    }
}

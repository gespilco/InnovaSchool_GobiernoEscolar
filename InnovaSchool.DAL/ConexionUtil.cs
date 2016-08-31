using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Web;
using System.Linq;

namespace InnovaSchool.DAL
{
    class ConexionUtil
    {
        public static string Get_Connection()
        {
            return ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        }
    }
}

using InnovaSchool.Entity;
using System.Collections.Generic;
using System.Web;

namespace InnovaSchool.UserLayer
{
    public class SessionHelper
    {
        public static EUsuario Usuario
        {
            get
            {
                EUsuario user = (EUsuario)HttpContext.Current.Session["Usuario"];

                if (user == null)
                {
                    user = new EUsuario();
                }

                return user;
            }
            set
            {
                HttpContext.Current.Session["Usuario"] = value;
            }
        }

        public static List<string> Roles
        {
            get
            {
                List<string> roles = (List<string>)HttpContext.Current.Session["Roles"];
                if (roles == null)
                {
                    roles = new List<string>();
                }
                return roles;
            }
            set
            {
                HttpContext.Current.Session["Roles"] = value;
            }
        }

        public static bool IsInRole(string Rol)
        {
            bool authorize = Roles.Contains(Rol);

            return authorize;
        }
    }
}
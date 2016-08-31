using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InnovaSchool.Entity;

namespace InnovaSchool.UserLayer.MaterPage
{
    public partial class SiteInnovaSchool : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                EUsuario Usuario = (EUsuario)Session["Usuario"];
                lblUsuario.Text = Usuario.Usuario.ToString();
            }
            catch (Exception ex)
            {
                Response.Redirect("../Error/NoAccess.html");
            }
        }
    }
}
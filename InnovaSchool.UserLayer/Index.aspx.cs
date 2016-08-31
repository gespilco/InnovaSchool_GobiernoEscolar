using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InnovaSchool.UserLayer.Common;
using InnovaSchool.Entity;

namespace InnovaSchool.UserLayer
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblTitulo.Text = Constant.TituloInicio;
            lblSubTitulo.Text = Constant.SubtituloTituloInicio;
        }
    }
}
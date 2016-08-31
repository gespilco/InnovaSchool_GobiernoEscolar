using InnovaSchool.BL;
using InnovaSchool.Entity;
using InnovaSchool.UserLayer.Common;
using System;
namespace InnovaSchool.UserLayer
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Clear();
        }

        protected void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            Resources.Resources objResources = new Resources.Resources();
            EUsuario EUsuario = new EUsuario
            {
                Usuario = username.Text,
                UPassword = objResources.MD5Crypto(password.Text)
            };
            EUsuario UsuarioExistente;
            BUsuario BUsuario = new BUsuario();
            UsuarioExistente = BUsuario.VerificarUsuario(EUsuario);
            if (UsuarioExistente == null)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", "<script>$('#mensaje').html(GenerarMensaje('" + Constant.TituloErrorLogin + "','" + Constant.MensajeErrorLogin + "'))</script>");
                ClientScript.RegisterStartupScript(this.GetType(), "Show", "<script>myModalShow();</script>");
                objResources.LimpiarControles(this.Controls);
            }
            else
            {
                Session["Usuario"] = UsuarioExistente;
                Response.Redirect("Index.aspx");
            }
        }
    }
}
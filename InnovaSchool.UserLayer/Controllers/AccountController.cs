using InnovaSchool.BL;
using InnovaSchool.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InnovaSchool.UserLayer.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/Login
        public ActionResult Login(string ReturnUrl)
        {
            Session.Clear();
            ViewBag.ReturnUrl = ReturnUrl;
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password, string ReturnUrl)
        {
            //Resources.Resources objResources = new Resources.Resources();
            EUsuario EUsuario = new EUsuario
            {
                Usuario = username,
                UPassword = BOperaciones.MD5Crypto(password)
            };
            EUsuario UsuarioExistente;
            BUsuario BUsuario = new BUsuario();
            UsuarioExistente = BUsuario.VerificarUsuario(EUsuario);
            //UsuarioExistente = new EUsuario() { IdUsuario = 1, Usuario = "admin", Estado = 1 };
            if (UsuarioExistente == null)
            {                
                ViewBag.Mensaje = "Usuario y/o contraseña incorrecta(s).";
                return View();
            }
            else
            {
                SessionHelper.Usuario = UsuarioExistente;

                //Roles
                SessionHelper.Roles = new List<string>() { UsuarioExistente.Rol };

                if (ReturnUrl != null && ReturnUrl != string.Empty)
                {
                    return Redirect(Url.Content(ReturnUrl));
                }

                return RedirectToAction("Index", "Home");
            }
        }
	}
}
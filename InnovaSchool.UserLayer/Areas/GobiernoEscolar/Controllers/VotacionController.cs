using InnovaSchool.BL;
using InnovaSchool.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InnovaSchool.Entity.Result;

namespace InnovaSchool.UserLayer.Areas.GobiernoEscolar.Controllers
{
    public class VotacionController : Controller
    {
        
        //
        // GET: /GobiernoEscolar/Votacion/
        public ActionResult Index()
        {
            if (Session["UsuarioVotacion"] == null)
            {
                Response.Redirect("~/GobiernoEscolar/Votacion/Credenciales", true);
            }

            return View();
        }

        public JsonResult ListarPartidos()
        {
            BVotacion oBVotacion = new BVotacion();
            var model = oBVotacion.ListarPartidosVotacion_DAL();

            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Credenciales()
        {
            Session["UsuarioVotacion"] = null;
            return View();
        }

        [HttpPost]
        public ActionResult Credenciales(string usuario, string clave)
        {
            BDetalleProceso oBDetalleProceso = new BDetalleProceso();
            var proceso = oBDetalleProceso.ObtenerProcesoVigente_BL("Realizar Votaciones");

            if (proceso != null)
            {
                SP_GE_ObtenerCredencialesVotacion_Result UsuarioExistente;
                BAlumnoEmpadronado oBAlumnoEmpadronado = new BAlumnoEmpadronado();

                //Resources.Resources objResources = new Resources.Resources();
                UsuarioExistente = oBAlumnoEmpadronado.ObtenerCredencialesVotacion(usuario, BOperaciones.MD5Crypto(clave));
                if (UsuarioExistente == null)
                {
                    ViewBag.Mensaje = "Usuario y/o contraseña incorrectos";
                    //return View();
                }
                else
                {
                    if (UsuarioExistente.estado == "Registrado")
                    {
                        Session["UsuarioVotacion"] = UsuarioExistente;
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ViewBag.Mensaje = "Ud. ya realizó el proceso de votación";
                        //return View();
                    }
                }          
            }
            else
            {
                ViewBag.Mensaje = "El tiempo para realizar las votaciones ha concluido";              
            }

            return View();
            
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public JsonResult RegistrarVoto(int? idPartido)
        {
            bool result = false;
            string mensaje = "";

            var usuario = (SP_GE_ObtenerCredencialesVotacion_Result)Session["UsuarioVotacion"];
            if (usuario != null)
            {
                if (usuario.estado != "Votante")
                {
                    BVotacion oBVotacion = new BVotacion();
                    result = oBVotacion.RegistrarVotacion_DAL(usuario.idAlumno, idPartido);
                    if (result)
                    {                        
                        Session["UsuarioVotacion"] = null;
                    }
                }
                else
                {
                    mensaje = "Ya realizaste tu voto, no puedes votar 2 veces";
                }
            }
            else
            {
                mensaje = "Su sesión ha expirado. Vuelva a ingresar con sus credenciales";
            }            

            return Json(new { Estado = result, Mensaje = mensaje });
        }
	}
}
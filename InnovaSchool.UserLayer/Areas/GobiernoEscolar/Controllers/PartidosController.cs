using InnovaSchool.BL;
using InnovaSchool.Entity;
using InnovaSchool.Entity.Result;
using InnovaSchool.UserLayer.Areas.GobiernoEscolar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace InnovaSchool.UserLayer.Areas.GobiernoEscolar.Controllers
{
    public class PartidosController : BaseController
    {
        BPartidoPostulante oBPartidoPostulante;

        //
        // GET: /GobiernoEscolar/Partidos/
        public ActionResult Index()
        {
            oBPartidoPostulante = new BPartidoPostulante();
            var model = oBPartidoPostulante.ListarPartidoPostulante_BL();
            Session["Partidos"] = model;
            return View(model);
        }

        public ActionResult Registro(int? id)
        {
            BDetalleProceso oBDetalleProceso = new BDetalleProceso();
            var proceso = oBDetalleProceso.ObtenerProcesoVigente_BL("Registrar Partido Postulante");
            ViewBag.ProcesoActivo = (proceso != null);
            
            ViewBag.IdPartido = id;
            return View();
        }

        public JsonResult ValidarNombre(string nombre)
        {
            oBPartidoPostulante = new BPartidoPostulante();
            Dictionary<string, object> validacion = oBPartidoPostulante.ValidarNombrePartido_BL(nombre);
            return Json(validacion, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public int Registro(EPartidoModel model)
        {                     
            oBPartidoPostulante = new BPartidoPostulante();            

            //Validar el nombre del partido si se esta registrando
            EPartidoPostulante partido = new EPartidoPostulante();
            partido.idPartido = model.IdPartido;
            partido.Nombre = model.NombrePartido;
            if (model.Logo != null)
            {
                //var res = new Resources.Resources();
                string b64 = model.Logo.Substring(model.Logo.IndexOf(",") + 1);
                if (BOperaciones.IsBase64String(b64))
                {
                    byte[] bytes = System.Convert.FromBase64String(b64);
                    partido.Logo = bytes;
                }
            }

            partido.Integrantes = model.Integrantes;

            return oBPartidoPostulante.RegistrarPartido_BL(partido);
        }

        public JsonResult VerPartido(int id)
        {
            oBPartidoPostulante = new BPartidoPostulante();
            var result = oBPartidoPostulante.ListarPartidoPostulante_BL(id);
            var integrantes = oBPartidoPostulante.ListarIntegrantesPartido_BL(id);

            string foto = "";

            if (result.Logo != null)
            {
                foto = string.Format("data:image/png;base64,{0}", System.Convert.ToBase64String(result.Logo));                
                result.Logo = null;
            }

            return Json(new { Partido = result, Logo = foto, Integrantes = integrantes }, JsonRequestBehavior.AllowGet);
        }

        [CustomAuthorize(Roles = "Comision_leg")]
        public JsonResult GenerarCredenciales()
        {
            var lista = (List<SP_GE_ListarPartidoPostulante_Result>)Session["Partidos"];

            if (lista != null)
            {
                oBPartidoPostulante = new BPartidoPostulante();
                List<SP_GE_ListarIntegrantesPartido_Result> integrantes = null;

                foreach (var row in lista)
                {
                    integrantes = oBPartidoPostulante.ListarIntegrantesPartido_BL(row.idPartido);
                    oBPartidoPostulante.GenerarCredenciales_BL(integrantes);
                }
            }

            return Json(lista.Count);
        }

        public JsonResult ListarCargos()
        {
            BCargo oBCargo = new BCargo();
            return Json(oBCargo.ListarCargo_BL(DateTime.Now.Year), JsonRequestBehavior.AllowGet);
        }

        public JsonResult ValidarIntegranteInscrito(int id)
        {
            oBPartidoPostulante = new BPartidoPostulante();
            var result = oBPartidoPostulante.ValidarIntegranteInscrito_BL(id);

            return Json(new { Integrante = result }, JsonRequestBehavior.AllowGet);
        }
    }
}
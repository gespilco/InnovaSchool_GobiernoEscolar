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

        public ActionResult Actualizar()
        {
            return View();
        }

        public ActionResult Registro(int? id)
        {            
            ViewBag.IdPartido = id;
            return View();
        }

        [HttpPost]
        public int Registro(EPartidoModel model)
        {
            EPartidoPostulante partido = new EPartidoPostulante();
            partido.idPartido = model.IdPartido;
            partido.Nombre = model.NombrePartido;
            partido.Estado = "Registrado";
            if (model.Logo != null)
            {
                var res = new Resources.Resources();
                string b64 = model.Logo.Substring(model.Logo.IndexOf(",") + 1);
                if (res.IsBase64String(b64))
                {
                    byte[] bytes = System.Convert.FromBase64String(b64);
                    partido.Logo = bytes;
                }
            }

            partido.Integrantes = model.Integrantes;

            oBPartidoPostulante = new BPartidoPostulante();
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
                foto = System.Convert.ToBase64String(result.Logo);
                result.Logo = null;
            }            

            return Json(new { Partido = result, Logo = foto, Integrantes = integrantes }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult PlanGobierno(int? id)
        {
            if (id != null)
            {
                ViewBag.IdPartido = id;
                oBPartidoPostulante = new BPartidoPostulante();
                var result = oBPartidoPostulante.ListarPartidoPostulante_BL((int)id);

                ViewBag.NombrePartido = result.Nombre;
            }
            
            return View();
        }

        [CustomAuthorize(Roles = "Supervisor")]
        public JsonResult GenerarCredenciales()
        {
            var lista = (List<SP_ListarPartidoPostulante_Result>)Session["Partidos"];

            if (lista != null)
            {
                foreach (var row in lista)
                {
                    row.Nombre += "xxx";
                }
            }
            
            return Json(lista.Count);
        }

        #region Metodos
        public JsonResult ListarCargos()
        {
            BCargo oBCargo = new BCargo();
            return Json(oBCargo.ListarCargo_BL(DateTime.Now.Year), JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}
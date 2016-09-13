using InnovaSchool.BL;
using InnovaSchool.Entity;
using InnovaSchool.Entity.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InnovaSchool.UserLayer.Areas.GobiernoEscolar.Controllers
{
    public class ResultadosController : BaseController
    {
        [CustomAuthorize(Roles = "Rep_academico")]
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult VerResultados(int anyo)
        {
            BResultados oBResultados = new BResultados();
            var result = oBResultados.GenerarResultados_BL(anyo);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Notificar(string html)
        {
            BResultados oBResultados = new BResultados();
            var result = oBResultados.Notificar_BL(html);

            return Json(result);
        }
    }
}
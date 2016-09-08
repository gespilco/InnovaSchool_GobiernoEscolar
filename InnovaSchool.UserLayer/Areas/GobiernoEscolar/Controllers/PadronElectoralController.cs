using InnovaSchool.BL;
using InnovaSchool.Entity.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InnovaSchool.UserLayer.Areas.GobiernoEscolar.Controllers
{
    public class PadronElectoralController : BaseController
    {
        //
        // GET: /GobiernoEscolar/PadronElectoral/
        public ActionResult Index()
        {
            //Extrael el padron generado
            BAlumnoEmpadronado oBAlumnoEmpadronado = new BAlumnoEmpadronado();
            var model = oBAlumnoEmpadronado.ListarAlumnosEmpadronados_BL();
            Session["AlumnosEmpadronados"] = model;
            return View(model);
        }

        public ActionResult GenerarPadron()
        {
            BAlumnoEmpadronado oBAlumnoEmpadronado = new BAlumnoEmpadronado();
            string mensaje = oBAlumnoEmpadronado.GenerarPadronElectoral_BL();
            TempData["Mensaje"] = mensaje;
            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult Notificar()
        {
            List<SP_ListarAlumnosPadronElectoral_Result> model = (List<SP_ListarAlumnosPadronElectoral_Result>)Session["AlumnosEmpadronados"];

            BAlumnoEmpadronado oBAlumnoEmpadronado = new BAlumnoEmpadronado();
            int procesados = oBAlumnoEmpadronado.GenerarCredenciales_BL(model);

            return Json(procesados);
        }
	}
}
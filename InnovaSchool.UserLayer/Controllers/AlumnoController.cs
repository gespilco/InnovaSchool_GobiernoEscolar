using InnovaSchool.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InnovaSchool.UserLayer.Controllers
{
    public class AlumnoController : Controller
    {        
        //
        // GET: /Alumno/
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Detalle(int id)
        {
            BAlumno oBAlumno = new BAlumno();
            var result = oBAlumno.ListarAlumno_BL(id);

            return Json(new { Alumno = result }, JsonRequestBehavior.AllowGet);
        }
	}
}
using InnovaSchool.BL;
using InnovaSchool.Entity;
using InnovaSchool.Entity.Result;
using InnovaSchool.UserLayer.Models;
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
        public int Registro(string partido, string data, HttpPostedFileBase image)
        {            
            List<EPartidoModel> personas = new JavaScriptSerializer().Deserialize<List<EPartidoModel>>(data);            

            foreach (var p in personas)
            {
                p.Cargo = "xx";
            }

            //partido.FechaReg = DateTime.Now;
            oBPartidoPostulante = new BPartidoPostulante();
            return 1;//oBPartidoPostulante.RegistrarPartido_BL(partido);
        }

        public ActionResult PlanGobierno(int? id)
        {
            ViewBag.NombrePartido = "Nombre del partido político";
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
	}
}
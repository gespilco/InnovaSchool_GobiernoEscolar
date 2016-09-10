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
        public JsonResult Registro(EPartidoModel model)
        {
            int? id = null;
            string mensaje = "";
            oBPartidoPostulante = new BPartidoPostulante();

            //Verificamos las coincidencias del nombre
            bool isValid = true;

            //Validar el nombre del partido si se esta registrando
            if ((model.IdPartido == 0))
                isValid = oBPartidoPostulante.ValidarPartido(model.NombrePartido);

            if (isValid)
            {
                EPartidoPostulante partido = new EPartidoPostulante();
                partido.idPartido = model.IdPartido;
                partido.Nombre = model.NombrePartido;
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

                id = oBPartidoPostulante.RegistrarPartido_BL(partido);
                mensaje = "Ok";
            }
            else
            {
                mensaje = "Nombre de partido tiene mas de 50% de coincidencia. No procede con el registro";
            }


            return Json(new { Id = id, Mensaje = mensaje });
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

        [CustomAuthorize(Roles = "Comision_leg")]
        public JsonResult GenerarCredenciales()
        {
            var lista = (List<SP_ListarPartidoPostulante_Result>)Session["Partidos"];

            if (lista != null)
            {
                oBPartidoPostulante = new BPartidoPostulante();
                //List<SP_ListarIntegrantesPartido_Result> integrantes = null;

                //foreach (var row in lista)
                //{
                //    integrantes = oBPartidoPostulante.ListarIntegrantesPartido_BL(row.idPartido);
                //    oBPartidoPostulante.GenerarCredenciales_BL(integrantes);
                //}
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
            var result = oBPartidoPostulante.ValidarIntegranteInscrito(id);

            return Json(new { Integrante = result }, JsonRequestBehavior.AllowGet);
        }

        #region Plan de gobierno
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

        public JsonResult CargarPlanGobierno(int idPartido)
        {
            BPlanGobierno oBPlanGobierno = new BPlanGobierno();
            
            EPlanGobierno Plan = oBPlanGobierno.SP_PlanGobiernoPartido_BL(idPartido);
            List<SP_ListarActividadesPlanGobierno_Result> Actividades = null;
            List<SP_ListarInstrumentosPlanGobierno_Result> Instrumentos = null;

            if (Plan != null)
            {
                Actividades = oBPlanGobierno.SP_ListarActividadesPlanGobierno_BL(Plan.idplan);
                Instrumentos = oBPlanGobierno.SP_ListarInstrumentosPlanGobierno_BL(Plan.idplan);
            }

            return Json(new
            {
                Plan = Plan,
                Actividades = Actividades,
                Instrumentos = Instrumentos
            }, JsonRequestBehavior.AllowGet);
        }

        public int AprobarPlanGobierno(int idPlan)
        {
            BPlanGobierno oBPlanGobierno = new BPlanGobierno();             
            return oBPlanGobierno.SP_AprobarPlanGobierno_BL(idPlan);
        }

        public JsonResult VerSubActividadesPlan(int idActividad)
        {            
            BPlanGobierno oBPlanGobierno = new BPlanGobierno(); 

            var result = oBPlanGobierno.SP_ListarSubActividadesPlanGobierno_BL(idActividad);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public int GuardarObservacionActividad(EObservacion obs)
        {
            BPlanGobierno oBPlanGobierno = new BPlanGobierno();
            int result = oBPlanGobierno.SP_GuardarObservacionActividad_DAL(obs);

            return result;
        }
        #endregion
    }
}
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
    public class PlanGobiernoController : BaseController
    {
        BPartidoPostulante oBPartidoPostulante;

        public ActionResult Index(int? id)
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

        public PartialViewResult VerObservaciones(int id, string tipo)
        {

            BPlanGobierno oBPlanGobierno = new BPlanGobierno();
            List<EObservacion> model = oBPlanGobierno.SP_VerObservacionesDetalle_BL(id, tipo);

            return PartialView("_PartialObservaciones", model);
        }

        public int GuardarObservacion(EObservacion obs)
        {
            BPlanGobierno oBPlanGobierno = new BPlanGobierno();
            int result = oBPlanGobierno.SP_GuardarObservacion_BL(obs);

            return result;
        }

        [HttpPost]
        public JsonResult EnviarObservaciones(int idPartido, int idPlan)
        {
            BPlanGobierno oBPlanGobierno = new BPlanGobierno();
            List<EObservacion> obsActividades = oBPlanGobierno.SP_VerTodasObservacionesPlan_BL(idPlan);
            EEmailStatus status = new EEmailStatus() { Estado = false, Mensaje = "No se envio el email ya que no hay observaciones para enviar" };

            if(obsActividades.Count > 0)
            {
                oBPartidoPostulante = new BPartidoPostulante();
                List<SP_ListarIntegrantesPartido_Result> integrantes = oBPartidoPostulante.ListarIntegrantesPartido_BL(idPartido);

                if (integrantes.Count > 0)
                {
                    List<EEmail> Destinatarios = new List<EEmail>();

                    EEmail Emisor = new EEmail("procesoelectoral@innovaschool.edu.pe", "Innova School");

                    foreach (var item in integrantes)
                    {
                        Destinatarios.Add(new EEmail(item.Correo, item.Nombre));
                    }

                    string html = "";
                    html += "<h2>Observaciones del Plan de Gobierno</h2>";
                    html += "<ul>";
                    foreach (var item in obsActividades)
                    {
                        html += string.Format("<li>{0}</li>", item.Descripcion);
                    }

                    html += "</ul>";

                    status = BEmail.EnviarEmail(Emisor, Destinatarios, "Observaciones", html);
                }
                else
                {
                    status.Mensaje = "No hay integrantes registrados del partido";
                }
                
            }

            return Json(status);
        }
	}
}
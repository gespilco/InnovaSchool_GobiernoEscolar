using InnovaSchool.DAL;
using InnovaSchool.Entity;
using InnovaSchool.Entity.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovaSchool.BL
{
    public class BPlanGobierno
    {
        public EPlanGobierno SP_PlanGobiernoPartido_BL(int idPartido)
        {
            DPlanGobierno oDPlanGobierno = new DPlanGobierno();
            return oDPlanGobierno.SP_PlanGobiernoPartido_DAL(idPartido);
        }

        public List<SP_GE_ListarActividadesPlanGobierno_Result> SP_ListarActividadesPlanGobierno_BL(int idPlan)
        {
            DPlanGobierno oDPlanGobierno = new DPlanGobierno();
            return oDPlanGobierno.SP_ListarActividadesPlanGobierno_DAL(idPlan);
        }

        public List<SP_GE_ListarSubActividadesPlanGobierno_Result> SP_ListarSubActividadesPlanGobierno_BL(int idActividad)
        {
            DPlanGobierno oDPlanGobierno = new DPlanGobierno();
            return oDPlanGobierno.SP_ListarSubActividadesPlanGobierno_DAL(idActividad);
        }

        public List<SP_GE_ListarInstrumentosPlanGobierno_Result> SP_ListarInstrumentosPlanGobierno_BL(int idPlan)
        {
            DPlanGobierno oDPlanGobierno = new DPlanGobierno();
            return oDPlanGobierno.SP_ListarInstrumentosPlanGobierno_DAL(idPlan);
        }

        public int SP_GuardarObservacion_BL(EObservacion objEN, int idPlanGobierno)
        {
            DPlanGobierno oDPlanGobierno = new DPlanGobierno();
            return oDPlanGobierno.SP_GuardarObservacion_DAL(objEN, idPlanGobierno);
        }

        public List<EObservacion> SP_VerObservacionesDetalle_BL(int id, string tipo)
        {
            DPlanGobierno oDPlanGobierno = new DPlanGobierno();
            return oDPlanGobierno.SP_VerObservacionesDetalle_DAL(id, tipo);
        }

        public bool SP_EliminarObservacion_BL(int idObservacion)
        {
            DPlanGobierno oDPlanGobierno = new DPlanGobierno();
            return oDPlanGobierno.SP_PlanGobiernoEliminarObservacion_DAL(idObservacion);
        }

        public List<EObservacion> SP_VerTodasObservacionesPlan_BL(int idPlan)
        {
            DPlanGobierno oDPlanGobierno = new DPlanGobierno();
            return oDPlanGobierno.SP_VerTodasObservacionesPlan_DAL(idPlan);
        }

        public int SP_AprobarPlanGobierno_BL(int idPlan)
        {
            DPlanGobierno oDPlanGobierno = new DPlanGobierno();
            return oDPlanGobierno.SP_AprobarPlanGobierno_DAL(idPlan);
        }

        public EEmailStatus EnviarObservaciones(int idPartido, int idPlan)
        {            
            List<EObservacion> observaciones = SP_VerTodasObservacionesPlan_BL(idPlan);
            EEmailStatus status = new EEmailStatus() { Estado = false, Mensaje = "No se envio el email ya que no hay observaciones para enviar" };

            if (observaciones.Count > 0)
            {
                BPartidoPostulante oBPartidoPostulante = new BPartidoPostulante();
                List<SP_GE_ListarIntegrantesPartido_Result> integrantes = oBPartidoPostulante.ListarIntegrantesPartido_BL(idPartido);

                if (integrantes.Count > 0)
                {
                    List<EEmail> Destinatarios = new List<EEmail>();

                    EEmail Emisor = new EEmail("innovaschool2016@gmail.com", "Innova School");

                    foreach (var item in integrantes)
                    {
                        Destinatarios.Add(new EEmail(item.Correo, item.Nombre));
                    }

                    string html = "";
                    html += "<h2>Observaciones del Plan de Gobierno</h2>";
                    var obsActividades = observaciones.Where(x => x.idActividadPropuesta != null).ToList();
                    var obsInstrumentos = observaciones.Where(x => x.idInstrumento != null).ToList();

                    if (obsActividades.Count > 0)
                    {
                        html += "<h3>Observaciones de actividades:</h3>";
                        html += "<ul>";
                        foreach (var item in obsActividades)
                        {
                            html += string.Format("<li>{0}</li>", item.Descripcion);
                        }

                        html += "</ul>";
                    }

                    if (obsInstrumentos.Count > 0)
                    {
                        html += "<br/>";
                        html += "<h3>Observaciones de instrumentos:</h3>";
                        html += "<ul>";
                        foreach (var item in obsInstrumentos)
                        {
                            html += string.Format("<li>{0}</li>", item.Descripcion);
                        }

                        html += "</ul>";
                    }

                    status = BEmail.EnviarEmail(Emisor, Destinatarios, "Observaciones", html);
                }
                else
                {
                    status.Mensaje = "No hay integrantes registrados del partido";
                }

            }

            return status;
        }
    }
}

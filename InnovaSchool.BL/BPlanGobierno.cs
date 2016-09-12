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

        public List<SP_ListarActividadesPlanGobierno_Result> SP_ListarActividadesPlanGobierno_BL(int idPlan)
        {
            DPlanGobierno oDPlanGobierno = new DPlanGobierno();
            return oDPlanGobierno.SP_ListarActividadesPlanGobierno_DAL(idPlan);
        }

        public List<SP_ListarSubActividadesPlanGobierno_Result> SP_ListarSubActividadesPlanGobierno_BL(int idActividad)
        {
            DPlanGobierno oDPlanGobierno = new DPlanGobierno();
            return oDPlanGobierno.SP_ListarSubActividadesPlanGobierno_DAL(idActividad);
        }

        public List<SP_ListarInstrumentosPlanGobierno_Result> SP_ListarInstrumentosPlanGobierno_BL(int idPlan)
        {
            DPlanGobierno oDPlanGobierno = new DPlanGobierno();
            return oDPlanGobierno.SP_ListarInstrumentosPlanGobierno_DAL(idPlan);
        }

        public int SP_GuardarObservacion_BL(EObservacion objEN)
        {
            DPlanGobierno oDPlanGobierno = new DPlanGobierno();
            return oDPlanGobierno.SP_GuardarObservacion_DAL(objEN);
        }

        public List<EObservacion> SP_VerObservacionesDetalle_BL(int id, string tipo)
        {
            DPlanGobierno oDPlanGobierno = new DPlanGobierno();
            return oDPlanGobierno.SP_VerObservacionesDetalle_DAL(id, tipo);
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
    }
}

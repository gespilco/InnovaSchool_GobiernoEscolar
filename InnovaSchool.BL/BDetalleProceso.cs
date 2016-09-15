using InnovaSchool.DAL;
using InnovaSchool.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovaSchool.BL
{
    public class BDetalleProceso
    {
        public EDetalleProceso ObtenerProcesoVigente_BL(string proceso)
        {
            DDetalleProceso oDetalleProceso = new DDetalleProceso();
            return oDetalleProceso.ObtenerProcesoVigente_DAL(proceso);
        }

        public EDetalleProceso ObtenerProcesoValido_BL(string proceso)
        {
            DDetalleProceso oDetalleProceso = new DDetalleProceso();
            return oDetalleProceso.ObtenerProcesoValido_DAL(proceso);
        }
    }
}

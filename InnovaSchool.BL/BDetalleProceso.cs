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
        public EDetalleProceso ObtenerProceso_BL(string proceso)
        {
            DDetalleProceso oDetalleProceso = new DDetalleProceso();
            return oDetalleProceso.ObtenerProceso_DAL(proceso);
        }
    }
}

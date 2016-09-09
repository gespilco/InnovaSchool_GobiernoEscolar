using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovaSchool.Entity
{
    public class EObservacion
    {
        public int idObservacion { get; set; }
        public string Descripcion { get; set; }
        public string NivelObservacion { get; set; }
        public Nullable<int> idInstrumento { get; set; }
        public Nullable<int> idActividadPropuesta { get; set; }
        public Nullable<int> idactPlan { get; set; }
    }
}

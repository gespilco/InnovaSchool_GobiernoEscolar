using System;

namespace InnovaSchool.Entity
{
    public partial class EDetalleProceso
    {
        public int idProceso { get; set; }
        public string nombreProceso { get; set; }
        public Nullable<System.DateTime> FechaInicio { get; set; }
        public Nullable<System.DateTime> FechaFin { get; set; }
        public Nullable<int> idPersona { get; set; }
    }
}

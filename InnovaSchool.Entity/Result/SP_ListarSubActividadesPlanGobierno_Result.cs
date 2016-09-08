using System;

namespace InnovaSchool.Entity.Result
{
    public partial class SP_ListarSubActividadesPlanGobierno_Result
    {
        public int SubActividadID { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public Nullable<int> idActividadPropuesta { get; set; }
        public Nullable<int> idactPlan { get; set; }
    }
}

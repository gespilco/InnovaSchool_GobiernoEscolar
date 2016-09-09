using System;

namespace InnovaSchool.Entity.Result
{
    public partial class SP_ListarAlumnosPadronElectoral_Result
    {
        public int idAlumno { get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public Nullable<int> edad { get; set; }
        public string correoElectronico { get; set; }
        public string grado { get; set; }
        public string seccion { get; set; }
    }
}

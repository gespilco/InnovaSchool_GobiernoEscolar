using System;

namespace InnovaSchool.Entity
{
    public class EAlumnoEmpadronado
    {
        public int idalumnoempadronado { get; set; }
        public Nullable<long> codalumnoempadronado { get; set; }
        public string estado { get; set; }
        public Nullable<int> añoescolar { get; set; }
        public Nullable<int> idAlumno { get; set; }
        public Nullable<int> idProceso { get; set; }
    }
}

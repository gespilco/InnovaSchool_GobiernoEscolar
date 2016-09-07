using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovaSchool.Entity
{
    public partial class EAlumno
    {
        public int idAlumno { get; set; }
        public string estado { get; set; }
        public Nullable<int> idPersona { get; set; }
        public Nullable<int> idApoderado { get; set; }
        public Nullable<int> idSede { get; set; }
        public virtual EPersona Persona { get; set; }
    }
}

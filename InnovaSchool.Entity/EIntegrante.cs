using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovaSchool.Entity
{
    public class EIntegrante
    {
        public int idIntegrante { get; set; }
        public Nullable<int> idAlumno { get; set; }
        public Nullable<int> idCargo { get; set; }
        public Nullable<int> idPartido { get; set; }
    }
}

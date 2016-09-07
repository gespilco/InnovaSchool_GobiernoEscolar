using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovaSchool.Entity
{
    public class ECargo
    {
        public int idCargo { get; set; }
        public string tipoCargo { get; set; }
        public Nullable<int> anoAcademico { get; set; }
    }
}

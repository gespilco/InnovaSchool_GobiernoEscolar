using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovaSchool.Entity
{
    public class EPlanGobierno
    {
        public int idplan { get; set; }
        public Nullable<System.DateTime> FechaReg { get; set; }
        public string Estado { get; set; }
        public string Objetivo { get; set; }
        public Nullable<System.DateTime> FechaAprob { get; set; }
        public Nullable<int> codAlumno { get; set; }
        public Nullable<int> idProceso { get; set; }
        public Nullable<int> idPartido { get; set; }
        //Variable auxiliar
        public Nullable<int> idPersonaAsesor { get; set; }
    }
}

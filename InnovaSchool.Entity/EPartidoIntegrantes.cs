using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovaSchool.Entity
{
    public class EPartidoIntegrantes
    {
        public int IdPartido { get; set; }
        public int IdAlumno { get; set; }
        public string Nombres { get; set; }
        public string ApePaterno { get; set; }
        public string ApeMaterno { get; set; }
        public int IdCargo { get; set; }
        public string Grado { get; set; }
    }
}

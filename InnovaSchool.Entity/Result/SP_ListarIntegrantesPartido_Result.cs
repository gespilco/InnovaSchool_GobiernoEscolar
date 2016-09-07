using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovaSchool.Entity.Result
{
    public class SP_ListarIntegrantesPartido_Result
    {
        public int idPartido { get; set; }
        public int idAlumno { get; set; }
        public string Nombre { get; set; }
        public string Grado { get; set; }
        public int idCargo { get; set; }
        public string Cargo { get; set; }        
    }
}

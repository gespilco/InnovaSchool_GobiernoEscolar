using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InnovaSchool.UserLayer.Models
{
    public class EPartidoModel
    {
        public string NombrePartido { get; set; }
        public int CodigoAlumno { get; set; }
        public string NombreAlumno { get; set; }
        public string Grado { get; set; }
        public int IdCargo { get; set; }
        public string Cargo { get; set; }
    }
}
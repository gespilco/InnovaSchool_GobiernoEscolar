using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovaSchool.Entity.Result
{
    public class SP_GE_ObtenerCredencialesVotacion_Result
    {
        public int idalumnoempadronado { get; set; }
        public int idAlumno { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string estado { get; set; }
    }
}

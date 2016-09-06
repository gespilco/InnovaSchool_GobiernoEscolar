using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovaSchool.Entity
{
    public class EUsuario
    {
        public int IdUsuario { get; set; }
        public string Usuario { get; set; }
        public string Email { get; set; }
        public string UPassword { get; set; }
        public int IdPregunta { get; set; }
        public string Respuesta { get; set; }
        public int Estado { get; set; }
        public string UsuCreacion { get; set; }
        public DateTime? FecCreacion { get; set; }
        public string UsuModificación { get; set; }
        public DateTime? FecModificacion { get; set; }
    }
}

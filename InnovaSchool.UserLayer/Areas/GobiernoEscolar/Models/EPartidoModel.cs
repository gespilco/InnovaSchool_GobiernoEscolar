using InnovaSchool.Entity;
using System.Collections.Generic;

namespace InnovaSchool.UserLayer.Areas.GobiernoEscolar.Models
{
    public class EPartidoModel
    {
        public int IdPartido { get; set; }
        public string NombrePartido { get; set; }
        public string Logo { get; set; }
        public List<EIntegrante> Integrantes { get; set; }
    }    
}
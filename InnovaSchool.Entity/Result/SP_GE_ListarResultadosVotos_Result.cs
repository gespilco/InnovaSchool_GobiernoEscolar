using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovaSchool.Entity.Result
{
    public partial class SP_GE_ListarResultadosVotos_Result
    {
        public int idPartido { get; set; }
        public string NombrePartido { get; set; }
        public int Votos { get; set; }
    }
}

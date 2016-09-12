using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovaSchool.Entity.Result
{
    public partial class SP_GE_ListarPartidoPostulante_Result
    {
        public int idPartido { get; set; }
        public string Nombre { get; set; }
        public string Estado { get; set; }
        public byte[] Logo { get; set; }
        //Variable auxiliar para cargar el logo
        public string Imagen { get; set; }
    }
}

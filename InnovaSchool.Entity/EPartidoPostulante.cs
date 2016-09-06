using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovaSchool.Entity
{
    public class EPartidoPostulante
    {

        public int PartidoID { get; set; }
        public string Nombre { get; set; }
        public string Estado { get; set; }
        public byte[] Logo { get; set; }
        public DateTime FechaReg { get; set; }
        public int idvoto { get; set; }
        public int idplan { get; set; }
        public int idpersona { get; set; }

    }
}

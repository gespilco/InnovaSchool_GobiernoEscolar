using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovaSchool.Entity.Result
{
    public partial class SP_ListarActividadesPlanGobierno_Result
    {
        public int idactividadPropuesta { get; set; }
        public string nombre { get; set; }
        public string fechaInicio { get; set; }
        public string fechaTermino { get; set; }
        public string descripcion { get; set; }
    }
}

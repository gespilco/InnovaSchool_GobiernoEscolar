using InnovaSchool.DAL;
using InnovaSchool.Entity;
using InnovaSchool.Entity.Result;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovaSchool.BL
{
    public class BPartidoPostulante
    {
        public List<SP_ListarPartidoPostulante_Result> ListarPartidoPostulante_BL()
        {
           DPartidoPostulante Obj_Dal = new DPartidoPostulante();
           return Obj_Dal.ListarPartidoPostulante_DAL();
        }

       
        public int RegistrarPartido_BL(EPartidoPostulante objEN)
        {
           DPartidoPostulante Obj_Dal = new DPartidoPostulante();            
            return Obj_Dal.RegistrarPartidoPostulante_DAL(objEN);
        }

        public int ActualizarInstrumento_BL(EPartidoPostulante objEN)
        {
            DPartidoPostulante Obj_Dal = new DPartidoPostulante();
            return Obj_Dal.ActualizarPartidoPostulante_DAL(objEN);
        }

        public int EliminarInstrumento_BL(EPartidoPostulante objEN)
        {
            DPartidoPostulante Obj_Dal = new DPartidoPostulante();
            return Obj_Dal.EliminarPartidoPostulante_DAL(objEN);
        }
    

       
}    
}

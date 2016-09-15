using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InnovaSchool.DAL;
using InnovaSchool.Entity;
using InnovaSchool.Entity.Result;

namespace InnovaSchool.BL
{
    public class BVotacion
    {
        public bool RegistrarVotacion_DAL(int idAlumno, int? idPartido)
        {
            DVotacion oDVotacion = new DVotacion();
            return oDVotacion.RegistrarVotacion_DAL(idAlumno, idPartido);
        }

        public List<SP_GE_ListarPartidoPostulante_Result> ListarPartidosVotacion_DAL()
        {
            DVotacion oDVotacion = new DVotacion();
            var result = oDVotacion.ListarPartidosVotacion_DAL();            

            foreach (var item in result)
            {
                item.Imagen = null;

                if (item.Logo != null)
                {
                    item.Imagen = string.Format("data:image/png;base64,{0}", System.Convert.ToBase64String(item.Logo));
                    item.Logo = null;
                }
            }

            return result;
        }
    }
}

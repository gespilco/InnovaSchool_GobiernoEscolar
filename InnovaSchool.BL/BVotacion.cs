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
    }
}

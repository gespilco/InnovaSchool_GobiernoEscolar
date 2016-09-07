using InnovaSchool.DAL;
using InnovaSchool.Entity.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovaSchool.BL
{
    public class BAlumno
    {
        DAlumno oDAlumno;

        public SP_ListarAlumnoById_Result ListarAlumno_BL(int idAlumno)
        {
            oDAlumno = new DAlumno();
            return oDAlumno.ListarAlumno_DAL(idAlumno);
        }
    }
}

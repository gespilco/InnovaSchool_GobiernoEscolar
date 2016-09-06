using InnovaSchool.DAL;
using InnovaSchool.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovaSchool.BL
{
    public class BAlumnoEmpadronado
    {
        public DataTable ListarAlumnoEmpadronado_BL(EAlumnoEmpadronado objEN)
        {
           DAlumnoEmpadronado Obj_Dal = new DAlumnoEmpadronado();
            return Obj_Dal.ListarAlumnosEmpadronados_DAL(objEN);
        }
       
        public int RegistrarAlumnoEmpadronado_BL(EAlumnoEmpadronado objEN)
        {
            DAlumnoEmpadronado Obj_Dal = new DAlumnoEmpadronado();
            return Obj_Dal.RegistrarAlumnoEmpadronado_DAL(objEN);
        }

        public int ActualizarAlumnoEmpadronado_BL(EAlumnoEmpadronado objEN)
        {
            DAlumnoEmpadronado Obj_Dal = new DAlumnoEmpadronado();
            return Obj_Dal.ActualizarAlumnoEmpadronado_DAL(objEN);
        }

        public int EliminarAlumnoEmpadronado_BL(EAlumnoEmpadronado objEN)
        {
            DAlumnoEmpadronado Obj_Dal = new DAlumnoEmpadronado();
            return Obj_Dal.EliminarAlumnoEmpadronadp_DAL(objEN);
        }
    }




    
}

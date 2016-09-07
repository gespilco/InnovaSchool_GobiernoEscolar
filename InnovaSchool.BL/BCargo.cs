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
    public class BCargo
    {
        public List<ECargo> ListarCargo_BL(int anoAcademico)
        {
           DCargo Obj_Dal = new DCargo();
           return Obj_Dal.ListarCargos_DAL(anoAcademico);
        }
       
        //public int RegistrarCargo_BL(ECargo objEN)
        //{
        //    DCargo Obj_Dal = new DCargo();
        //    return Obj_Dal.RegistrarCargo_DAL(objEN);
        //}

        //public int ActualizarCargo_BL(ECargo objEN)
        //{
        //    DCargo Obj_Dal = new DCargo();
        //    return Obj_Dal.ActualizarCargo_DAL(objEN);
        //}

        //public int EliminarCargo_BL(ECargo objEN)
        //{
        //    DCargo Obj_Dal = new DCargo();
        //    return Obj_Dal.EliminarCargo_DAL(objEN);
        //}
    }


    
}

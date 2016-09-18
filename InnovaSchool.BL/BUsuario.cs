using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InnovaSchool.Entity;
using InnovaSchool.DAL;

namespace InnovaSchool.BL
{
    public class BUsuario
    {
        DUsuario oDUsuario = new DUsuario();

        public EUsuario VerificarUsuario_BL(EUsuario EUsuario)
        {
            return oDUsuario.VerificarUsuario_DAL(EUsuario);
        }

        public int RegistrarUsuario_BL(EUsuario objEN)
        {
            return oDUsuario.RegistrarUsuario_DAL(objEN);
        }
    }
}

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
        DUsuario DUsuario = new DUsuario();

        public EUsuario VerificarUsuario(EUsuario EUsuario)
        {
            return DUsuario.VerificarUsuario(EUsuario);
        }
        public List<EUsuario> Login(EUsuario EUsuario)
        {
            return DUsuario.Login(EUsuario);
        }
    }
}

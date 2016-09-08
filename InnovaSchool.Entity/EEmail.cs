using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovaSchool.Entity
{
    public class EEmail
    {
        public string Nombre { get; set; }
        public string Email { get; set; }

        public EEmail(string Email, string Nombre)
        {
            this.Nombre = Nombre;
            this.Email = Email;
        }

        public EEmail()
        {
            this.Nombre = string.Empty;
            this.Email = string.Empty;
        }
    }

    public class EEmailStatus
    {
        public bool Estado { get; set; }
        public string Mensaje { get; set; }
        public string ErrorTecnico { get; set; }
    }
}

using InnovaSchool.DAL;
using InnovaSchool.Entity;
using InnovaSchool.Entity.Result;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace InnovaSchool.BL
{
    public class BPartidoPostulante
    {
        public List<SP_ListarPartidoPostulante_Result> ListarPartidoPostulante_BL()
        {
            DPartidoPostulante Obj_Dal = new DPartidoPostulante();
            return Obj_Dal.ListarPartidoPostulante_DAL();
        }

        public SP_ListarPartidoPostulanteById_Result ListarPartidoPostulante_BL(int IdPartido)
        {
            DPartidoPostulante Obj_Dal = new DPartidoPostulante();
            return Obj_Dal.ListarPartidoPostulante_DAL(IdPartido);
        }

        public int RegistrarPartido_BL(EPartidoPostulante objEN)
        {
            objEN.Estado = "Incompleto";

            if (objEN.Integrantes != null)
            {
                if (objEN.Integrantes.Count == 3)
                {
                    objEN.Estado = "Registrado";
                }
            }
            DPartidoPostulante Obj_Dal = new DPartidoPostulante();
            //Registramos el partido
            int result = Obj_Dal.RegistrarPartidoPostulante_DAL(objEN);

            Obj_Dal.EliminarIntegrantes_DAL(result);

            //Registramos los integrantes
            if (objEN.Integrantes != null)
            {
                foreach (var obj in objEN.Integrantes)
                {
                    obj.idPartido = result;
                    Obj_Dal.RegistrarIntegrante_DAL(obj);
                }
            }
            
            return result;
        }

        public bool ValidarPartido(string nombre)
        {
            DPartidoPostulante Obj_Dal = new DPartidoPostulante();
            List<string> partidos = Obj_Dal.ListarPartidosValidacion_DAL();

            foreach (string p in partidos)
            {
                if (p == nombre)
                {
                    return false;
                }
            }

            return true;

        }

        public SP_ValidarIntegrantePartido_Result ValidarIntegranteInscrito(int idAlumno)
        {
            DPartidoPostulante Obj_Dal = new DPartidoPostulante();
            return Obj_Dal.ValidarIntegranteInscrito_DAL(idAlumno, DateTime.Now.Year);
        }

        public List<SP_ListarIntegrantesPartido_Result> ListarIntegrantesPartido_BL(int idPartido)
        {
            DPartidoPostulante Obj_Dal = new DPartidoPostulante();
            return Obj_Dal.ListarIntegrantesPartido_DAL(idPartido);
        }

        public int EliminarInstrumento_BL(EPartidoPostulante objEN)
        {
            DPartidoPostulante Obj_Dal = new DPartidoPostulante();
            return Obj_Dal.EliminarPartidoPostulante_DAL(objEN);
        }

        public int GenerarCredenciales_BL(List<SP_ListarIntegrantesPartido_Result> alumnos)
        {
            EEmail emisor = new EEmail("procesoelectoral@innovaschool.pe", "Innova School");
            int procesados = 0;

            string Plantilla = BOperaciones.GetHtmlPage(HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["PlantillaCredencialesVoto"]));

            //foreach (var item in alumnos)
            //{
            //    EEmailStatus status = BEmail.EnviarEmail(emisor, new List<EEmail>() { new EEmail(item.correoElectronico, item.nombre + " " + item.apellidos) },
            //         "Credenciales", Plantilla
            //         .Replace("{Nombres}", item.nombre)
            //         .Replace("{Apellidos}", item.apellidos)
            //         .Replace("{Usuario}", "ALUMNO-" + item.idAlumno.ToString())
            //         .Replace("{Clave}", "123456")
            //         );

            //    if (status.Estado == true)
            //    {
            //        procesados++;
            //    }
            //}

            return procesados;
        }

    }
}

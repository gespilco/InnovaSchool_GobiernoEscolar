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
    public class BAlumnoEmpadronado
    {
        DAlumnoEmpadronado oDAlumnoEmpadronado;

        public List<SP_ListarAlumnosPadronElectoral_Result> ListarAlumnosEmpadronados_BL()
        {
            int annioEscolar = DateTime.Now.Year;
            oDAlumnoEmpadronado = new DAlumnoEmpadronado();
            return oDAlumnoEmpadronado.ListarAlumnosEmpadronados_DAL(annioEscolar);
        }

        public string GenerarPadronElectoral_BL()
        {
            BDetalleProceso oBDetalleProceso = new BDetalleProceso();
            EDetalleProceso proceso = oBDetalleProceso.ObtenerProceso_BL("Empadronamiento");

            string mensaje = "";

            if (proceso != null)
            {
                int annioEscolar = DateTime.Now.Year;
                oDAlumnoEmpadronado = new DAlumnoEmpadronado();
                List<SP_ListarAlumnosPadronElectoral_Result> result = oDAlumnoEmpadronado.ListarAlumnosPadronElectoral_DAL(annioEscolar);

                EAlumnoEmpadronado oEmpadronado;
                foreach (var alumno in result)
                {
                    oEmpadronado = new EAlumnoEmpadronado()
                    {
                        idAlumno = alumno.idAlumno,
                        añoescolar = annioEscolar,
                        //codalumnoempadronado = 1, 
                        idProceso = proceso.idProceso,
                        estado = "Registrado"
                    };

                    oDAlumnoEmpadronado.RegistrarAlumnoPadronElectoral_DAL(oEmpadronado);
                }
            }
            else
            {
                mensaje = "El proceso no existe o esta fuera de fecha";
            }
            
            return mensaje;
        }

        public int GenerarCredenciales_BL(List<SP_ListarAlumnosPadronElectoral_Result> alumnos)
        {
            EEmail emisor = new EEmail("procesoelectoral@innovaschool.edu.pe", "Innova School");
            int procesados = 0;

            string Plantilla = BOperaciones.GetHtmlPage(HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["PlantillaCredencialesVoto"]));

            foreach (var item in alumnos)
            {
               EEmailStatus status = BEmail.EnviarEmail(emisor, new List<EEmail>() { new EEmail(item.correoElectronico, item.nombre + " " + item.apellidos) },
                    "Credenciales", Plantilla
                    .Replace("{Nombres}", item.nombre)
                    .Replace("{Apellidos}", item.apellidos)
                    .Replace("{Usuario}", "ALUMNO-" + item.idAlumno.ToString())
                    .Replace("{Clave}", "123456")
                    );

               if (status.Estado == true)
               {
                   procesados++;
               }
            }

            return procesados;
        }
    }
}

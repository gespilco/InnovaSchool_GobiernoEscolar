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

        public List<SP_GE_ListarAlumnosPadronElectoral_Result> ListarAlumnosEmpadronados_BL()
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
                List<SP_GE_ListarAlumnosPadronElectoral_Result> result = oDAlumnoEmpadronado.ListarAlumnosPadronElectoral_DAL(annioEscolar);

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

        public int GenerarCredenciales_BL(List<SP_GE_ListarAlumnosPadronElectoral_Result> alumnos)
        {
            EEmail emisor = new EEmail("procesoelectoral@innovaschool.edu.pe", "Innova School");
            int procesados = 0;

            string Plantilla = BOperaciones.GetHtmlPage(HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["PlantillaCredencialesVoto"]));

            EAlumnoEmpadronado oEAlumnoEmpadronado;

            var path = VirtualPathUtility.ToAbsolute("~/GobiernoEscolar/Votacion");
            var urlVotacion = new Uri(HttpContext.Current.Request.Url, path).AbsoluteUri;

            Plantilla = Plantilla.Replace("{UrlVotacion}", urlVotacion);

            foreach (var item in alumnos)
            {
                //Generar usuario y clave
                oDAlumnoEmpadronado = new DAlumnoEmpadronado();

                //Generamos una clave aleatorio de 5 digitos
                string clave = Util.GetRandomNumber(10000, 99999).ToString(); //System.Web.Security.Membership.GeneratePassword(6, 1);

                oEAlumnoEmpadronado = new EAlumnoEmpadronado()
                {
                    idAlumno = item.idAlumno,
                    usuario = double.Parse(item.idAlumno.ToString()).ToString("#000000"), //Su usuario es su codigo de alumno
                    claveAcceso = Util.MD5Crypto(clave) //Encriptamos la clave
                };

                //Generamos las credenciales
                int filas_afectadas = oDAlumnoEmpadronado.GenerarCredencialAlumno_DAL(oEAlumnoEmpadronado);

                if (filas_afectadas > 0)
                {
                    EEmailStatus status = BEmail.EnviarEmail(emisor, new List<EEmail>() { new EEmail(item.correoElectronico, item.nombre + " " + item.apellidos) },
                    "Credenciales", Plantilla
                    .Replace("{Nombres}", item.nombre)
                    .Replace("{Apellidos}", item.apellidos)
                    .Replace("{Usuario}", oEAlumnoEmpadronado.usuario)
                    .Replace("{Clave}", clave)
                    );

                    if (status.Estado == true)
                    {
                        procesados++;
                    }
                }                
            }

            return procesados;
        }

        public SP_GE_ObtenerCredencialesVotacion_Result ObtenerCredencialesVotacion(string usuario, string claveAcceso)
        {
             oDAlumnoEmpadronado = new DAlumnoEmpadronado();
             return oDAlumnoEmpadronado.ObtenerCredencialesVotacion_DAL(usuario, claveAcceso);
        }
    }
}

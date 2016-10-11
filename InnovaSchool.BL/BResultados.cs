using InnovaSchool.DAL;
using InnovaSchool.Entity;
using InnovaSchool.Entity.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovaSchool.BL
{
    public class BResultados
    {
        public List<SP_GE_ListarResultadosVotos_Result> ListarResultadosVotos_BL(int anyo)
        {
            DResultados oDResultados = new DResultados();
            return oDResultados.ListarResultadosVotos_DAL(anyo);
        }

        public SP_GE_ListarConteoVotos_Result ListarConteoVotos_BL(int anyo)
        {
            DResultados oDResultados = new DResultados();
            return oDResultados.ListarConteoVotos_DAL(anyo);
        }

        public object GenerarResultados_BL(int anyo)
        {
            object result = null;
            string mensaje = "";

            BDetalleProceso oBDetalleProceso = new BDetalleProceso();
            var proceso = oBDetalleProceso.ObtenerProcesoVigente_BL("Realizar Votaciones");

            if (proceso == null)
            {
                BPartidoPostulante oBPartidoPostulante = new BPartidoPostulante();

                var resultados = ListarResultadosVotos_BL(anyo);
                var conteo = ListarConteoVotos_BL(anyo);
                
                //Maxima cantidad de votos
                int maxVotacion = resultados.Max(x => x.Votos);
                var ganadores = resultados.Where(x => x.Votos == maxVotacion).ToList();

                object dataPartido = null;

                //Si existe un unico ganador
                if (ganadores.Count == 1)
                {
                    var ganador = ganadores.FirstOrDefault();

                    var p = oBPartidoPostulante.ListarPartidoPostulante_BL(ganador.idPartido);

                    string foto = "";
                    if (p.Logo != null)
                    {
                        foto = string.Format("data:image/png;base64,{0}", System.Convert.ToBase64String(p.Logo));
                        p.Logo = null;
                    }

                    dataPartido = new
                    {
                        Partido = p,
                        Logo = foto,
                        Integrantes = oBPartidoPostulante.ListarIntegrantesPartido_BL(ganador.idPartido)
                    };
                }

                result = new
                {
                    Votos = resultados,
                    Conteo = conteo,
                    Ganador = dataPartido ?? ganadores
                };
            }
            else
            {
                mensaje = "El proceso de votación no ha concluido";
            }

            return result ?? new { Mensaje = mensaje };
        }

        public EEmailStatus Notificar_BL(string html)
        {
            BAlumnoEmpadronado oBAlumnoEmpadronado = new BAlumnoEmpadronado();
            EEmail Emisor = new EEmail("innovaschool2016@gmail.com", "Innova School");
            List<SP_GE_ListarAlumnosPadronElectoral_Result> alumnos = oBAlumnoEmpadronado.ListarAlumnosEmpadronados_BL();
            List<EEmail> Destinatarios = new List<EEmail>();

            foreach (var item in alumnos)
            {
                Destinatarios.Add(new EEmail(item.correoElectronico, item.nombre + " " + item.apellidos));
            }

            EEmailStatus status = BEmail.EnviarEmail(Emisor, Destinatarios, "Resultados Votación", html);

            return status;
        }
    }
}

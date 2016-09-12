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
            BPartidoPostulante oBPartidoPostulante = new BPartidoPostulante();

            var resultados = ListarResultadosVotos_BL(anyo);
            var conteo = ListarConteoVotos_BL(anyo);
            var ganador = resultados.FirstOrDefault();

            dynamic dataPartido = null;
            if (ganador != null)
            {
                //verificamos si existen otros partidos con la misma cantidad de votos
                int cantidad = resultados.Where(x => x.Votos == ganador.Votos).Count();

                //Si existe un unico ganador
                if (cantidad == 1)
                {
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
            }

            var result = new
            {
                Votos = resultados,
                Conteo = conteo,
                Ganador = dataPartido
            };

            return result;
        }

        public EEmailStatus Notificar_BL(string html)
        {
            BAlumnoEmpadronado oBAlumnoEmpadronado = new BAlumnoEmpadronado();
            EEmail Emisor = new EEmail("procesoelectoral@innovaschool.edu.pe", "Innova School");
            List<SP_ListarAlumnosPadronElectoral_Result> alumnos = oBAlumnoEmpadronado.ListarAlumnosEmpadronados_BL();
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

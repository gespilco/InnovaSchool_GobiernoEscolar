﻿using InnovaSchool.DAL;
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
        public List<SP_GE_ListarPartidoPostulante_Result> ListarPartidoPostulante_BL()
        {
            DPartidoPostulante Obj_Dal = new DPartidoPostulante();
            var result = Obj_Dal.ListarPartidoPostulante_DAL();

            foreach(var item in result)
            {
                item.Imagen = null;

                if (item.Logo != null)
                {
                    item.Imagen = string.Format("data:image/png;base64,{0}", System.Convert.ToBase64String(item.Logo));                
                    item.Logo = null;
                }                
            }

            return result;
        }

        public SP_GE_ListarPartidoPostulanteById_Result ListarPartidoPostulante_BL(int IdPartido)
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

        public Dictionary<string, object> ValidarNombrePartido_BL(string nombre)
        {
            DPartidoPostulante Obj_Dal = new DPartidoPostulante();
            var result = Obj_Dal.SP_ValidarNombrePartido_DAL(nombre);            
            return result;
        }

        public SP_GE_ValidarIntegrantePartido_Result ValidarIntegranteInscrito_BL(int idAlumno)
        {
            DPartidoPostulante Obj_Dal = new DPartidoPostulante();
            return Obj_Dal.ValidarIntegranteInscrito_DAL(idAlumno, DateTime.Now.Year);
        }

        public List<SP_GE_ListarIntegrantesPartido_Result> ListarIntegrantesPartido_BL(int idPartido)
        {
            DPartidoPostulante Obj_Dal = new DPartidoPostulante();
            return Obj_Dal.ListarIntegrantesPartido_DAL(idPartido);
        }

        public int EliminarInstrumento_BL(EPartidoPostulante objEN)
        {
            DPartidoPostulante Obj_Dal = new DPartidoPostulante();
            return Obj_Dal.EliminarPartidoPostulante_DAL(objEN);
        }

        public int GenerarCredenciales_BL(List<SP_GE_ListarIntegrantesPartido_Result> alumnos)
        {
            EEmail emisor = new EEmail("innovaschool2016@gmail.com", "Innova School");
            int procesados = 0;

            string Plantilla = BOperaciones.GetHtmlPage(HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["PlantillaCredencialesIntegrante"]));

            var path = VirtualPathUtility.ToAbsolute("~/Account/Login");
            var urlVotacion = new Uri(HttpContext.Current.Request.Url, path).AbsoluteUri;

            Plantilla = Plantilla.Replace("{Url}", urlVotacion);

            BUsuario oBUsuario = new BUsuario();

            foreach (var item in alumnos)
            {
                string usuario = double.Parse(item.idAlumno.ToString()).ToString("#000000");
                string clave = usuario; //Deberia haber una vista para cambiar clave

                oBUsuario.RegistrarUsuario_BL(new EUsuario() { 
                    Usuario = usuario,
                    UPassword = BOperaciones.MD5Crypto(clave),
                    Email = item.Correo,
                    IdPregunta = 1,
                    Respuesta = "",
                    UsuCreacion = "admin",
                    Estado = 1,
                    idPersona = item.idPersona
                });

                EEmailStatus status = BEmail.EnviarEmail(emisor, new List<EEmail>() { new EEmail(item.Correo, item.Nombre) },
                     "Credenciales", Plantilla
                     .Replace("{Nombres}", item.Nombre)                    
                     .Replace("{Usuario}", usuario)
                     .Replace("{Clave}", clave)
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

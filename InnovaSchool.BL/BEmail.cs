using InnovaSchool.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace InnovaSchool.BL
{
    public static class BEmail
    {
        //Configuración esta en Web.config
        public static EEmailStatus EnviarEmail(
            EEmail Emisor,
            List<EEmail> Destinatarios,
            string Asunto, string Cuerpo,
            List<EEmail> CC = null,
            List<EEmail> CCO = null,
            List<Attachment> Adjuntos = null,
            bool FormatoHtml = true)
        {
            try
            {
                using (MailMessage sms = new MailMessage())
                {
                    //Dirección que envia el correo
                    sms.From = new MailAddress(Emisor.Email, Emisor.Nombre);

                    //Destinatarios
                    foreach (EEmail obj in Destinatarios)
                    {
                        if (obj.Email != null && obj.Email != "")
                            sms.To.Add(new MailAddress(obj.Email, obj.Nombre));
                    }

                    //CC (Con Copia)
                    if (CC != null)
                    {
                        foreach (EEmail obj in CC)
                        {
                            if (obj.Email != null && obj.Email != "")
                                sms.CC.Add(new MailAddress(obj.Email, obj.Nombre));
                        }
                    }

                    //CCO (Con Copia oculta)
                    if (CCO != null)
                    {
                        foreach (EEmail obj in CCO)
                        {
                            if (obj.Email != null && obj.Email != "")
                                sms.Bcc.Add(new MailAddress(obj.Email, obj.Nombre));
                        }
                    }

                    //Asunto del correo               
                    sms.Subject = Asunto == null ? "" : Asunto.Replace("\n", " ").Replace("\r", " ");

                    //Cuerpo o contenido del correo
                    if (FormatoHtml)
                    {
                        AlternateView avHtml = AlternateView.CreateAlternateViewFromString(Cuerpo, System.Text.Encoding.UTF8, System.Net.Mime.MediaTypeNames.Text.Html);
                        sms.AlternateViews.Add(avHtml);
                    }
                    else
                    {
                        sms.Body = Cuerpo;
                        //sms.IsBodyHtml = true;
                    }

                    if (Adjuntos != null)
                    {
                        foreach (Attachment archivo in Adjuntos)
                        {
                            sms.Attachments.Add(archivo);
                        }
                    }

                    sms.Priority = MailPriority.Normal;

                    using (SmtpClient smtp = new SmtpClient())
                    {
                        smtp.Send(sms);
                    }

                    return new EEmailStatus
                    {
                        Estado = true,
                        Mensaje = "Se ha enviado el correo a los destinatarios"
                    };
                }
            }
            catch (Exception ex)
            {
                return new EEmailStatus
                {
                    Estado = false,
                    Mensaje = "No se pudo enviar el correo a los destinatarios",
                    ErrorTecnico = ex.Message
                };
            }
        }
    }
}

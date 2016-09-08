using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace InnovaSchool.BL
{
    public static class BOperaciones
    {
        public static string GetHtmlPage(string strURL)
        {
            string strResult = null;
            WebResponse objResponse;
            WebRequest objRequest = HttpWebRequest.Create(strURL);
            objResponse = objRequest.GetResponse();
            using (StreamReader sr = new StreamReader(objResponse.GetResponseStream()))
            {
                strResult = sr.ReadToEnd();
                sr.Close();
            }
            return strResult;
        }
    }
}

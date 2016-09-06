using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
/// <!--
/// Autor: Jaime Acuña
/// Fecha: 21-05-2016
/// Proyecto: Innova School
/// Descripcion: Creación
/// -->
namespace InnovaSchool.UserLayer.Resources
{
    public class Resources
    {
        //public void LimpiarControles(ControlCollection controles)
        //{
        //    foreach (Control control in controles)
        //    {
        //        if (control is TextBox)
        //        {
        //            ((TextBox)control).Text = string.Empty;
        //        }
        //        else if (control is DropDownList)
        //        {
        //            ((DropDownList)control).ClearSelection();
        //        }
        //        else if (control is RadioButtonList)
        //            ((RadioButtonList)control).ClearSelection();
        //        else if (control is CheckBoxList)
        //            ((CheckBoxList)control).ClearSelection();
        //        else if (control is RadioButton)
        //            ((RadioButton)control).Checked = false;
        //        else if (control is CheckBox)
        //            ((CheckBox)control).Checked = false;
        //        else if (control is GridView)
        //            ((GridView)control).DataBind();
        //        else if (control.HasControls())
        //            //Esta linea detécta un Control que contenga otros Controles
        //            //Así ningún control se quedará sin ser limpiado.
        //            LimpiarControles(control.Controls);
        //    }
        //}

        public string MD5Crypto(string text)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));
            byte[] result = md5.Hash;
            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                strBuilder.Append(result[i].ToString("x2"));
            }
            return strBuilder.ToString();
        }

        //public DateTime? GetDateFromTextBox(TextBox txt)
        //{
        //    return string.IsNullOrEmpty(txt.Text) ? null : (DateTime?)Convert.ToDateTime(txt.Text);
        //}

        //public void ControlPageGridView(GridView GrigView, GridViewPageEventArgs e)
        //{
        //    #region ControlPageGridView
        //    if (e.NewPageIndex >= 0 && e.NewPageIndex <= GrigView.PageCount - 1)
        //    {
        //        GrigView.PageIndex = e.NewPageIndex;
        //    }
        //    #endregion
        //}

        ///// <summary>
        ///// Convierte una cadena base 64 a Imagen
        ///// </summary>
        ///// <param name="base64string"></param>
        ///// <returns></returns>
        //public static System.Drawing.Bitmap ConvertStringToImage(string base64string)
        //{
        //    string b64 = base64string.Substring(base64string.IndexOf(",") + 1);
        //    if (IsBase64String(b64))
        //    {
        //        using (System.IO.MemoryStream memStream = new System.IO.MemoryStream(Convert.FromBase64String(b64)))
        //        {
        //            System.Drawing.Image result = System.Drawing.Image.FromStream(memStream);
        //            memStream.Close();
        //            return new System.Drawing.Bitmap(result);
        //        }
        //    }
        //    return null;
        //}

        ///// <summary>
        ///// Convierte una imagen a formato Base64
        ///// </summary>
        ///// <param name="Image">Bitmap image</param>
        ///// <returns></returns>
        ///// <remarks></remarks>
        //public static string ConvertImageToString(System.Drawing.Bitmap Image)
        //{
        //    byte[] byteArray = null;
        //    using (System.IO.MemoryStream stream = new System.IO.MemoryStream())
        //    {
        //        System.Drawing.Bitmap bmp = new System.Drawing.Bitmap((System.Drawing.Bitmap)Image);
        //        bmp.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
        //        byteArray = stream.ToArray();
        //    }
        //    return Convert.ToBase64String(byteArray);
        //}

        public bool IsBase64String(string s)
        {
            s = s.Trim();
            return (s.Length % 4 == 0) && Regex.IsMatch(s, @"^[a-zA-Z0-9\+/]*={0,3}$", RegexOptions.None);
        }
    }
}
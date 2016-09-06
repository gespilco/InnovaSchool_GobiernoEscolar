using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Security.Cryptography;
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
        public void LimpiarControles(ControlCollection controles)
        {
            foreach (Control control in controles)
            {
                if (control is TextBox)
                {
                    ((TextBox)control).Text = string.Empty;
                }
                else if (control is DropDownList)
                {
                    ((DropDownList)control).ClearSelection();
                }
                else if (control is RadioButtonList)
                    ((RadioButtonList)control).ClearSelection();
                else if (control is CheckBoxList)
                    ((CheckBoxList)control).ClearSelection();
                else if (control is RadioButton)
                    ((RadioButton)control).Checked = false;
                else if (control is CheckBox)
                    ((CheckBox)control).Checked = false;
                else if (control is GridView)
                    ((GridView)control).DataBind();
                else if (control.HasControls())
                    //Esta linea detécta un Control que contenga otros Controles
                    //Así ningún control se quedará sin ser limpiado.
                    LimpiarControles(control.Controls);
            }
        }

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

        public DateTime? GetDateFromTextBox(TextBox txt)
        {
            return string.IsNullOrEmpty(txt.Text) ? null : (DateTime?)Convert.ToDateTime(txt.Text);
        }

        public void ControlPageGridView(GridView GrigView, GridViewPageEventArgs e)
        {
            #region ControlPageGridView
            if (e.NewPageIndex >= 0 && e.NewPageIndex <= GrigView.PageCount - 1)
            {
                GrigView.PageIndex = e.NewPageIndex;
            }
            #endregion
        }
    }
}
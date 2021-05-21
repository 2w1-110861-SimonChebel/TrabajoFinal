using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Easy_Stock.Entidades
{
    public static class Validar
    {
        public static bool ValidarCamposVacios(WebControl[] aControles)
        {
            bool bandera = true;
            foreach (var control in aControles)
            {
                if (control != null)
                {
                    if (control.GetType().Name.Equals("TextBox"))
                    {
                        if (string.IsNullOrEmpty(((TextBox)control).Text))
                        {
                            control.BorderColor = Color.Red;
                            bandera = false;
                        }
                    }
                    if (control.GetType().Name.Equals("DropDownList"))
                    {
                        if (((DropDownList)control).SelectedValue == "0")
                        {
                            control.BorderColor = Color.Red;
                            bandera = false;
                        }
                    }
                }
            }
            return bandera;
        }

        public static void ReestablecerColores(WebControl[] aControles)
        {
            foreach (var control in aControles)
            {
                if (control != null)
                {
                    control.BorderColor = Color.LightGray;
                }
            }
        }


        //public static void LimpiarCampos(WebControl[] aControles)
        //{
        //    foreach (var control in aControles)
        //    {
        //        if (control != null)
        //        {
        //            if (control.GetType().Name.Equals("TextBox"))
        //            {
        //                var aux = (TextBox)control;
        //                if (string.IsNullOrEmpty(aux.Text))
        //                {
        //                    control.BorderColor = Color.Red;
        //                }
        //            }
        //            if (control.GetType().Name.Equals("DropDownList"))
        //            {
        //                var aux = (DropDownList)control;
        //                if (aux.SelectedValue == "0")
        //                {
        //                    control.BorderColor = Color.Red;
        //                }
        //            }
        //        }
        //    }
        //}
    }
}
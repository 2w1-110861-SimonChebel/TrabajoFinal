using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Easy_Stock.Entidades
{
    public static class Util
    {
        public static int rango { get; } = 30;
        public static void CargarComboYears(ref DropDownList ddl)
        {
            int yearRange = DateTime.Today.Year - rango;

            for (int i = 0; i <= rango; i++)
            {
                ListItem li = new ListItem
                {
                    Text = yearRange.ToString(),
                    Value = yearRange.ToString()
                };
                ddl.Items.Add(li);
                yearRange++;
            }

        }
    }
}
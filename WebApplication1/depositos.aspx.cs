using Easy_Stock.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Easy_Stock
{
    public partial class depositos : System.Web.UI.Page
    {
        protected Sucursal oSucursal;
        protected void Page_Load(object sender, EventArgs e)
        {
            oSucursal = new Sucursal();
        }
    }
}
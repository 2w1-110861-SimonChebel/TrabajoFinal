using Easy_Stock.AccesoDatos;
using Easy_Stock.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Easy_Stock
{
    public partial class home : Page
    {
        protected List<Transaccion> lstTransacciones;
        protected List<Producto> lstProductos;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["transaction"] != null && Request.QueryString["transaction"].Equals("ok"))
                {
                    divMensaje.Visible = true;
                    divMensaje.Attributes["class"] = Bootstrap.alertSuccesDismissable;
                    hMensaje.InnerText = "La transacción se realizó correctamente";
                }
                if ((Request.QueryString["devolucion"] != null && Request.QueryString["devolucion"].Equals("ok")))
                {
                    divMensaje.Visible = true;
                    divMensaje.Attributes["class"] = Bootstrap.alertSuccesDismissable;
                    hMensaje.InnerText = "Devolución realizada correctamente";
                }
                lstTransacciones = AdTransaccion.obtenerTransacciones(true);
                lstProductos = AdProducto.obtenerProductos("", true);
            }
        }
    }
}
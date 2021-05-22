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
                lstTransacciones = AdTransaccion.obtenerTransacciones(true);
                lstProductos = AdProducto.obtenerProductos("",true);
            }
        }
    }
}
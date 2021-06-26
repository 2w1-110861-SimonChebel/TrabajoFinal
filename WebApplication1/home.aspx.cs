﻿using Easy_Stock.AccesoDatos;
using Easy_Stock.Entidades;
using System;
using System.Collections.Generic;
using System.Web.UI;


namespace Easy_Stock
{
    public partial class home : Page
    {
        protected List<Transaccion> lstTransacciones;
        protected List<Producto> lstProductos;
        protected List<Producto> lstProductosStock;
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
                if ((Request.QueryString["cambio"] != null && Request.QueryString["cambio"].Equals("ok")))
                {
                    divMensaje.Visible = true;
                    divMensaje.Attributes["class"] = Bootstrap.alertSuccesDismissable;
                    hMensaje.InnerText = "Cambio realizado correctamente";
                }

                lstTransacciones = AdTransaccion.ObtenerTransacciones(true);
                lstProductos = AdProducto.ObtenerProductos("", true);
                lstProductosStock = AdProducto.ObtenerProductosStock();
            }
        }

        protected void btnVerDetalle_Click(object sender, EventArgs e)
        {

        }

        protected void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            lstProductosStock = AdProducto.ObtenerProductosStock();
        }
    }
}
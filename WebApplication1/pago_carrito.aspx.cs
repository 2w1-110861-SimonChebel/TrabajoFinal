﻿using Easy_Stock.AccesoDatos;
using Easy_Stock.Entidades;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Easy_Stock
{
    public partial class pago_carrito : Page
    {
        protected Cliente oClienteCarrito;
        protected Usuario oUsuario;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtTipoTran.Text = Session["tipoTranActual"] != null ? ((TipoTransaccion)Session["tipoTranActual"]).tipoTransaccion: "Undefined";
                this.oClienteCarrito = (Cliente)Session["clienteCarrito"];
                Carrito aux = (Carrito)Session["carrito"];
                grvProductos.DataSource = ((Carrito)Session["carrito"]).productos;
                grvProductos.DataBind();
                this.oUsuario = (Usuario)Session["usuario"];
                txtCliente.Text = string.Format("{0} {1}", oClienteCarrito.tipoCliente.idTipoCliente == 1 ? this.oClienteCarrito.nombre : oClienteCarrito.razonSocial, oClienteCarrito.tipoCliente.idTipoCliente == 1 ? this.oClienteCarrito.apellido : string.Empty);
                txtDniCLiente.Text = string.Format("{0}", this.oClienteCarrito.tipoCliente.idTipoCliente == 1 ? oClienteCarrito.dni : oClienteCarrito.cuit);
                txtDireccion.Text = oClienteCarrito.direccion;
                txtBarrio.Text = oClienteCarrito.barrio;
                txtLocalidad.Text = oClienteCarrito.localidad.localidad;
                txtProvincia.Text = oClienteCarrito.provincia.provincia;
                hTotal.InnerText = string.Format("{0} {1}", "Total: $", aux.calcularTotalProductos());
                cargarCombos();
            }


        }

        private void cargarCombos()
        {
            List<FormaPago> lstFormasPago = AdGeneral.obtenerFormasDePago();
            List<TipoFactura> lstTipoFactura = AdGeneral.obtenerTiposFacturas();

            cboFormaPago.DataSource = null;
            cboFormaPago.DataBind();
            cboFormaPago.DataSource = lstFormasPago;
            for (int i = 0; i < lstFormasPago.Count; i++)
            {
                ListItem li = new ListItem
                {
                    Text = lstFormasPago[i].formaPago,
                    Value = string.Format("{0}{1}{2}", lstFormasPago[i].idFormaPago.ToString(), ",", lstFormasPago[i].porcentajeRecargo)
                };
                cboFormaPago.Items.Add(li);
            }

            cboTipoFactura.DataSource = null;
            cboTipoFactura.DataBind();
            cboTipoFactura.DataSource = lstTipoFactura;
            for (int i = 0; i < lstTipoFactura.Count; i++)
            {
                ListItem li = new ListItem
                {
                    Text = lstTipoFactura[i].tipoFactura,
                    Value = lstTipoFactura[i].idTipoFactura.ToString()
                };
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Session["carrito"] = null;
            Session["clienteCarrito"] = null;
            Session["tipoTranActual"] = null;
            Response.Redirect("home.aspx", false);
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {

            if (cboFormaPago.SelectedValue != "0" || cboTipoFactura.SelectedValue !="0")
            {
                string[] valuesFormaPago = cboFormaPago.SelectedValue.Split(',');
                Carrito aux = (Carrito)Session["carrito"];
                List<DetalleFactura> lstDetalle = new List<DetalleFactura>();
                foreach (var item in aux.productos)
                {
                    lstDetalle.Add(new DetalleFactura
                    {
                        cantidad = item.cantidad,
                        producto = item,
                        iva = 0,
                        subTotal = item.calcularSubTotal(),
                        precio = item.precioVenta
                    });
                }
                VentaCliente oVenta = new VentaCliente
                {
                    fecha = DateTime.Now,
                    descripcion = string.Empty,
                    proveedor = null,
                    descuento = 0,
                    total = aux.calcularTotalProductos(),
                    formaPago = new FormaPago
                    {
                        idFormaPago = Convert.ToInt32(valuesFormaPago[0]),
                        formaPago = cboFormaPago.SelectedItem.Text
                    },
                    tipoTransaccion = new TipoTransaccion
                    {
                        idTipoTransaccion = ((TipoTransaccion)Session["tipoTranActual"]).idTipoTransaccion,
                        tipoTransaccion = ((TipoTransaccion)Session["tipoTranActual"]).tipoTransaccion
                    },
                    factura = new Factura
                    {
                        fecha = DateTime.Now,
                        total = aux.calcularTotalProductos(),
                        observaciones = string.Empty,
                        cliente = (Cliente)Session["clienteCarrito"],
                        empresa = (Empresa)Session["empresa"],
                        usuario = (Usuario)Session["usuario"],
                        detallesFactura = lstDetalle,
                        tipoFactura = new TipoFactura
                        {
                            idTipoFactura = Convert.ToInt32(cboTipoFactura.SelectedValue),
                            tipoFactura = cboTipoFactura.SelectedItem.Text
                        },
                        iva = 0
                    },


                };
                if (AdTransaccion.RegistrarVenta(oVenta))
                {
                    Session["carrito"] = null;
                    Session["clienteCarrito"] = null;
                    Session["tipoTranActual"] = null;
                    Session["productos"] = null;
                    Session["clientes"] = null;
                    Response.Redirect("home.aspx?transaction=ok");
                }
                else
                {
                    divMensaje.Visible = true;
                    hMensaje.InnerText = "Hubo un error al realizar la transacción. Intente nuevamente.";
                }
            }
            else {
                if(cboFormaPago.SelectedValue =="0") cboFormaPago.BorderColor = Color.Red;
                if (cboTipoFactura.SelectedValue == "0")  cboTipoFactura.BorderColor = Color.Red;
            }

        }

        protected void btnVolverCarrito_Click(object sender, EventArgs e)
        {
            Session["carrito"] = (Carrito)Session["carrito"];
            Response.Redirect("productos.aspx?accion=carrito");
        }

        protected void grvProductos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void grvProductos_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }
    }
}
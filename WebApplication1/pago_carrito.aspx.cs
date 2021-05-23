using Easy_Stock.AccesoDatos;
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
                this.oClienteCarrito = (Cliente)Session["clienteCarrito"];
                Carrito aux = (Carrito)Session["carrito"];
                grvProductos.DataSource = ((Carrito)Session["carrito"]).productos;
                grvProductos.DataBind();
                this.oUsuario = (Usuario)Session["usuario"];
                txtCliente.Text = string.Format("{0} {1}", oClienteCarrito.tipoCliente.idTipoCliente == 1 ? this.oClienteCarrito.nombre : oClienteCarrito.razonSocial, oClienteCarrito.tipoCliente.idTipoCliente == 1 ? this.oClienteCarrito.apellido : string.Empty);
                //txtUsuario.Text = string.Format("{0} {1}", this.oUsuario.nombre, this.oUsuario.apellido);
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
            List<FormaPago> lst = AdGeneral.obtenerFormasDePago();
            cboFormaPago.DataSource = null;
            cboFormaPago.DataBind();
            cboFormaPago.DataSource = lst;
            for (int i = 0; i < lst.Count; i++)
            {
                ListItem li = new ListItem
                {
                    Text = lst[i].formaPago,
                    Value = string.Format("{0}{1}{2}", lst[i].idFormaPago.ToString(), ",", lst[i].porcentajeRecargo)
                };
                cboFormaPago.Items.Add(li);
            }

            List<TipoTransaccion> lstTiposTransacciones = AdGeneral.obtenerTiposTransacciones();
            cboTipoTransaccion.DataSource = null;
            cboTipoTransaccion.DataBind();
            cboTipoTransaccion.DataSource = lstTiposTransacciones;

            for (int i = 0; i < lstTiposTransacciones.Count; i++)
            {
                ListItem li = new ListItem
                {
                    Text = lstTiposTransacciones[i].tipoTransaccion,
                    Value = lstTiposTransacciones[i].idTipoTransaccion.ToString()
                };
                cboTipoTransaccion.Items.Add(li);
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {

        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {

            if (cboFormaPago.SelectedValue != "0")
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
                        idTipoTransaccion = 1 //CAMBIARRRRRRRRRRRRRRR
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
                            idTipoFactura = 1
                        },
                        iva = 0
                    },


                };
                if (AdTransaccion.RegistrarVenta(oVenta))
                {
                    Session["carrito"] = null;
                    Session["clienteCarrito"] = null;
                    Response.Redirect("home.aspx?transaction=ok");
                }
                else
                {
                    divMensaje.Visible = true;
                    hMensaje.InnerText = "Hubo un error al realizar la transacción. Intente nuevamente.";
                }
            }
            else {
                cboFormaPago.BorderColor = Color.Red;
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
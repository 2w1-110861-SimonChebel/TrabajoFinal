using Easy_Stock.AccesoDatos;
using Easy_Stock.Entidades;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Easy_Stock
{
    public partial class devolucion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["accion"] = Request.QueryString["accion"];
                if (!string.IsNullOrEmpty(Request.QueryString["idTran"]) && (!string.IsNullOrEmpty(Request.QueryString["idCli"])))
                {
                    grvDetalleVenta.DataSource = Session["facturaVentaDevolucion"] != null ? ((Factura)Session["facturaVentaDevolucion"]).listaProductosIndividuales() : null;
                    grvDetalleVenta.DataBind();
                }
                else {
                    cargarCombos();
                }
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            divMensaje.Visible = false;
            divMensajeResult.Visible = false;
            grvVentas.DataSource = null;
            grvVentas.DataBind();
            WebControl[] aControles = new WebControl[] {
                txtCliente,
                txtNroVenta,
                cboUsuario,
                dtpFecha
            };

            if (Validar.HayUnCampoSeleccionado(aControles))
            {
                Cliente cli = null;
                Usuario usu = null;

                if (!string.IsNullOrEmpty(txtCliente.Text)) cli = new Cliente { nombre = txtCliente.Text, apellido = txtCliente.Text, razonSocial = txtCliente.Text };
                if (Convert.ToInt32(cboUsuario.SelectedValue) > 0) usu = new Usuario { idUsuario = Convert.ToInt32(cboUsuario.SelectedValue) };
                List<VentaCliente> lstVentas = AdTransaccion.obtenerVentasCliente(txtNroVenta.Text != "" ? Convert.ToInt32(txtNroVenta.Text) : 0, cli, usu, dtpFecha.Text);
                if (lstVentas != null)
                {
                    grvVentas.DataSource = lstVentas;
                    grvVentas.DataBind();
                }
                else
                {
                    divMensajeResult.Visible = true;
                    divMensajeResult.Attributes["class"] = Bootstrap.alertWarningDismissable;
                    hResult.InnerText = "No se encontraron resultados.";
                }
            }
            else {
                divMensaje.Visible = true;
                divMensaje.Attributes["class"] = Bootstrap.alertDangerDismissable;
                hMensaje.InnerText = "Debe completar al menos un (1) filtro";
            }
            return;
        }

        protected void grvVentas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void grvVentas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string accion = Request.QueryString["accion"].ToString();
            string[] arg = e.CommandArgument.ToString().Split(',');
            int idTransaccion = Convert.ToInt32(arg[0]);
            int idCliente = Convert.ToInt32(arg[1]);
            Factura oFactura = AdTransaccion.obtenerFacturas(idTransaccion);
            Session["facturaVentaDevolucion"] = oFactura;
            Session["idTransaccionDevolucion"] = idTransaccion;
            Response.Redirect("devolucion.aspx?idTran=" + idTransaccion + "&idCli=" + idCliente+"&accion="+accion);
            //grvDetalleVenta.DataSource = oFactura != null ? oFactura.detallesFactura : null;
            //grvDetalleVenta.DataBind();
        }

        private void cargarCombos()
        {
            List<Usuario> lstUsuarios = AdUsuario.ObtenerUsuarios();
            cboUsuario.DataSource = null;
            cboUsuario.DataBind();
            for (int i = 0; i < lstUsuarios.Count; i++)
            {
                ListItem li = new ListItem
                {
                    Text = string.Format("{0} {1}", lstUsuarios[i].nombre, lstUsuarios[i].apellido),
                    Value = lstUsuarios[i].idUsuario.ToString()
                };
                cboUsuario.Items.Add(li);
            }
        }

        protected void btnElegirVenta_Click(object sender, EventArgs e)
        {

        }

        protected void grvDetalleVenta_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void grvDetalleVenta_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int auxCantidad = 0;
            decimal total = 0;
            string auxAccion = Session["accion"].ToString();

            if (auxAccion.Equals("cambio")) auxCantidad = Session["cantidad"] != null ? Convert.ToInt32(Session["cantidad"]) : 0;

            if (divMensaje.Visible) divMensaje.Visible = false;
            string[] argumentos = e.CommandArgument.ToString().Split(',');
            string codigoUnico = argumentos[0];
            int fila = Convert.ToInt32(argumentos[1]);
            if(auxAccion.Equals("devolucion")) total = Session["total"] != null && !rbDevolucionTotal.Checked ? ((decimal)Session["total"]) : 0;
            List<Producto> lstProductosDevolver = Session["productosDevolver"] == null ? new List<Producto>() : (List<Producto>)Session["productosDevolver"];
            foreach (var item in ((Factura)Session["facturaVentaDevolucion"]).detallesFactura)
            {
                if (item.producto.codigoUnico == codigoUnico) {

                    if ((grvDetalleVenta.Rows[fila].Cells[5].FindControl("chkSeleccion") as CheckBox).Checked)
                    {
                        lstProductosDevolver.Remove(item.producto);
                        total -= item.precio;
                        auxCantidad--;

                        if (auxAccion.Equals("devolucion"))  hTotal.InnerText = "Total a devolver: $" + total;
                        else hCantidad.InnerText = "Cantidad de productos a devolver: " +auxCantidad;

                        Session["productosDevolver"] = lstProductosDevolver;
                        (grvDetalleVenta.Rows[fila].Cells[5].FindControl("chkSeleccion") as CheckBox).Checked = false;
                        (grvDetalleVenta.Rows[fila].Cells[5].FindControl("chkSeleccion") as CheckBox).Visible = false;
                        (grvDetalleVenta.Rows[fila].Cells[5].FindControl("btnSeleccionar") as LinkButton).Attributes["class"] = "btn btn-success";
                        (grvDetalleVenta.Rows[fila].Cells[5].FindControl("btnSeleccionar") as LinkButton).Text = "Agregar";
                        if (lstProductosDevolver.Count < 1) Session["productosDevolver"] = null;
                        break;
                    }
                    else {
                        lstProductosDevolver.Add(item.producto);
                        if (auxAccion.Equals("devolucion")) total += item.precio;
                        else auxCantidad++;
                        if (auxAccion.Equals("devolucion")) hTotal.InnerText = "Total a devolver: $" + total;
                        else hCantidad.InnerText = "Cantidad de productos a devolver: " + auxCantidad;
                        Session["productosDevolver"] = lstProductosDevolver;

                        (grvDetalleVenta.Rows[fila].Cells[5].FindControl("chkSeleccion") as CheckBox).Checked = true;
                        (grvDetalleVenta.Rows[fila].Cells[5].FindControl("chkSeleccion") as CheckBox).Visible = true;
                        (grvDetalleVenta.Rows[fila].Cells[5].FindControl("btnSeleccionar") as LinkButton).Attributes["class"] = "btn btn-danger";
                        (grvDetalleVenta.Rows[fila].Cells[5].FindControl("btnSeleccionar") as LinkButton).Text = "Quitar";
                        break;
                    }

                }
            }
            Session["total"] = total;
            Session["cantidad"] = auxCantidad;

        }

        protected void rbDevolucionParcial_CheckedChanged(object sender, EventArgs e)
        {
            divMensaje.Visible = false;
            Session["total"] = null;
            Session["cantidad"] = null;
            Session["productosDevolver"] = null;
            foreach (GridViewRow fila in grvDetalleVenta.Rows)
            {

                if ((grvDetalleVenta.Rows[fila.RowIndex].Cells[4].FindControl("chkSeleccion") as CheckBox).Checked)
                {
                    _ = (grvDetalleVenta.Rows[fila.RowIndex].Cells[4].FindControl("chkSeleccion") as CheckBox).Enabled = false;
                    _ = (grvDetalleVenta.Rows[fila.RowIndex].Cells[4].FindControl("chkSeleccion") as CheckBox).Checked = false;
                    (grvDetalleVenta.Rows[fila.RowIndex].Cells[5].FindControl("btnSeleccionar") as LinkButton).Attributes["class"] = "btn btn-success";
                    (grvDetalleVenta.Rows[fila.RowIndex].Cells[5].FindControl("btnSeleccionar") as LinkButton).Text = "Agregar";
                    (grvDetalleVenta.Rows[fila.RowIndex].Cells[5].FindControl("btnSeleccionar") as LinkButton).Enabled = true;
                }

            }
            if (Session["accion"].Equals("devolucion")) hTotal.InnerText = "Total a devolver: $0,0";
            else hCantidad.InnerText = "Cantidad de productos a devolver: 0";
        }

        protected void rbDevolucionTotal_CheckedChanged(object sender, EventArgs e)
        {
            divMensaje.Visible = false;
            Session["totalDevolver"] = null;
            decimal total = 0;
            int cantidad = Session["cantidad"]!= null ? Convert.ToInt32(Session["cantidad"]):0;
            foreach (DetalleFactura df in ((Factura)Session["facturaVentaDevolucion"]).detallesFactura)
            {
                total += df.producto.calcularSubTotal();
                cantidad++;
            }

            foreach (GridViewRow fila in grvDetalleVenta.Rows)
            {
                _ = (grvDetalleVenta.Rows[fila.RowIndex].Cells[4].FindControl("chkSeleccion") as CheckBox).Checked = true;
                _ = (grvDetalleVenta.Rows[fila.RowIndex].Cells[4].FindControl("chkSeleccion") as CheckBox).Enabled = false;
                //(grvDetalleVenta.Rows[fila.RowIndex].Cells[5].FindControl("chkSeleccion") as CheckBox).Checked = true;
                (grvDetalleVenta.Rows[fila.RowIndex].Cells[5].FindControl("chkSeleccion") as CheckBox).Visible = true;
                //(grvDetalleVenta.Rows[fila.RowIndex].Cells[5].FindControl("btnSeleccionar") as LinkButton).Attributes["class"] = "btn btn-warning";
                (grvDetalleVenta.Rows[fila.RowIndex].Cells[5].FindControl("btnSeleccionar") as LinkButton).Text = "Seleccionado";
                (grvDetalleVenta.Rows[fila.RowIndex].Cells[5].FindControl("btnSeleccionar") as LinkButton).Enabled = false;
            }
            if (Session["accion"].Equals("devolucion"))
            {
                hTotal.InnerText = "Total a devolver: $" + total;
                Session["total"] = total;
            }
            else {
                hCantidad.InnerText = "Cantidad de productos a devolver: " + cantidad;
                Session["cantidad"] = cantidad;
            }
           

        }

        //private string obtenerValorNumerico(string cadena)
        //{
        //    string resultado = Regex.Replace(cadena, "<.*?>", string.Empty);
        //    return resultado;
        //}

        protected void btnSeleccionarProductos_Click(object sender, EventArgs e)
        {
            //rbDevolucionTotal_CheckedChanged(sender, e);
        }

        protected void chkSeleccion_CheckedChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow fila in grvDetalleVenta.Rows)
            {
                _ = (grvDetalleVenta.Rows[fila.RowIndex].Cells[4].FindControl("chkSeleccion") as CheckBox).Checked = true;
                _ = (grvDetalleVenta.Rows[fila.RowIndex].Cells[4].FindControl("chkSeleccion") as CheckBox).Enabled = false;
                //html precio = (WebControl)grvDetalleVenta.Rows[fila.RowIndex].Cells[3].FindControl("divPrecio");
                //string cio = obtenerValorNumerico(precio.ToString());
                //total += Convert.ToDecimal( grvDetalleVenta.Rows[fila.RowIndex].Cells[3].FindControl("divPrecio"));
            }
        }

        protected void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (!rbDevolucionParcial.Checked) rbDevolucionParcial.Checked = true;
        }

        protected void btnFinalizar_Click(object sender, EventArgs e)
        {
            if (Session["productosDevolver"] == null)
            {
                divMensaje.Visible = true;
                divMensaje.Attributes["class"] = Bootstrap.alertDangerDismissable;
                hMensaje.InnerText = "Debe seleccionar uno o más productos a devolver.";
            }
            else {

                int idTransaccion = (int)Session["idTransaccionDevolucion"];
                decimal montoDevolver = rbCreditoAfavor.Checked ? (decimal)Session["total"] : 0;
                int tipoDevolucion = rbCreditoAfavor.Checked ? (int)Tipo.tipoDevolucionDineroCliente.creditoAfavorDeCliente : rbDevolverDinero.Checked ? (int)Tipo.tipoDevolucionDineroCliente.montoDevueltoAcliente : 0;
                int tipoTransaccion = (int)Tipo.tipoTransaccion.devolucionDeCliente;
                DateTime fecha = DateTime.Now;
                int idCliente = ((Factura)Session["facturaVentaDevolucion"]).cliente.idCliente; /*Request.QueryString["idClie"] != null ? Convert.ToInt32(Request.QueryString["idClie"]) : (int)Session["idClienteDevolucion"];*/
                if (rbDevolucionTotal.Checked)
                {
                    Factura oFactura = (Factura)Session["facturaVentaDevolucion"];
                    if (AdTransaccion.DevolverProductos(oFactura, 0, montoDevolver, idTransaccion, fecha, tipoDevolucion, tipoTransaccion, ((Usuario)Session["usuario"]).idUsuario))
                    {
                        LimpiarForm();
                    }
                    else
                    {
                        MostrarMensajeError();
                    }
                }
                if (rbDevolucionParcial.Checked)
                {
                    List<Producto> lstProd = (List<Producto>)Session["productosDevolver"];
                    List<DetalleFactura> lstDetalleAux = new List<DetalleFactura>();

                    foreach (var producto in lstProd)
                    {
                        foreach (var item in ((Factura)Session["facturaVentaDevolucion"]).detallesFactura)
                        {
                            if (producto.codigoUnico == item.producto.codigoUnico)
                            {
                                DetalleFactura aux = new DetalleFactura();
                                aux = item;
                                aux.producto = producto;
                                lstDetalleAux.Add(aux);
                            }

                        }
                    }
                   
                    if (AdTransaccion.DevolverProductos(new Factura { detallesFactura = lstDetalleAux }, idCliente, montoDevolver, idTransaccion, fecha, tipoDevolucion, tipoTransaccion, ((Usuario)Session["usuario"]).idUsuario))
                    {
                        LimpiarForm();
                    }
                    else {
                        MostrarMensajeError();
                    }

                }
            }

        }

        private void LimpiarForm()
        {
            Session["facturaVentaDevolucion"] = null;
            Session["idTransaccionDevolucion"] = null;
            Session["productosDevolver"] = null;
            Session["total"] = null;
            Session["cantidad"] = null;
            string dev = Session["accion"].Equals("devolucion") ? "devolucion" : "cambio";
            Response.Redirect("home.aspx?devolucion=ok");
        }

        private void MostrarMensajeError()
        {
            divMensaje.Visible = true;
            divMensaje.Attributes["class"] = Bootstrap.alertDangerDismissable;
            hMensaje.InnerText = "Hubo un error al realizar la acción. Intente nuevamente";
        }
    }
}
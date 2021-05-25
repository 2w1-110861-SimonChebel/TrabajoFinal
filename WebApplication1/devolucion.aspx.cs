using Easy_Stock.AccesoDatos;
using Easy_Stock.Entidades;
using System;
using System.Collections.Generic;
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
                if(Convert.ToInt32(cboUsuario.SelectedValue)>0) usu = new Usuario { idUsuario = Convert.ToInt32(cboUsuario.SelectedValue) };
                List<VentaCliente> lstVentas = AdTransaccion.obtenerVentasCliente( txtNroVenta.Text != ""? Convert.ToInt32(txtNroVenta.Text):0, cli, usu, dtpFecha.Text);
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
        }

        protected void grvVentas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void grvVentas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string[] arg = e.CommandArgument.ToString().Split(',');
            int idTransaccion = Convert.ToInt32(arg[0]);
            int idCliente = Convert.ToInt32(arg[1]);
            Factura oFactura = AdTransaccion.obtenerFacturas(idTransaccion);
            Session["facturaVentaDevolucion"] = oFactura;
            Response.Redirect("devolucion.aspx?idTran=" + idTransaccion + "&idCli=" + idCliente);
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
                    Text =string.Format("{0} {1}", lstUsuarios[i].nombre,lstUsuarios[i].apellido),
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

        }

        protected void rbDevolucionParcial_CheckedChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow fila in grvDetalleVenta.Rows)
            {
                _ = (grvDetalleVenta.Rows[fila.RowIndex].Cells[4].FindControl("chkSeleccion") as CheckBox).Checked=false;
                _ = (grvDetalleVenta.Rows[fila.RowIndex].Cells[4].FindControl("chkSeleccion") as CheckBox).Enabled = true;
            }
        }

        protected void rbDevolucionTotal_CheckedChanged(object sender, EventArgs e)
        {
            decimal total = 0;
            foreach (GridViewRow fila in grvDetalleVenta.Rows)
            {
                _ = (grvDetalleVenta.Rows[fila.RowIndex].Cells[4].FindControl("chkSeleccion") as CheckBox).Checked = true;
                _ = (grvDetalleVenta.Rows[fila.RowIndex].Cells[4].FindControl("chkSeleccion") as CheckBox).Enabled = false;
                //html precio = (WebControl)grvDetalleVenta.Rows[fila.RowIndex].Cells[3].FindControl("divPrecio");
                //string cio = obtenerValorNumerico(precio.ToString());
                //total += Convert.ToDecimal( grvDetalleVenta.Rows[fila.RowIndex].Cells[3].FindControl("divPrecio"));
            }
            //hTotal.InnerText = "Total a devolver: $" + total;
        }

        private string obtenerValorNumerico(string cadena)
        {
            string resultado = Regex.Replace(cadena, "<.*?>", string.Empty);
            return resultado;
        }


    }
}
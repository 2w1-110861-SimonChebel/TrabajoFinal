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
    public partial class pago_carrito : Page
    {
        protected Cliente oClienteCarrito;
        protected Usuario oUsuario;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.oClienteCarrito = (Cliente)Session["clienteCarrito"];
            Carrito aux = (Carrito)Session["carrito"];
            grvProductos.DataSource = ((Carrito)Session["carrito"]).lstProductos ;
            grvProductos.DataBind();
            this.oUsuario = (Usuario)Session["usuario"];
            txtCliente.Text = string.Format("{0} {1}",oClienteCarrito.tipoCliente.idTipoCliente==1? this.oClienteCarrito.nombre:oClienteCarrito.razonSocial, oClienteCarrito.tipoCliente.idTipoCliente == 1 ? this.oClienteCarrito.apellido:string.Empty);
            //txtUsuario.Text = string.Format("{0} {1}", this.oUsuario.nombre, this.oUsuario.apellido);
            txtDniCLiente.Text = string.Format("{0}", this.oClienteCarrito.tipoCliente.idTipoCliente==1 ? oClienteCarrito.dni : oClienteCarrito.cuit);
            txtDireccion.Text = oClienteCarrito.direccion;
            txtBarrio.Text = oClienteCarrito.barrio;
            txtLocalidad.Text = oClienteCarrito.localidad.localidad;
            txtProvincia.Text = oClienteCarrito.provincia.provincia;
            hTotal.InnerText = string.Format("{0} {1}", "Total: $", aux.calcularTotalProductos());
            cargarCombo();

        }

        private void cargarCombo()
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
                    Value = lst[i].idFormaPago.ToString()
                };
                cboFormaPago.Items.Add(li);
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {

        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {

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
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
    public partial class cliente_carrito : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            string documento = txtBuscarCliente.Text;
            if (string.IsNullOrEmpty(documento)) return;
            Cliente oCliente = null;
            List<Cliente> lst = AdCliente.obtenerClientes("", 0, documento);
            if (lst != null) oCliente = lst.FirstOrDefault();                      
            Session["clienteCarrito"] = oCliente;
            if (oCliente != null)
            {
                divMensaje.Visible = false;
                grvClienteCarrito.DataSource = new List<Cliente> { oCliente };
                grvClienteCarrito.DataBind();
            }
            else
            {
                divMensaje.Visible = true;
                grvClienteCarrito.DataSource = null;
                grvClienteCarrito.DataBind();
            }
           
        }

        protected void btnAgregarNuevoCliente_Click(object sender, EventArgs e)
        {
            Response.Redirect("editar_clientes.aspx?accion=cli_carrito&doc=" + (!string.IsNullOrEmpty(txtBuscarCliente.Text) ? txtBuscarCliente.Text : "0"));
        }

        protected string devolverFechaSinHorario(DateTime fecha)
        {
            return fecha.ToShortDateString();
        }

        protected void grvClienteCarrito_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void grvClienteCarrito_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int idCliente = Convert.ToInt32(e.CommandArgument);
            return;
        }
    }
}
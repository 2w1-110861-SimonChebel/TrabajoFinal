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
    public partial class productos : System.Web.UI.Page
    {
        protected List<Producto> lstProductos = new List<Producto>();
        Carrito oCarrito = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            string accion = string.IsNullOrEmpty(Request.QueryString["accion"]) ? string.Empty : Request.QueryString["accion"];
            if (!IsPostBack)
            {
                divMensaje.Visible = false;
                lstProductos = AdProducto.obtenerProductos();
                grvProductos.DataSource = lstProductos;
                grvProductos.DataBind();
                if (!string.IsNullOrEmpty(accion) && accion.Equals("carrito"))
                {
                    grvProductos.Columns[14].Visible = false;
                    grvProductos.Columns[15].Visible = true;
                    if (Session["carrito"] != null) {
                        grvCarrito.DataSource = ((Carrito)Session["carrito"]).productos;
                        grvCarrito.DataBind();
                    }
                }
                else
                {
                    grvProductos.Columns[14].Visible = true;
                    grvProductos.Columns[15].Visible = false;
                }


            }
        }

        protected void btnEditarProducto_Click(object sender, EventArgs e)
        {
            
        }

        protected void btnBuscarProducto_Click(object sender, EventArgs e) 
        {
            string nombre = txtBuscarProducto.Text;
            lstProductos = AdProducto.obtenerProductos(nombre);

            if (lstProductos != null && lstProductos.Count > 0)
            {
                grvProductos.DataSource = lstProductos;
                grvProductos.DataBind();
                divMensaje.Visible = false;
            }
            else 
            {
                divMensaje.Visible = true;
                grvProductos.DataSource = null;
                grvProductos.DataBind();
            }
        }
        protected void btnEliminarProducto_Click(object sender, EventArgs e)
        {
         
        }
        protected void grvProductos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string[] argumentos = e.CommandArgument.ToString().Split(',');
            int idProducto = Convert.ToInt32(argumentos[0]);
            int fila = Convert.ToInt32(argumentos[1]);
            if (e.CommandName.Equals("editar"))
            {              
                Response.Redirect("editar_producto.aspx?id=" + idProducto.ToString() +"&accion="+e.CommandName);
            }
            if(e.CommandName.Equals("eliminar"))
            {
                if(AdProducto.eliminarProductoPorId(idProducto))
                {
                    divMensaje.Visible = true;
                    divMensaje.InnerText = "Producto eliminado correctamente";
                    divMensaje.Style["class"] = "alert alert-success";
                    Response.Redirect("productos.aspx");
                }
                else
                {                  
                    divMensaje.InnerText = "Hubo un error al eliminar el producto";
                    divMensaje.Style["class"] = "alert alert-danger";
                    Response.Redirect("productos.aspx");
                }
           
            }
            if (e.CommandName.Equals("agregarCarrito"))
            {

                TextBox txtCant = (grvProductos.Rows[fila].Cells[15].FindControl("txtCantidadProducto") as TextBox);
                int cantidad = (txtCant != null && !string.IsNullOrEmpty(txtCant.Text))? Convert.ToInt32(txtCant.Text):0;
                if (cantidad < 1) return;
                else
                {
                    if (Session["carrito"] == null) oCarrito = new Carrito();
                    else { oCarrito = (Carrito)Session["carrito"]; }
                    grvCarrito.DataSource = null;
                    grvCarrito.DataBind();
                    divTotal.Visible = true;
                    Producto oProducto = lstProductos!=null && lstProductos.Count>0 ? buscarProductoLocal(idProducto): AdProducto.obtenerProductoPorId(idProducto);
                    oProducto.cantidad = cantidad;
                    oCarrito.agregarProducto(oProducto);
                    Session["carrito"] = oCarrito;
                    hTotal.InnerText = string.Format("{0} {1}","Total: $", oCarrito.calcularTotalProductos().ToString());
                    (grvProductos.Rows[fila].Cells[15].FindControl("txtCantidadProducto") as TextBox).BackColor = Color.Beige;
                    grvCarrito.DataSource = oCarrito.productos;
                    grvCarrito.DataBind();
                }
                

            }
                           
        }
        private Producto buscarProductoLocal(int idProducto)
        {
            foreach (var item in this.lstProductos)
            {
                if (item.idProducto == idProducto) return item;
            }
            return null;
        }

        protected void btnAgregarProductoCarrito_Click(object sender, EventArgs e)
        {
            
        }

        protected void btnQuitarProductoCarrito_Click(object sender, EventArgs e)
        {
            //ClientScript.RegisterStartupScript(GetType(), "obtenerCodigo", "obtenerCodigo();", true);

        }

        protected void grvCarrito_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            string accion = e.CommandName;
            if (accion.Equals("quitarCarrito"))
            {
                Carrito auxCarrito = (Carrito)Session["carrito"];
                auxCarrito.removerProducto(id);
                Session["carrito"] = auxCarrito.productos.Count < 1 ? null : auxCarrito;
            }
        }

        protected void grvCarrito_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnDescartar_Click(object sender, EventArgs e)
        {
            Session["carrito"] = null;
            Response.Redirect("productos.aspx?accion=carrito", true);
        }

        protected void btnContinuar_Click(object sender, EventArgs e)
        {
            Response.Redirect("cliente_carrito.aspx");
        }
    }
}
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
    public partial class editar_producto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            cargarCombos();
        }

        protected void btnAgregarProducto_Click(Object sender, EventArgs e)
        {

            try
            {
                Producto oProducto = new Producto
                {
                    nombre = txtNombreProducto.Text,
                    marca = new Marca { idMarca = Convert.ToInt32(cboMarcas.SelectedValue) },
                    precioVenta = float.Parse(txtPrecioVenta.Text),
                    precioCosto = float.Parse(txtPrecioCosto.Text),
                    descripcion = txtDescripcion.Text,
                    categoria = new Categoria { idCategoria = Convert.ToInt32(cboCategorias.SelectedValue) },
                    proveedor = new Proveedor { idProveedor = Convert.ToInt32(cboProveedores.SelectedValue) },
                    deposito = (cboCategorias.SelectedValue != "0") ? new Deposito
                    {
                        idDeposito = Convert.ToInt32(cboDepositos.SelectedValue)
                    } : null,
                    stockMinimo = Convert.ToInt32(txtStockMinimo.Text),
                    stockMaximo = Convert.ToInt32(txtStockMaximo.Text),
                    cantidadRestante = Convert.ToInt32(txtCantidad.Text)
                };

                AdProducto.agregarProducto(oProducto);
                
            }
            catch (Exception ex)
            {
                Response.Redirect("editar_producto.aspx?response=false");
                throw ex;
            }

        }

        private void cargarCombos()
        {
            List<Marca> lstMarcas = AdMarca.obtenerMarcas();
            List<Proveedor> lstProveedores = AdProveedor.obtenerProveedoresSimple();
            List<Categoria> lstCategorias = AdCategoria.obtenerCategorias();
            List<Deposito> lstDepositos = AdDeposito.obtenerDepositos();

            cboMarcas.DataSource = lstMarcas;
            for (int i = 0; i < lstMarcas.Count; i++)
            {
                ListItem li = new ListItem
                {
                    Text = lstMarcas[i].marca,
                    Value = lstMarcas[i].idMarca.ToString()
                };
                cboMarcas.Items.Add(li);
            }

            cboProveedores.DataSource = lstProveedores;
            for (int i = 0; i < lstProveedores.Count; i++)
            {
                ListItem li = new ListItem
                {
                    Text = lstProveedores[i].nombre,
                    Value = lstProveedores[i].idProveedor.ToString()
                };
                cboProveedores.Items.Add(li);
            }

            cboCategorias.DataSource = lstCategorias;
            for (int i = 0; i < lstCategorias.Count; i++)
            {
                ListItem li = new ListItem
                {
                    Text = lstCategorias[i].nombre,
                    Value = lstCategorias[i].idCategoria.ToString()
                };
                cboCategorias.Items.Add(li);
            }

            cboDepositos.DataSource = lstDepositos;
            for (int i = 0; i < lstDepositos.Count; i++)
            {
                ListItem li = new ListItem
                {
                    Text = lstDepositos[i].descripcion,
                    Value = lstDepositos[i].idDeposito.ToString()
                };
                cboDepositos.Items.Add(li);
            }

        }
    }
}
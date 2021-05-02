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
        protected int idProducto;
        protected string accion;
        protected void Page_Load(object sender, EventArgs e)
        {
            accion = (string.IsNullOrEmpty(Request.QueryString["accion"]) ? string.Empty : Request.QueryString["accion"].ToString());
            CargarCombos();
            if (Request.QueryString["id"] != null && Request.QueryString["accion"].Equals("editar"))
            {
                this.idProducto = Convert.ToInt32(Request.QueryString["id"]);
                Producto oProducto = AdProducto.obtenerProducto(idProducto);

                if (oProducto != null)
                {
                    txtNombreProducto.Text = oProducto.nombre;
                    txtCantidad.Text = oProducto.cantidadRestante.ToString();
                    cboMarcas.SelectedValue = oProducto.marca.idMarca.ToString();
                    txtPrecioVenta.Text = oProducto.precioVenta.ToString();
                    txtPrecioCosto.Text = oProducto.precioCosto.ToString();
                    cboCategorias.SelectedValue = oProducto.categoria.idCategoria.ToString();
                    cboProveedores.SelectedValue = oProducto.proveedor.idProveedor.ToString();
                    cboDepositos.SelectedValue = oProducto.deposito.idDeposito != null ? oProducto.deposito.idDeposito.ToString() : 0.ToString();
                    txtStockMinimo.Text = oProducto.stockMinimo.ToString();
                    txtStockMaximo.Text = oProducto.stockMaximo.ToString();
                    txtDescripcion.Text = string.IsNullOrEmpty(oProducto.descripcion) ? string.Empty : oProducto.descripcion;
                    btnAgregarProducto.Text = "Guardar cambios";
                }
                             

            }
            
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

                if (accion.Equals("editar"))
                {
                    AdProducto.actualizarProducto(oProducto);
                    //divProductoCargado.Style["display"] = "inherit";
                    Response.Redirect("home.aspx");               
                }
                else {
                    AdProducto.agregarProducto(oProducto);
                    divProductoCargado.Style["display"] = "inherit";
                    LimpiarCampos();
                }

            }
            catch (Exception ex)
            {
                Response.Redirect("editar_producto.aspx?response=false");
                divErrorCargaProducto.Style["display"] = "inherit";
                throw ex;
            }

        }

        private void CargarCombos()
        {
            List<Marca> lstMarcas = AdMarca.obtenerMarcas();
            List<Proveedor> lstProveedores = AdProveedor.obtenerProveedoresSimple();
            List<Categoria> lstCategorias = AdCategoria.obtenerCategorias();
            List<Deposito> lstDepositos = AdDeposito.obtenerDepositosCombo();

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

        public void LimpiarCampos()
        {
            txtNombreProducto.Text = string.Empty;
            txtCantidad.Text = string.Empty;
            cboMarcas.SelectedValue = "0";
            txtPrecioCosto.Text = string.Empty;
            txtPrecioVenta.Text = string.Empty;
            cboCategorias.SelectedValue = "0";
            cboProveedores.SelectedValue = "0";
            cboDepositos.SelectedValue = "0";
            txtStockMinimo.Text = string.Empty;
            txtStockMaximo.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
        }
    }
}
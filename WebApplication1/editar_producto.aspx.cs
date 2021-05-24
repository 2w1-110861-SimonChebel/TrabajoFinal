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
            if (!IsPostBack && Request.QueryString["response"] != "false")
            {
                accion = (string.IsNullOrEmpty(Request.QueryString["accion"]) ? string.Empty : Request.QueryString["accion"].ToString());
                CargarCombos();
                if (Request.QueryString["id"] != null && Request.QueryString["accion"].Equals("editar"))
                {
                    this.idProducto = Convert.ToInt32(Request.QueryString["id"]);
                    Producto oProducto = AdProducto.obtenerProductoPorId(idProducto);

                    if (oProducto != null)
                    {
                        txtCodigo.Text = oProducto.codigo;
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
                        dtpFechaElab.Text = oProducto.fechaElab.ToString();
                        dtpFechaVenc.Text = oProducto.fechaVenc.ToString();
                        txtDescripcion.Text = string.IsNullOrEmpty(oProducto.descripcion) ? string.Empty : oProducto.descripcion;
                        btnAgregarProducto.Text = "Guardar cambios";
                    }


                }
            }


        }

        protected void btnAgregarProducto_Click(Object sender, EventArgs e)
        {

            try
            {
                accion = (string.IsNullOrEmpty(Request.QueryString["accion"]) ? string.Empty : Request.QueryString["accion"].ToString());
                Producto oProducto = new Producto
                {
                    idProducto = Convert.ToInt32(Request.QueryString["id"]),
                    codigo = txtCodigo.Text.ToUpper(),
                    nombre = txtNombreProducto.Text,
                    marca = new Marca { idMarca = Convert.ToInt32(cboMarcas.SelectedValue) },
                    precioVenta = decimal.Parse(txtPrecioVenta.Text.Replace(".",",")),
                    precioCosto = decimal.Parse(txtPrecioCosto.Text.Replace(".",",")),
                    descripcion = txtDescripcion.Text,
                    categoria = new Categoria { idCategoria = Convert.ToInt32(cboCategorias.SelectedValue) },
                    proveedor = new Proveedor { idProveedor = Convert.ToInt32(cboProveedores.SelectedValue) },
                    deposito = (cboCategorias.SelectedValue != "0") ? new Deposito
                    {
                        idDeposito = Convert.ToInt32(cboDepositos.SelectedValue)
                    } : null,
                    stockMinimo = Convert.ToInt32(txtStockMinimo.Text),
                    stockMaximo = Convert.ToInt32(txtStockMaximo.Text),
                    cantidadRestante = Convert.ToInt32(txtCantidad.Text),
                    fechaVenc = Convert.ToDateTime(dtpFechaVenc.Text),
                    fechaElab = Convert.ToDateTime(dtpFechaElab.Text),
                    fechaIngreso = accion.Equals("editar") ? Convert.ToDateTime(dtpFechaIngreso.Text): DateTime.Now
                };
                if (validarCamposVacios())
                {
                    if (accion.Equals("editar"))
                    {
                        if (AdProducto.actualizarProducto(oProducto))
                        {
                            divMensaje.Visible= true;
                            divMensaje.Attributes["class"] = Bootstrap.alertSuccesDismissable;
                            hMensaje.InnerText = "Cambios guardados correctamente";
                            reestablecerColores();
                            LimpiarCampos();
                        }
                        else {
                            divMensaje.Visible= true;
                            divMensaje.Attributes["class"] = Bootstrap.alertDangerDismissable;
                            hMensaje.InnerText = "Hubo un error al actualizar el producto. Intente nuevamente.";
                        }
                        
                    }
                    else
                    {
                        if (AdProducto.agregarProducto(oProducto))
                        {
                            divMensaje.Visible = true;
                            divMensaje.Attributes["class"] = Bootstrap.alertSuccesDismissable;
                            hMensaje.InnerText = "Producto cargado correctamente";
                            reestablecerColores();
                            LimpiarCampos();
                        }
                        else {
                            divMensaje.Visible = true;
                            divMensaje.Attributes["class"] = Bootstrap.alertSuccesDismissable;
                            hMensaje.InnerText = "Producto cargado correctamente";
                        }
                       

                        
                    }
                }
                else {
                    divMensaje.Visible = true;
                    divMensaje.Attributes["class"] = Bootstrap.alertDangerDismissable;
                    hMensaje.InnerText = "Complete todos los campos";
                    return;
                }
               

            }
            catch (Exception ex)
            {
                divErrorCargaProducto.Style["display"] = "inherit";
                divMensaje.Attributes["class"] = Bootstrap.alertDangerDismissable;
                hMensaje.InnerText = "Hubo un error al guardar los cambios. Verifique los campos";
                return;
                //Response.Redirect("editar_producto.aspx?response=false");
                throw ex;
            }

        }

        private bool validarCamposVacios()
        {
            WebControl[] aCampos = new WebControl[] {
                txtCodigo,
                txtCantidad,
                txtNombreProducto,
                txtPrecioCosto,
                txtPrecioVenta,
                txtStockMaximo,
                txtStockMinimo,
                cboCategorias,
                cboMarcas,
                cboProveedores
            };

            return Validar.ValidarCamposVacios(aCampos);
        }

        private void reestablecerColores()
        {
            WebControl[] aCampos = new WebControl[] {
                txtCodigo,
                txtCantidad,
                txtNombreProducto,
                txtPrecioCosto,
                txtPrecioVenta,
                txtStockMaximo,
                txtStockMinimo,
                cboCategorias,
                cboMarcas,
                cboProveedores

            };

            Validar.ReestablecerColores(aCampos);
        }

        private void CargarCombos()
        {
            List<Marca> lstMarcas = AdMarca.obtenerMarcas();
            List<Proveedor> lstProveedores = AdProveedor.obtenerProveedoresSimple();
            List<Categoria> lstCategorias = AdCategoria.obtenerCategorias();
            List<Deposito> lstDepositos = AdDeposito.obtenerDepositosCombo();

            cboMarcas.DataSource = null;
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

            cboProveedores.DataSource = null;
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

            cboCategorias.DataSource = null;
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

            cboDepositos.DataSource = null;
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
            txtCodigo.Text = string.Empty;
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
            dtpFechaElab.Text = string.Empty;
            dtpFechaVenc.Text = string.Empty;
        }
    }
}
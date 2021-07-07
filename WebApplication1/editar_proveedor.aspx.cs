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
    public partial class editar_proveedor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int idProveedor = Request.QueryString["id"] != null ? Convert.ToInt32(Request.QueryString["id"]) : 0;
            string accion = Request.QueryString["accion"] != null ? Request.QueryString["accion"] : string.Empty;
            if (!IsPostBack && accion.Equals("editar"))
            {
                cargarCombos();
                Proveedor oProveedor = AdProveedor.ObtenerProveedores("", idProveedor).FirstOrDefault();
                if (oProveedor != null)
                {
                    btnAgregarProveedor.Text = "Guardar cambios";
                    divTitulo.InnerText = "Editar proveedor";
                    txtNombre.Text = oProveedor.nombre;
                    txtEmail.Text = oProveedor.email;
                    txtTelefono.Text = oProveedor.telefono;
                    TxtDireccion.Text = oProveedor.direccion;
                    cboLocalidades.SelectedValue = oProveedor.localidad.idLocalidad.ToString();
                    cboProvincias.SelectedValue = oProveedor.provincia.idProvincia.ToString();
                    TxtCodigoPostal.Text = oProveedor.codigoPostal;
                    txtBarrio.Text = oProveedor.barrio;

                }
            }
        }

        private void cargarCombos()
        {
            List<Localidad> lstLocalidades = AdGeneral.obtenerLocalidades();
            List<Provincia> lstProvincias = AdGeneral.obtenerProvincias();

            cboLocalidades.DataSource = null;
            cboLocalidades.DataBind();
            for (int i = 0; i < lstLocalidades.Count; i++)
            {
                ListItem li = new ListItem
                {
                    Text = lstLocalidades[i].localidad,
                    Value = lstLocalidades[i].idLocalidad.ToString()
                };
                cboLocalidades.Items.Add(li);
            }
            //Provincias
            cboProvincias.DataSource = null;
            cboProvincias.DataBind();
            for (int i = 0; i < lstProvincias.Count; i++)
            {
                ListItem li = new ListItem
                {
                    Text = lstProvincias[i].provincia,
                    Value = lstProvincias[i].idProvincia.ToString()
                };
                cboProvincias.Items.Add(li);
            }
        }

        protected void btnAgregarProveedor_Click(object sender, EventArgs e)
        {
            if (validarCampos())
            {
                int idProveedor = Request.QueryString["id"] != null ? Convert.ToInt32(Request.QueryString["id"]) : 0;
                Proveedor oProveedor = new Proveedor
                {
                    idProveedor = idProveedor,
                    nombre = txtNombre.Text,
                    email = txtEmail.Text,
                    telefono = txtTelefono.Text,
                    direccion = TxtDireccion.Text,
                    localidad = new Localidad
                    {
                        idLocalidad = Convert.ToInt32(cboLocalidades.SelectedValue)
                    },
                    provincia = new Provincia
                    {
                        idProvincia = Convert.ToInt32(cboProvincias.SelectedValue)
                    },
                    codigoPostal = TxtCodigoPostal.Text,
                    barrio = txtBarrio.Text

                };
                if (AdProveedor.actualizarProveedor(oProveedor))
                {
                    Response.Redirect("proveedores.aspx?edit=true");
                }
                else
                {
                    divMensaje.Visible = true;
                    divMensaje.Attributes["class"] = Bootstrap.alertDangerDismissable;
                    hMensaje.InnerText = "Hubo un error al actualizar el proveedor. Intente nuevamente";
                    return;
                }
            }
        }

        private bool validarCampos()
        {
            WebControl[] aCampos = new WebControl[] {
                txtNombre,
                txtTelefono,
                txtEmail,
                txtBarrio,
                TxtCodigoPostal,
                TxtDireccion,
                cboLocalidades,
                cboProvincias
            };
            return Validar.ValidarCamposVacios(aCampos);
        }

        private void reestablecerColoresCampos()
        {

            WebControl[] aCampos = new WebControl[] {
            txtNombre,
            txtBarrio,
            txtEmail,
            txtTelefono,
            TxtCodigoPostal,
            TxtDireccion,
            cboLocalidades,
            cboProvincias
        };
            Validar.ReestablecerColores(aCampos);
        }

        private void limpiarCampos()
        {
            txtNombre.Text = string.Empty;
            txtBarrio.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            TxtCodigoPostal.Text = string.Empty;
            TxtDireccion.Text = string.Empty;
            cboLocalidades.SelectedValue = "0";
            cboProvincias.SelectedValue = "0";
        }
    }
}
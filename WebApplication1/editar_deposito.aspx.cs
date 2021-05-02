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
    public partial class editar_deposito : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarCombos();
            }
        }
        protected void btnAgregarDeposito_Click(object sender, EventArgs e)
        {
            Sucursal oSucursal = new Sucursal
            {
                nombre = txtNombreSucursal.Text,
                direccion = txtDireccionDeposito.Text,
                deposito = new Deposito {
                    descripcion = txtDescripcion.Text,
                    completo = (cboCompleto.SelectedValue == "0") ? false : (cboCompleto.SelectedValue == "1") ? true : false
                },
                localidad = new Localidad {
                    idLocalidad = Convert.ToInt32(cboLocalidades.SelectedValue),
                    localidad = cboLocalidades.SelectedItem.Text
                },
                provincia = new Provincia {
                    idProvincia = Convert.ToInt32(cboProvincias.SelectedValue),
                    provincia = cboProvincias.SelectedItem.Text
                }


            };
            AdDeposito.agregarDeposito(oSucursal);
        }

        private void CargarCombos()
        {
            List<Localidad> lstLocalidad = AdGeneral.obtenerLocalidades();
            List<Provincia> lstProvincias = AdGeneral.obtenerProvincias();

            cboLocalidades.DataSource = lstLocalidad;
            for (int i = 0; i < lstLocalidad.Count; i++)
            {
                ListItem li = new ListItem
                {
                    Text = lstLocalidad[i].localidad,
                    Value = lstLocalidad[i].idLocalidad.ToString()
                };
                cboLocalidades.Items.Add(li);
            }

            cboProvincias.DataSource = lstProvincias;
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

        private void limpiarCampos()
        {
            txtDescripcion.Text = string.Empty;
            txtDireccionDeposito.Text = string.Empty;
            txtNombreSucursal.Text = string.Empty;
            cboCompleto.SelectedValue = "-1";
            cboLocalidades.SelectedValue = "0";
            cboProvincias.SelectedValue = "0";
        }
    }
}
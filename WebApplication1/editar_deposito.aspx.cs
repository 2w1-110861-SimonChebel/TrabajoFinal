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
        protected int idSucursal;
        protected string accion;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.accion = string.IsNullOrEmpty(Request.QueryString["accion"]) ? string.Empty : Request.QueryString["accion"].ToString();
                divMensaje.Visible = false;
                CargarCombos();
                if (Request.QueryString["id"] != null && Request.QueryString["accion"].Equals("editar")) {
                    this.idSucursal = Convert.ToInt32(Request.QueryString["id"]);
                    Sucursal oSucursal = AdDeposito.obtenerDepositoPorId(idSucursal);

                    if (oSucursal != null)
                    {
                        hfIdDeposito.Value = oSucursal.deposito.idDeposito.ToString();
                        txtDescripcion.Text = oSucursal.deposito.descripcion;
                        txtDireccionDeposito.Text = oSucursal.direccion;
                        txtNombreSucursal.Text = oSucursal.nombre;
                        cboCompleto.SelectedValue = oSucursal.deposito.completo ? "1" : "0";
                        cboLocalidades.SelectedValue = oSucursal.localidad.idLocalidad.ToString();
                        cboProvincias.SelectedValue = oSucursal.provincia.idProvincia.ToString();
                        btnAgregarDeposito.Text = "Guardar cambios";
                    }
                }
                //if (Request.QueryString["id"] != null && Request.QueryString["accion"].Equals("eliminar"))
                //{
                //    this.idSucursal = Convert.ToInt32(Request.QueryString["id"]);
                //    AdDeposito.eliminarDeposito(this.idSucursal);
                //}
            }
        }
        protected void btnAgregarDeposito_Click(object sender, EventArgs e)
        {
            Sucursal oSucursal;
            this.accion = string.IsNullOrEmpty(Request.QueryString["accion"]) ? string.Empty : Request.QueryString["accion"].ToString();
            int idSucu = accion.Equals("editar") ? Convert.ToInt32(Request.QueryString["id"]) : 0;

            oSucursal = new Sucursal
            {
                idSucursal = idSucu,
                nombre = txtNombreSucursal.Text,
                direccion = txtDireccionDeposito.Text,
                deposito = new Deposito
                {
                    idDeposito = (accion.Equals("editar"))? Convert.ToInt32(hfIdDeposito.Value):0,
                    descripcion = txtDescripcion.Text,
                    completo = cboCompleto.SelectedValue == "-1" ? false : cboCompleto.SelectedValue == "0" ?false:true
                },
                provincia = new Provincia {
                    idProvincia = Convert.ToInt32(cboProvincias.SelectedValue)
                },
                localidad = new Localidad { 
                    idLocalidad = Convert.ToInt32(cboLocalidades.SelectedValue)
                }
                
                };
            if (accion.Equals("editar"))
            {
              
                if (AdDeposito.editarDeposito(oSucursal))
                {
                    limpiarCampos();
                    divMensaje.Visible = true;
                    divMensaje.Style["class"] = "alert alert-success";
                    hMensaje.InnerText = "Deposito actualizado correctamente";
                    System.Threading.Thread.Sleep(2000);
                    Response.Redirect("depositos.aspx");
                }
                else {
                    divMensaje.Visible = true;
                    divMensaje.Style["class"] = "alert alert-danger";
                    hMensaje.InnerText = "Hubo un error al cargar el deposito";
                }
                
            }
            else
            {
                if (AdDeposito.agregarDeposito(oSucursal))
                {
                    divMensaje.Visible = true;
                    divMensaje.Style["class"] = "alert alert-success";
                    hMensaje.InnerText = "Deposito cargado correctamente";
                    limpiarCampos();
                }
                else
                {
                    divMensaje.Visible = true;
                    divMensaje.Style["class"] = "alert alert-danger";
                    hMensaje.InnerText = "Hubo un error al cargar el deposito";
                }
            }
            
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
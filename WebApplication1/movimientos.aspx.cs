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
    public partial class movimientos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hTitulo.InnerText = string.Format("{0}{1} {2}","Movimientos (",AdTransaccion.CantidadTotalTransaccion()," en total)");
                divMensaje.Visible = false;
               
                CargarCombos();
  
            }
        }

        protected void btnVerDetalle_Click(object sender, EventArgs e)
        {

        }

        protected void grvTransacciones_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string[] arguments = e.CommandArgument.ToString().Split(',');
            int idTran = Convert.ToInt32(arguments[0]);
            int idTipoTran = Convert.ToInt32(arguments[1]);
            Response.Redirect("detalle_movimientos.aspx?id=" + idTran + "&idTipo=" + idTipoTran);

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            divMensajeResult.Visible = false;
            divMensaje.Visible = false;
            grvTransacciones.DataSource = null;
            grvTransacciones.DataBind();
            WebControl[] aControles = new WebControl[] {
                txtCliente,
                txtNroTran,
                cboUsuario,
                dtpFechaInicio,
                dtpFechaFin,
                cboProveedor,
                cboTipoTransaccion
            };

            //filtros
            int idTransaccion = string.IsNullOrEmpty(txtNroTran.Text) ? 0 : Convert.ToInt32(txtNroTran.Text);
            Cliente cli = !string.IsNullOrEmpty(txtCliente.Text) ? new Cliente { nombre = txtCliente.Text, apellido = txtCliente.Text, razonSocial = txtCliente.Text }:null;
            Usuario usu = Convert.ToInt32(cboUsuario.SelectedValue) > 0? new Usuario { idUsuario = Convert.ToInt32(cboUsuario.SelectedValue) } : null;
            Proveedor pro = Convert.ToInt32(cboProveedor.SelectedValue) > 0 ? new Proveedor { idProveedor = Convert.ToInt32(cboProveedor.SelectedValue) } : null;
            string fechaInicio = !string.IsNullOrEmpty(dtpFechaInicio.Text) ? dtpFechaInicio.Text : string.Empty;
            string fechaFin = !string.IsNullOrEmpty(dtpFechaFin.Text) ? dtpFechaFin.Text : string.Empty;

            if (Validar.HayUnCampoSeleccionado(aControles))
            {
                int tipoTran = Convert.ToInt32(cboTipoTransaccion.SelectedValue);
                if (Convert.ToInt32(cboTipoTransaccion.SelectedValue) > 0)
                {
                    switch (tipoTran)
                    {
                        case (int)Tipo.tipoTransaccion.ventaCliente:
                            List<VentaCliente> lstVentas = AdTransaccion.ObtenerVentasCliente(idTransaccion,cli,usu,fechaInicio,fechaFin,tipoTran, true,false, true);
                            grvTransacciones.DataSource = lstVentas;
                            grvTransacciones.DataBind();
                            if (lstVentas == null) MostrarMensajeNoEcontrados();
                            break;
                        case (int)Tipo.tipoTransaccion.cambioProductoDeCliente:
                            List<Transaccion> lstMov = AdTransaccion.obtenerMovimientos(idTransaccion,cli,usu,fechaInicio,fechaFin, pro, tipoTran, true);
                            grvTransacciones.DataSource = lstMov;
                            grvTransacciones.DataBind();
                            if (lstMov == null) MostrarMensajeNoEcontrados();
                            break;
                        case (int)Tipo.tipoTransaccion.devolucionDeCliente:
                            List<Transaccion> lstDev = AdTransaccion.obtenerMovimientos(idTransaccion, cli, usu, fechaInicio, fechaFin, pro, tipoTran, true);
                            grvTransacciones.DataSource = lstDev;
                            grvTransacciones.DataBind();
                            if (lstDev == null) MostrarMensajeNoEcontrados();
                            break;
                        default:
                            //List<Transaccion> lstTran = AdTransaccion.
                            break;

                    }
                }
                else 
                {
                    List<Transaccion> lstMov = AdTransaccion.obtenerMovimientos(idTransaccion, cli, usu, fechaInicio, fechaFin, pro, tipoTran, true);
                    grvTransacciones.DataSource = lstMov;
                    grvTransacciones.DataBind();
                    if (lstMov == null) MostrarMensajeNoEcontrados();
                    //grvTransacciones.DataSource = lstMov;
                    //grvTransacciones.DataBind();
                    //if (lstMov == null) MostrarMensajeNoEcontrados();
           
                }
                //List<>
                //if (lstVentas != null)
                //{
                //    grvVentas.DataSource = lstVentas;
                //    grvVentas.DataBind();
                //}
                //else
                //{
                //    divMensajeResult.Visible = true;
                //    divMensajeResult.Attributes["class"] = Bootstrap.alertWarningDismissable;
                //    hResult.InnerText = "No se encontraron resultados.";
                //}
            }
            else
            {
                divMensaje.Visible = true;
                divMensaje.Attributes["class"] = Bootstrap.alertDangerDismissable;
                hMensaje.InnerText = "Debe completar al menos un (1) filtro";
            }
            return;
        }

        private void CargarCombos()
        {
            cboUsuario.DataSource = null;
            cboProveedor.DataSource = null;
            List<Usuario> lstUsuario = Session["listaUsuario"] != null ? (List<Usuario>)Session["listaUsuario"] : AdUsuario.ObtenerUsuarios();
            List<Proveedor> lstProveedor = Session["listaProveedores"] != null ? (List<Proveedor>)Session["listaProveedores"] : AdProveedor.obtenerProveedores();
            List<TipoTransaccion> lstTipoTransaccion = Session["listaTipoTransaccion"] != null ? (List<TipoTransaccion>)Session["listaTipoTransaccion"] : AdGeneral.obtenerTiposTransacciones();
            if (Session["listaUsuario"] == null) Session["listaUsuario"] = lstUsuario;
            if(Session["listaProveedores"] == null) Session["listaProveedores"] = lstProveedor;
            if (Session["listaTipoTransaccion"] == null) Session["listaTipoTransaccion"] = lstTipoTransaccion;

            for (int i = 0; i < lstUsuario.Count; i++)
            {
                ListItem li = new ListItem
                {
                    Text = string.Format("{0} {1}", lstUsuario[i].nombre, lstUsuario[i].apellido),
                    Value = lstUsuario[i].idUsuario.ToString()
                };
                cboUsuario.Items.Add(li);
            }

            for (int i = 0; i < lstProveedor.Count; i++)
            {
                ListItem li = new ListItem
                {
                    Text = lstProveedor[i].nombre,
                    Value = lstProveedor[i].idProveedor.ToString()
                };
                cboProveedor.Items.Add(li);
            }

            for (int i = 0; i < lstTipoTransaccion.Count; i++)
            {
                ListItem li = new ListItem
                {
                    Text = lstTipoTransaccion[i].tipoTransaccion,
                    Value = lstTipoTransaccion[i].idTipoTransaccion.ToString()
                };
                cboTipoTransaccion.Items.Add(li);
            }
        }

        private void MostrarMensajeNoEcontrados()
        {
            divMensaje.Visible = true;
            divMensaje.Attributes["class"] = Bootstrap.alertWarningDismissable;
            hMensaje.InnerText = "No se encontraron resultados.";
        }

        protected void cboTipoTransaccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            int tipoTran = Convert.ToInt32(((DropDownList)sender).SelectedValue);
            switch (tipoTran)
            {
                case (int)Tipo.tipoTransaccion.ventaCliente:
                    cboProveedor.SelectedValue = "0";
                    //cboProveedor.Enabled = false;
                    cboProveedor.Attributes["disabled"] = "true";
                    break;
                case (int)Tipo.tipoTransaccion.cambioProductoDeCliente:
                    cboProveedor.SelectedValue = "0";
                    //cboProveedor.Enabled = false;
                    cboProveedor.Attributes["disabled"] = "true";
                    break;
                case (int)Tipo.tipoTransaccion.devolucionDeCliente:
                    cboProveedor.SelectedValue = "0";
                    //cboProveedor.Enabled = false;
                    cboProveedor.Attributes["disabled"] = "true";
                    break;

                default:
                    //cboProveedor.Enabled = true;
                    cboProveedor.Attributes.Remove("disabled");
                    break;
            }
        }

    }
}
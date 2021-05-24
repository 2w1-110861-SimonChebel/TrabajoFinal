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
    public partial class devolucion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarCombos();
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            divMensaje.Visible = false;
            divMensajeResult.Visible = false;
            WebControl[] aControles = new WebControl[] {
                txtCliente,
                txtNroVenta,
                cboUsuario,
                dtpFecha
            };

            if (Validar.HayUnCampoSeleccionado(aControles))
            {
                Cliente cli = null;
                Usuario usu = null;

                if (!string.IsNullOrEmpty(txtCliente.Text)) cli = new Cliente { nombre = txtCliente.Text, apellido = txtCliente.Text, razonSocial = txtCliente.Text };
                if(Convert.ToInt32(cboUsuario.SelectedValue)>0) usu = new Usuario { idUsuario = Convert.ToInt32(cboUsuario.SelectedValue) };
                List<VentaCliente> lstVentas = AdTransaccion.obtenerVentasCliente( txtNroVenta.Text != ""? Convert.ToInt32(txtNroVenta.Text):0, cli, usu, dtpFecha.Text);
                if (lstVentas != null)
                {
                    grvVentas.DataSource = lstVentas;
                    grvVentas.DataBind();
                }
                else 
                {
                    divMensajeResult.Visible = true;
                    divMensajeResult.Attributes["class"] = Bootstrap.alertWarningDismissable;
                    hResult.InnerText = "No se encontraron resultados.";
                }
            }
            else {
                divMensaje.Visible = true;
                divMensaje.Attributes["class"] = Bootstrap.alertDangerDismissable;
                hMensaje.InnerText = "Debe completar al menos un (1) filtro";
            }
        }

        protected void grvVentas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void grvVentas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string[] arg = e.CommandArgument.ToString().Split(',');
            int idTransaccion = Convert.ToInt32(arg[0]);
            int idCliente = Convert.ToInt32(arg[1]);
            Response.Redirect("devolucion.aspx?idTran=" + idTransaccion + "&idCli=" + idCliente);
        }

        private void cargarCombos()
        {
            List<Usuario> lstUsuarios = AdUsuario.ObtenerUsuarios();
            cboUsuario.DataSource = null;
            cboUsuario.DataBind();
            for (int i = 0; i < lstUsuarios.Count; i++)
            {
                ListItem li = new ListItem
                {
                    Text =string.Format("{0} {1}", lstUsuarios[i].nombre,lstUsuarios[i].apellido),
                    Value = lstUsuarios[i].idUsuario.ToString()
                };
                cboUsuario.Items.Add(li);
            }
        }

        protected void btnElegirVenta_Click(object sender, EventArgs e)
        {

        }

        protected void grvDetalleVenta_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void grvDetalleVenta_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }
    }
}
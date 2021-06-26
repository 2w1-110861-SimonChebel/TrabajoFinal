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
    public partial class depositos : System.Web.UI.Page
    {
        protected Sucursal oSucursal;
        protected List<Sucursal> lstDepositos;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Usuario oUsuario = (Usuario)Session["usuario"];
                if (oUsuario.tipoUsuario.idTipoUsuario != 1) grvDepositos.Columns[8].Visible = false;
                if (Request.QueryString["edit"] != null)
                {
                    divMensaje.Visible = true;
                    divMensaje.Attributes["class"] = Bootstrap.alertSuccesDismissable;
                    hMensaje.InnerText = "Los cambios se guardaron correctamente";
                }
                else divMensaje.Visible = false;
                oSucursal = new Sucursal();
                lstDepositos = AdDeposito.obtenerDepositos();
                grvDepositos.DataSource = lstDepositos;
                grvDepositos.DataBind();
            }

        }
        protected void grvDepositos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int idSucursal = Convert.ToInt32(e.CommandArgument);
            oSucursal = AdDeposito.obtenerDepositoPorId(idSucursal);

            if (e.CommandName.Equals("editar"))
            {
                Response.Redirect("editar_deposito.aspx?id=" + idSucursal.ToString() + "&accion=" + e.CommandName);
            }
            else if (e.CommandName.Equals("eliminar"))
            {
                if (AdDeposito.eliminarDeposito(oSucursal.deposito.idDeposito, oSucursal.idSucursal))
                {                                    
                    divMensaje.Visible = true;
                    divMensaje.InnerText = "Deposito eliminador correctamente";
                    divMensaje.Style["class"] = "alert alert-success";
                    Response.Redirect("depositos.aspx");
                }
                else
                {
                    divMensaje.Visible = true;
                    divMensaje.InnerText = "Hubo un error al eliminar el deposito";
                    divMensaje.Style["class"] = "alert alert-danger";
                    Response.Redirect("depositos.aspx");

                }

            }
        }

        protected void btnBuscarDeposito_Click(object sender, EventArgs e)
        {
            grvDepositos.DataSource = null;
            grvDepositos.DataBind();
            List<Sucursal> lstDepositos = AdDeposito.obtenerDepositos(txtBuscarDeposito.Text);
            if (lstDepositos != null && lstDepositos.Count > 0)
            {
                grvDepositos.DataSource = lstDepositos;
                grvDepositos.DataBind();
                divMensaje.Visible = false;
            }
            else {
                divMensaje.Visible = true;
                divMensaje.Style["class"] = "alert alert-warning";
                hMensaje.InnerText = "No se encontraron resultados";
            }
        }

    }
}
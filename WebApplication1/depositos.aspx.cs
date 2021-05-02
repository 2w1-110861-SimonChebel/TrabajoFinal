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
                if (AdDeposito.eliminarDeposito(idSucursal))
                {                  
                    Response.Redirect("depositos.aspx");
                    divMensaje.Visible = true;
                    divMensaje.InnerText = "Deposito eliminador correctamente";
                    divMensaje.Style["class"] = "alert alert-success";              
                }
                else
                {
                    Response.Redirect("depositos.aspx");
                    divMensaje.Visible = true;
                    divMensaje.InnerText = "Hubo un error al eliminar el deposito";
                    divMensaje.Style["class"] = "alert alert-danger";
                    
                }

            }
        }
        protected void btnEditarDeposito_Click(object sender, EventArgs e)
        {
            
        }
        protected void btnEliminarDeposito_Click(object sender, EventArgs e)
        {

        }
    }
}
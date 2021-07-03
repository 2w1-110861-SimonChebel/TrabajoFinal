using Easy_Stock.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InventarioP = Easy_Stock.Entidades.Inventario;

namespace Easy_Stock
{
    public partial class inventario : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (grvInventario.DataSource == null)
            {
                divMensaje.Visible = true;
            }

            if (!IsPostBack)
            {
                List<InventarioP> lst = AdInventario.ObtenerInventario();
                if (lst != null)
                {
                    CargarCombo();
                    grvInventario.DataSource = lst;
                    grvInventario.DataBind();
                    Session["inventario"] = lst;
                    divMensaje.Visible = false;
                }
                else {
                    divMensaje.Visible = true;
                }

            }
            else 
            {
                grvInventario.DataSource = Session["inventario"] != null ? (List<InventarioP>)Session["inventario"] : AdInventario.ObtenerInventario();
                grvInventario.DataBind();
                if (grvInventario.DataSource == null) divMensaje.Visible = true;
                else { divMensaje.Visible = false; }

            }
        }

        private void CargarCombo()
        {
            List<Easy_Stock.Entidades.EstadoProducto> lst = AdGeneral.ObtenerEstadosProductos();

            for (int i = 0; i < lst.Count; i++)
            {
                ListItem li = new ListItem
                {
                    Text = lst[i].estadoProducto,
                    Value = lst[i].idEstadoProducto.ToString()
                };
                cboEstado.Items.Add(li);
            }
        }

        protected void grvInventario_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {

        }

        protected void grvInventario_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
        {
            ((GridView)sender).PageIndex = e.NewPageIndex;
            grvInventario.DataSource = Session["inventario"] != null ? (List<InventarioP>)Session["inventario"] : AdInventario.ObtenerInventario();
            grvInventario.DataBind();
        }
    }
}
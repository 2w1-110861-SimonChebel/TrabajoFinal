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
        protected bool esBusqueda;
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

        protected void btnBuscar_Click(object sender, EventArgs e)
        {

            List<InventarioP> resultado = null;

            esBusqueda = true;

            divMensaje.Visible = false;

            string[] aux = txtCodigoUnico.Text.Split('-');
            string codigoUnico = aux.Length > 1 ? string.Format("{0}-{1}", aux[0], aux[1]) : string.Empty;
            string codigo = txtCodigo.Text;
            string nombre = txtNombre.Text;
            int idEstado = Convert.ToInt32( cboEstado.SelectedValue);
            DateTime fechaInicio = string.IsNullOrEmpty(dtpFechaInicio.Text) ? default: Convert.ToDateTime( dtpFechaInicio.Text);
            DateTime fechaFin = string.IsNullOrEmpty(dtpFechaFin.Text) ? default : Convert.ToDateTime(dtpFechaFin.Text).AddHours(23).AddMinutes(59).AddSeconds(59);

            resultado = AdInventario.ObtenerInventario(codigoUnico, codigo, idEstado, fechaInicio, fechaFin,nombre);

            if (resultado != null)
            {
                Session["inventario"] = resultado;
                grvInventario.DataSource = resultado;
                grvInventario.DataBind();
            }
            else 
            {
                Session["inventario"] = null;
                grvInventario.DataSource = null;
                grvInventario.DataBind();
                divMensaje.Visible = true;
            }


        }
    }
}
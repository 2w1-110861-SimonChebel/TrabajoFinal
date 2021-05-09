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
    public partial class clientes : System.Web.UI.Page
    {
        public Cliente oCliente ;
        public List<Cliente> lstClientes;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                divMensaje.Visible = false;
                lstClientes = AdCliente.obtenerClientes();
                grvClientes.DataSource = lstClientes;
                grvClientes.DataBind();
            }
        
        }

        protected void BtnBuscarCliente_Click(object sender, EventArgs e)
        {
            string nombre = txtBuscarCliente.Text;
            divMensaje.Visible = false;
            if (string.IsNullOrEmpty(nombre))
            {
                return;
            }
            else
            {
                List<Cliente> lstClientes = AdCliente.obtenerClientes(nombre);
                if (lstClientes == null)
                {
                    grvClientes.DataSource = lstClientes;
                    grvClientes.DataBind();
                    divMensaje.Visible = true;
                    divMensaje.Attributes["class"] = Bootstrap.alertWarningDismissable;
                    hMensaje.InnerText = "No se encontraron resultados";
                }
                else 
                {
                    grvClientes.DataSource = lstClientes;
                    grvClientes.DataBind();
                    divMensaje.Visible = true;
                    divMensaje.Attributes["class"] = Bootstrap.alertInfoDismissable;
                    hMensaje.InnerText = string.Format("{0} {1}","Clientes con el nombre ",nombre);
                }


            }
        }
        protected void BtnEliminarCliente_Click(object sender, EventArgs e)
        {
            
        }

        protected void BtnEditarCliente_Click(object sender, EventArgs e)
        {
            
        }
        protected void grvClientes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int idCliente = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName.Equals("editar"))
            {
                Response.Redirect("editar_cliente.aspx?id=" + idCliente.ToString() + "&accion=" + e.CommandName);
            }
        }
        protected string devolverFechaSinHorario(DateTime fecha)
        {
            return fecha.ToShortDateString();
        }

    }
}
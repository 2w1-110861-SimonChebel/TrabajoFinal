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
                string response = Request.QueryString["eliminado"] != null ? Request.QueryString["eliminado"] : string.Empty;
                if (!string.IsNullOrEmpty(response))
                {
                    divMensaje.Visible = true;
                    divMensaje.Attributes["class"] = Bootstrap.alertSuccesDismissable;
                    hMensaje.InnerText = "El cliente se borró correctamente";
                }
                else divMensaje.Visible = false;
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
            string command = e.CommandArgument.ToString();
            string[] param = command.Split(',');
            int idCliente = Convert.ToInt32(param[0]);
            int tipoCliente = 0;
            if(param.Length > 1 )Convert.ToInt32(param[1]);
            if (e.CommandName.Equals("editar"))
            {
                Response.Redirect("editar_clientes.aspx?id=" + idCliente.ToString() + "&accion=" + e.CommandName+"&tipoCliente="+tipoCliente);
            }
            if (e.CommandName.Equals("eliminar"))
            {
                if (AdCliente.eliminarClientePorId(idCliente))
                {
                    Response.Redirect("clientes.aspx?eliminado=true", true);
                }
                else {
                    divMensaje.Visible = true;
                    divMensaje.Attributes["class"] = Bootstrap.alertDangerDismissable;
                    hMensaje.InnerText = "Hubo un problema al eliminar el cliente. Intente nuevamente";
                    return;
                }
            }
        }
        protected string devolverFechaSinHorario(DateTime fecha)
        {
            return fecha.ToShortDateString();
        }

    }
}
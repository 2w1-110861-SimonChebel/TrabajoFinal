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
                lstClientes = AdCliente.obtenerClientes();
                grvClientes.DataSource = lstClientes;
                grvClientes.DataBind();
            }
        
        }

        protected void BtnCliente_Click(object sender, EventArgs e)
        {
            
        }

        protected void BtnEditarCliente_Click(object sender, EventArgs e)
        {
            
        }
        protected void grvClientes_RowCommand(object sender, EventArgs e)
        {

        }

    }
}
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
    public partial class editar_cat : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string id = Request.QueryString["i"] != null ? Request.QueryString["i"] : string.Empty;
                if (!string.IsNullOrEmpty(id))
                { 
                   hTitulo.InnerText = "Editar categoria"; 
                   btnAgregarCategoria.Text = "Guardar cambios";
                }
                else { hTitulo.InnerText = "Nueva categoria"; btnAgregarCategoria.Text = "Agregar"; }

                if (!string.IsNullOrEmpty(id))
                {
                    Categoria oCategoria = AdCategoria.ObtenerCategorias("",Convert.ToInt32(id)).First();

                    if (oCategoria != null)
                    {
                        txtNombre.Text = oCategoria.nombre;
                        txtDesc.Text = oCategoria.descripcion;
                    }
                    else
                    {
                        divMensaje.Visible = true;
                        divMensaje.Attributes["class"] = Bootstrap.alertDangerDismissable;
                        hMensaje.InnerText = "Hubo un problema. Intentar nuevamente";
                        return;
                    }
                }
            }
        }

        protected void btnAgregarCliente_Click(object sender, EventArgs e)
        {
            int id = Request.QueryString["i"] != null ? Convert.ToInt32(Request.QueryString["i"]) : 0;
            string nombre = txtNombre.Text;
            string descripcion = txtDesc.Text;

            //si es mayor es edicion
            if (id > 0)
            {
                if (Validar.ValidarCamposVacios(new WebControl[] { txtNombre }))
                {
                    if (AdCategoria.ActualizarCategoria(id, nombre, descripcion))
                    {
                        Response.Redirect("categorias.aspx?edit=true");
                    }
                    else
                    {
                        divMensaje.Attributes["class"] = Bootstrap.alertDangerDismissable;
                        divMensaje.Visible = true;
                        hTitulo.InnerText = "Hubo un error al actualizar los datos. Intente nuevamente";
                    }
                }
                else
                {
                    divMensaje.Visible = true;
                    divMensaje.Attributes["class"] = Bootstrap.alertWarningDismissable;
                    hMensaje.InnerText = "El nombre es obligatorio";
                }

            }
            else
            {
                if (Validar.ValidarCamposVacios(new WebControl[] { txtNombre }))
                {
                    Categoria cat = new Categoria
                    {
                        nombre = txtNombre.Text,
                        descripcion = txtDesc.Text,
                        estado = true
                    };
                    if (AdCategoria.AgregarCategoria(cat))
                    {
                        Response.Redirect("categorias.aspx?edit=true");
                    }
                    else 
                    {
                        divMensaje.Visible = true;
                        divMensaje.Attributes["class"] = Bootstrap.alertDangerDismissable;
                        hMensaje.InnerText = "Hubo un error. Intente nuevamente";
                    }
                }
            }
        }
    }
}
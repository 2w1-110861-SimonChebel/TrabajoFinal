using Easy_Stock.AccesoDatos;
using Easy_Stock.Entidades;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Easy_Stock
{
    public partial class Estadisticas : System.Web.UI.MasterPage
    {
        protected Usuario oUsuario;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                if (Session["usuario"] == null)
                    Response.Redirect("principal.aspx");
                oUsuario = (Usuario)Session["usuario"];
                lblUsuario.Text = string.Format("{0} {1}", oUsuario.nombre, oUsuario.apellido);
                if (Session["empresa"] == null) Session["empresa"] = AdGeneral.obtenerDatosEmpresa();
            }
        }


        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            try
            {
                Session["usuario"] = null;
                Session["carrito"] = null;
                Session["clienteCarrito"] = null;
                Session["empresa"] = null;
                Session["tipoTranActual"] = null;
                Session.Abandon();

                IDictionaryEnumerator enumerator = HttpContext.Current.Cache.GetEnumerator();

                while (enumerator.MoveNext())
                {
                    HttpContext.Current.Cache.Remove(enumerator.Key.ToString());
                }

                Response.Redirect("principal.aspx?session=out", false);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
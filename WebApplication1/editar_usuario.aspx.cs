using Easy_Stock.AccesoDatos;
using Easy_Stock.Entidades;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Easy_Stock
{
    public partial class editar_usuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string accion = string.IsNullOrEmpty(Request.QueryString["accion"]) ? string.Empty : Request.QueryString["accion"];
            int idUsuario = string.IsNullOrEmpty(Request.QueryString["id"]) ? 0 : Convert.ToInt32(Request.QueryString["id"]);

            if (!IsPostBack)
            {
                cargarCombos();
                if (idUsuario > 0 && accion.Equals("editar"))
                {
                    Usuario oUsuario = AdUsuario.ObtenerUsuarios(string.Empty, string.Empty, idUsuario).FirstOrDefault();
                    txtNombre.Text = oUsuario.nombre;
                    txtApellido.Text = oUsuario.apellido;
                    txtClave.Text = oUsuario.clave;
                    txtEmail.Text = oUsuario.email;
                    cboTipoUsuario.SelectedValue = oUsuario.tipoUsuario.idTipoUsuario.ToString();
                    hTitulo.InnerText = "Editar usuario";
                    btnRegistrar.Text = "Guardar cambios";

                    if (oUsuario.idUsuario == ((Usuario)Session["usuario"]).idUsuario) 
                    {
                        cboTipoUsuario.Enabled = false;
                        cboTipoUsuario.Attributes["class"] = "form-control";
                    }
                }
            }
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            string accion = string.IsNullOrEmpty(Request.QueryString["accion"]) ? string.Empty : Request.QueryString["accion"];
            int idUsuario = string.IsNullOrEmpty(Request.QueryString["id"]) ? 0 : Convert.ToInt32(Request.QueryString["id"]);

            if (accion.Equals("editar"))
            {
                if (validarCampos())
                {
                    Usuario oUsuario = new Usuario
                    {
                        idUsuario = idUsuario,
                        nombre=txtNombre.Text,
                        apellido = txtApellido.Text,
                        clave = txtClave.Text,
                        email = txtEmail.Text,
                        tipoUsuario = new TipoUsuario { 
                            idTipoUsuario = Convert.ToInt32(cboTipoUsuario.SelectedValue)
                        }
                    };
                    if (AdUsuario.actualizarUsuario(oUsuario))
                    {
                        Response.Redirect("usuarios.aspx?edit=success",true);
                    }
                    else
                    {
                        divMensaje.Visible = true;
                        divMensaje.Attributes["class"] = Bootstrap.alertDangerDismissable;
                        hMensaje.InnerText = "Hubo un problema al guardar los cambios. Intente nuevamente";
                        return;
                    }
                }
            }
            else
            {
                if (validarCampos())
                {
                    Usuario oUsuario = new Usuario
                    {
                        nombre = txtNombre.Text,
                        apellido = txtApellido.Text,
                        clave = txtClave.Text,
                        email = txtEmail.Text,
                        tipoUsuario = new TipoUsuario
                        {
                            idTipoUsuario = Convert.ToInt32(cboTipoUsuario.SelectedValue)
                        }
                    };
                    if (AdUsuario.agregarUsuario(oUsuario))
                    {
                        divMensaje.Visible = true;
                        divMensaje.Attributes["class"] = Bootstrap.alertSuccesDismissable;
                        hMensaje.InnerText = "Usuario cargado correctamente";
                        reestablecerColoresCampos();
                        limpiarCampos();
                    }
                    else
                    {
                        divMensaje.Visible = true;
                        divMensaje.Attributes["class"] = Bootstrap.alertDangerDismissable;
                        hMensaje.InnerText = "Hubo un problema al cargar el usuario. Intentente nuevamente";
                        return;
                    }


                }
                else
                {
                    divMensaje.Visible = true;
                    divMensaje.Attributes["class"] = Bootstrap.alertDangerDismissable;
                    hMensaje.InnerText = "Por favor complete los campos obligatorios";
                    return;
                }
            }

        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {

        }

        private void cargarCombos()
        {
            List<TipoUsuario> lstTipos = AdUsuario.obtenerTiposUsuario();

            cboTipoUsuario.DataSource = null;
            cboTipoUsuario.DataSource = lstTipos;
            for (int i = 0; i < lstTipos.Count; i++)
            {
                ListItem li = new ListItem
                {
                    Text = lstTipos[i].tipoUsuario,
                    Value = lstTipos[i].idTipoUsuario.ToString()
                };
                cboTipoUsuario.Items.Add(li);
            }
        }


        private void limpiarCampos()
        {
            txtNombre.Text = string.Empty;
            txtApellido.Text = string.Empty;
            txtClave.Text = string.Empty;
            txtEmail.Text = string.Empty;
            cboTipoUsuario.SelectedValue = "0";
        }

        private void reestablecerColoresCampos()
        {
            WebControl[] aCampos = null;
            aCampos = new WebControl[] {
                txtNombre,
                txtApellido,
                txtEmail,
                txtClave,
                cboTipoUsuario
            };
            Validar.ReestablecerColores(aCampos);
        }


        private bool validarCampos()
        {
            WebControl[] aCampos = null;
            aCampos = new WebControl[] {
                txtNombre,
                txtApellido,
                txtEmail,
                txtClave,
                cboTipoUsuario
            };
            return Validar.ValidarCamposVacios(aCampos);

        }
    }
}
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
    public partial class editar_clientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        
        {
            if (!IsPostBack)
            {
                reestablecerColoresCampos();
                string tipoClienteNombre = Request.QueryString["tipo"];
                int idCliente = Convert.ToInt32(Request.QueryString["id"]);
                string accion = Request.QueryString["accion"];
                int tipoCliente = !string.IsNullOrEmpty(Request.QueryString["tipoCliente"]) ? Convert.ToInt32(Request.QueryString["tipoCliente"]) : 0;
                if (string.IsNullOrEmpty(tipoCliente.ToString()))
                {
                    cargarCombos(true, tipoCliente);
                }
                else
                {
                    cargarCombos(false, tipoCliente);
                    this.cboTipoCliente.SelectedValue = tipoCliente.ToString();
                }
                if (!string.IsNullOrEmpty(accion))
                {
                    switch (accion)
                    {
                        case "editar":
                            Cliente oCliente = AdCliente.obtenerClientePorId(idCliente, tipoCliente);

                            cboTipoCliente.SelectedValue = oCliente.tipoCliente.idTipoCliente.ToString();
                            txtTelefono.Text = oCliente.telefono;
                            txtEmail.Text = oCliente.email;
                            txtTelefono.Text = oCliente.telefono;
                            txtBarrio.Text = oCliente.barrio;
                            txtDireccion.Text = oCliente.direccion;
                            cboProvincias.SelectedValue = oCliente.provincia.idProvincia.ToString();
                            cboLocalidades.SelectedValue = oCliente.localidad.idLocalidad.ToString();
                            txtCodigoPostal.Text = string.IsNullOrEmpty(oCliente.codigoPostal) ? string.Empty : oCliente.codigoPostal;
                            if (tipoCliente == 1)
                            {
                                txtNombre.Text = oCliente.nombre;
                                txtApellido.Text = oCliente.apellido;
                                cboSexos.SelectedValue = oCliente.sexo.idSexo.ToString();
                                txtDocumento.Text = oCliente.dni;
                                txtFechaNac.Text = oCliente.fechaNacimiento.ToString();
                                divCamposPersona.Visible = true;
                            }
                            if (tipoCliente == 2)
                            {
                                txtCuit.Text = oCliente.cuit;
                                txtRazonSocial.Text = oCliente.razonSocial;
                                cboTipoEmpresa.SelectedValue = oCliente.tipoEmpresa.idTipoEmpresa.ToString();
                                divCamposEmpresa.Visible = true;
                            }
                            btnAgregarCliente.Text = "Guardar cambios";
                            break;
                        case "eliminar":
                            break;
                        case "cli_carrito":
                            string docu = Request.QueryString["doc"];
                            if (docu != "0") { txtDocumento.Text = docu;txtCuit.Text = docu; }
                            btnAgregarCliente.Text = "Guardar y continuar";
                            break;

                        default:
                            break;
                    }
                }
            }

        }

        private void cargarCombos(bool esPrimeraVez = false, int tipoCliente = 0)
        {
            List<TipoCliente> lstTipoCliente = AdGeneral.obtenerTiposClientes();
            List<Localidad> lstLocalidades = AdGeneral.obtenerLocalidades();
            List<Provincia> lstProvincias = AdGeneral.obtenerProvincias();

            //Tipos clientes
            cboTipoCliente.DataSource = null;
            cboTipoCliente.DataBind();
            cboTipoCliente.DataSource = lstTipoCliente;
            for (int i = 0; i < lstTipoCliente.Count; i++)
            {
                ListItem li = new ListItem
                {
                    Text = lstTipoCliente[i].tipoCliente,
                    Value = lstTipoCliente[i].idTipoCliente.ToString()
                };
                cboTipoCliente.Items.Add(li);
            }
            //Localidades
            cboLocalidades.DataSource = null;
            cboLocalidades.DataBind();
            for (int i = 0; i < lstLocalidades.Count; i++)
            {
                ListItem li = new ListItem
                {
                    Text = lstLocalidades[i].localidad,
                    Value = lstLocalidades[i].idLocalidad.ToString()
                };
                cboLocalidades.Items.Add(li);
            }
            //Provincias
            cboProvincias.DataSource = null;
            cboProvincias.DataBind();
            for (int i = 0; i < lstProvincias.Count; i++)
            {
                ListItem li = new ListItem
                {
                    Text = lstProvincias[i].provincia,
                    Value = lstProvincias[i].idProvincia.ToString()
                };
                cboProvincias.Items.Add(li);
            }

            if (!esPrimeraVez)
            {
                if (tipoCliente == 1) //persona
                {
                    cboSexos.DataSource = null;
                    cboSexos.DataBind();
                    List<Sexo> lstSexos = AdGeneral.obtenerSexos();
                    for (int i = 0; i < lstSexos.Count; i++)
                    {
                        ListItem li = new ListItem
                        {
                            Text = lstSexos[i].sexo,
                            Value = lstSexos[i].idSexo.ToString()
                        };
                        cboSexos.Items.Add(li);
                    }
                }
                if (tipoCliente == 2) //empresa
                {
                    cboTipoEmpresa.DataSource = null;
                    cboTipoEmpresa.DataBind();
                    List<TipoEmpresa> lstTipoEmpresa = AdGeneral.obtenerTiposEmpresa();
                    for (int i = 0; i < lstTipoEmpresa.Count; i++)
                    {
                        ListItem li = new ListItem
                        {
                            Text = lstTipoEmpresa[i].tipoEmpresa,
                            Value = lstTipoEmpresa[i].idTipoEmpresa.ToString()
                        };
                        cboTipoEmpresa.Items.Add(li);
                    }
                }
            }

        }

        protected void cboTipoCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            string value = this.cboTipoCliente.SelectedValue;
            string accion = this.cboTipoCliente.SelectedValue == "1" ? "persona" : this.cboTipoCliente.SelectedValue == "2" ? "empresa" : string.Empty;
            string carrito = !string.IsNullOrEmpty(Request.QueryString["accion"]) && Request.QueryString["accion"].Equals("cli_carrito") ? Request.QueryString["accion"]:string.Empty;
            string docuCarrito = Request.QueryString["doc"] != null ? Request.QueryString["doc"] : string.Empty;
            if (carrito.Equals("cli_carrito"))
            {
                Response.Redirect("editar_clientes.aspx?accion=cli_carrito"+(!string.IsNullOrEmpty(docuCarrito)?"&doc="+docuCarrito + "&tipoCliente=" + value : "&tipoCliente=" + value));
            }
            else Response.Redirect("editar_clientes.aspx?tipo=" + accion + "&tipoCliente=" + value);
        }

        protected void btnAgregarCliente_Click(object sender, EventArgs e)
        {
            int tipoCliente = Convert.ToInt32(cboTipoCliente.SelectedValue);
            string accion = Request.QueryString["accion"];
            if (validarCampos(tipoCliente))
            {
                Cliente oCliente = new Cliente
                {
                    idCliente = Convert.ToInt32(Request.QueryString["id"]),
                    nombre = string.IsNullOrEmpty(txtNombre.Text) ? null : txtNombre.Text,
                    apellido = string.IsNullOrEmpty(txtApellido.Text) ? null : txtApellido.Text,
                    dni = string.IsNullOrEmpty(txtDocumento.Text) ? null : txtDocumento.Text,
                    telefono = string.IsNullOrEmpty(txtTelefono.Text) ? null : txtTelefono.Text,
                    email = string.IsNullOrEmpty(txtEmail.Text) ? null : txtEmail.Text,
                    direccion = string.IsNullOrEmpty(txtDireccion.Text) ? null : txtDireccion.Text,
                    codigoPostal = txtCodigoPostal.Text,
                    barrio = string.IsNullOrEmpty(txtBarrio.Text) ? null : txtBarrio.Text,
                    tipoCliente = new TipoCliente
                    {
                        idTipoCliente = Convert.ToInt32(cboTipoCliente.SelectedValue)
                    },
                    fechaNacimiento = string.IsNullOrEmpty(txtFechaNac.Text) ? default : Convert.ToDateTime(txtFechaNac.Text),
                    sexo = new Sexo
                    {
                        idSexo = string.IsNullOrEmpty(cboSexos.SelectedValue) ? 0 : Convert.ToInt32(cboSexos.SelectedValue)
                    },
                    tipoEmpresa = new TipoEmpresa
                    {
                        idTipoEmpresa = string.IsNullOrEmpty(cboTipoEmpresa.SelectedValue) ? 0 : Convert.ToInt32(cboTipoEmpresa.SelectedValue)
                    },
                    localidad = new Localidad
                    {
                        idLocalidad = Convert.ToInt32(cboLocalidades.SelectedValue)
                    },
                    provincia = new Provincia
                    {
                        idProvincia = Convert.ToInt32(cboProvincias.SelectedValue)
                    },
                    razonSocial = string.IsNullOrEmpty(txtRazonSocial.Text) ? null : txtRazonSocial.Text,
                    cuit = string.IsNullOrEmpty(txtCuit.Text) ? null : txtCuit.Text,
                    habilitado = true
                };
                if (!AdCliente.verificarDniCuitExiste((tipoCliente == 1) ? oCliente.dni : oCliente.cuit,oCliente.idCliente))
                {
                    if (accion.Equals("editar"))
                    {
                        if (AdCliente.actualizarCliente(oCliente, tipoCliente))
                        {
                            divMensaje.Visible = true;
                            divMensaje.Attributes["class"] = Bootstrap.alertSuccesDismissable;
                            hMensaje.InnerText = "El cliente se actualizó correctamente";
                            limpiarCampos();
                        }
                    }
                    else 
                    {
                        if (accion.Equals("eliminar"))
                        {
                            if (AdCliente.agregarCliente(oCliente, tipoCliente))
                            {
                                divMensaje.Visible = true;
                                divMensaje.Attributes["class"] = Bootstrap.alertSuccesDismissable;
                                hMensaje.InnerText = "Cliente cargado correctamente";
                                reestablecerColoresCampos();
                                limpiarCampos();
                            }
                            else
                            {
                                divMensaje.Visible = true;
                                divMensaje.Attributes["class"] = Bootstrap.alertDangerDismissable;
                                hMensaje.InnerText = "Hubo en error al cargar los datos. Intente nuevamente";
                            }
                        }
                        else {
                            if (accion.Equals("cli_carrito"))
                            {
                                if (AdCliente.agregarCliente(oCliente, tipoCliente))
                                {
                                    divMensaje.Visible = true;
                                    divMensaje.Attributes["class"] = Bootstrap.alertSuccesDismissable;
                                    reestablecerColoresCampos();
                                    limpiarCampos();
                                    Session["clienteCarrito"] = oCliente;
                                    Response.Redirect("pago_carrito.aspx");
                                }
                                else
                                {
                                    divMensaje.Visible = true;
                                    divMensaje.Attributes["class"] = Bootstrap.alertDangerDismissable;
                                    hMensaje.InnerText = "Hubo en error al cargar los datos. Intente nuevamente";
                                }
                            }
                        }
                       
                    }
                   
                }
                else
                {
                    divMensaje.Visible = true;
                    divMensaje.Attributes["class"] = Bootstrap.alertWarningDismissable;
                    hMensaje.InnerText = "El documento o cuit ingresado ya pertenece a un cliente";
                    reestablecerColoresCampos();
                    txtDocumento.BorderColor = Color.Red;
                    txtCuit.BorderColor = Color.Red;
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

        private void limpiarCampos()
        {
            cboTipoCliente.SelectedValue = "0";
            txtNombre.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            txtApellido.Text= string.Empty;
            cboSexos.SelectedValue = "0";
            txtDocumento.Text = string.Empty;
            txtFechaNac.Text= string.Empty;
            txtEmail.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtBarrio.Text = string.Empty;
            cboLocalidades.SelectedValue = "0";
            cboProvincias.SelectedValue = "0";
            txtRazonSocial.Text = string.Empty;
            txtCuit.Text = string.Empty;
            cboTipoEmpresa.SelectedValue = "0";
            //this.reestablecerValoresCampos(ref aCampos);
        }

        private void reestablecerColoresCampos()
        {

            WebControl[] aCampos = new WebControl[] {
                txtNombre,
                txtTelefono,
                txtApellido,
                cboSexos,
                txtDocumento,
                txtFechaNac,
                txtEmail,
                txtDireccion,
                txtBarrio,
                cboLocalidades,
                cboProvincias,
                txtRazonSocial,
                txtCuit,
                cboTipoEmpresa
                };
            Validar.ReestablecerColores(aCampos);
        }
        private bool validarCampos(int tipoCliente)
        {
            WebControl[] aCampos = null;
            if (tipoCliente == 1)//persona
            {
                aCampos = new WebControl[] {
                txtNombre,
                txtTelefono,
                txtApellido,
                cboSexos,
                txtDocumento,
                txtFechaNac,
                txtEmail,
                txtDireccion,
                txtBarrio,
                cboLocalidades,
                cboProvincias,
                };
            }
            if (tipoCliente == 2)
            {
                aCampos = new WebControl[] {
                txtTelefono,
                txtEmail,
                txtDireccion,
                txtBarrio,
                cboLocalidades,
                cboProvincias,
                txtRazonSocial,
                txtCuit,
                cboTipoEmpresa
                };
            }
            return Validar.ValidarCamposVacios(aCampos);

        }

    }
}
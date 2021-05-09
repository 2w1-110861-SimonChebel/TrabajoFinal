<%@ Page Title="" Language="C#" MasterPageFile="~/Header.Master" AutoEventWireup="true" CodeBehind="editar_clientes.aspx.cs" Inherits="Easy_Stock.editar_clientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form-group col-xl-6 col-md-6">
        <div id="divTitulo" class="col-md-6 col-xl-6" style="display: flex; justify-items: right" runat="server">
            <h2>Nuevo Cliente</h2>
        </div>

        <div id="divMensaje" runat="server">
            <h6 id="hMensaje" runat="server"></h6>
        </div>
        <label for="cboTipoCliente" class="control-label">Tipo de cliente</label>
        <asp:DropDownList class="form-control" ID="cboTipoCliente" name="cboTipoCliente" runat="server" AutoPostBack="true" OnSelectedIndexChanged="cboTipoCliente_SelectedIndexChanged">
            <asp:ListItem Value="0">- Seleccione -</asp:ListItem>
        </asp:DropDownList>
    </div>


    <%if (Request.QueryString["tipoCliente"] != null && Request.QueryString["tipoCliente"] =="1")
      {%>
    <div id="divCamposPersona" class="form-group col-xl-6 col-md-6" runat="server">
        <div class="form-group">
            <label for="nombre" class="control-label">Nombre (*)</label>
            <asp:TextBox type="text" class="form-control" ID="txtNombre" name="txtNombre" runat="server" MaxLength="100"> </asp:TextBox>
        </div>

        <div class="form-group">
            <label for="apellido" class="control-label">Apellido (*)</label>
            <asp:TextBox type="text" class="form-control" ID="txtApellido" name="txtApellido" runat="server" MaxLength="100"> </asp:TextBox>
        </div>


        <div class="form-group">
            <label for="sexo" class="control-label">Sexo (*)</label>
            <asp:DropDownList class="form-control" ID="cboSexos" name="cboSexos" runat="server">
                <asp:ListItem Value="0">- Seleccione -</asp:ListItem>
            </asp:DropDownList>
        </div>

        <div class="form-group">
            <label for="documento" class="control-label">Documento (Dni, LC, LE) (*)</label>
            <asp:TextBox type="text" class="form-control" ID="txtDocumento" name="txtDocumento" runat="server" MaxLength="30"> </asp:TextBox>
        </div>

        <div class="form-group">
            <label for="fechaNac" class="control-label">Fecha de nacimiento (*)</label>
            <asp:TextBox type="date" class="form-control" ID="txtFechaNac" name="txtFechaNac" runat="server"> </asp:TextBox>
        </div>

    </div>
    <%}
        else if (Request.QueryString["tipoCliente"] != null && Request.QueryString["tipoCliente"]=="2")
        {%>
    <div id="divCamposEmpresa" class="form-group col-xl-6 col-md-6" runat="server">
        <div class="form-group">
            <label for="razonSocial" class="control-label">Razón Social (*)</label>
            <asp:TextBox type="text" class="form-control" ID="txtRazonSocial" name="txtRazonSocial" runat="server" MaxLength="100"> </asp:TextBox>
        </div>

        <div class="form-group">
            <label for="cuit" class="control-label">CUIT/CUIL (*)</label>
            <asp:TextBox type="text" class="form-control" ID="txtCuit" name="txtCuit" runat="server" MaxLength="30"> </asp:TextBox>
        </div>

        <div class="form-group">
            <label for="tipoEmpresa" class="control-label">Tipo de empresa (*)</label>
            <asp:DropDownList class="form-control" ID="cboTipoEmpresa" name="cboTipoEmpresa" runat="server">
                <asp:ListItem Value="0">- Seleccione -</asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>
    <%}%>

    <%if (Convert.ToInt32(cboTipoCliente.SelectedValue) > 0)
        {%>
    <div id="divCamposGenerales" class="form-group col-xl-6 col-md-6" runat="server">

         <div class="form-group">
            <label for="telefono" class="control-label">Teléfono (*)</label>
            <asp:TextBox type="text" class="form-control" ID="txtTelefono" name="txtTelefono" runat="server" MaxLength="70"> </asp:TextBox>
        </div>

        <div class="form-group">
            <label for="email" class="control-label">Email (*)</label>
            <asp:TextBox type="text" class="form-control" ID="txtEmail" name="txtEmail" runat="server" MaxLength="70"> </asp:TextBox>
        </div>
        <div class="form-group">
            <label for="direccion" class="control-label">Dirección (*)</label>
            <asp:TextBox type="text" class="form-control" ID="txtDireccion" name="txtDireccion" runat="server" MaxLength="60"> </asp:TextBox>
        </div>
        <div class="form-group">
            <label for="Barrio" class="control-label">Barrio (*)</label>
            <asp:TextBox type="text" class="form-control" ID="txtBarrio" name="txtBarrio" runat="server" MaxLength="100"> </asp:TextBox>
        </div>

        <div class="form-group">
            <label for="localidad" class="control-label">Localidad (*)</label>
            <asp:DropDownList class="form-control" ID="cboLocalidades" name="cboLocalidades" runat="server">
                <asp:ListItem Value="0">- Seleccione -</asp:ListItem>
            </asp:DropDownList>
        </div>

        <div class="form-group">
            <label for="street1_id" class="control-label">Provincia (*)</label>
            <asp:DropDownList class="form-control" ID="cboProvincias" name="cboProvincias" runat="server">
                <asp:ListItem Value="0">- Seleccione -</asp:ListItem>
            </asp:DropDownList>
        </div>

        <div class="form-group">
            <label for="codigoPostal" class="control-label">Código Postal</label>
            <asp:TextBox type="text" class="form-control" ID="txtCodigoPostal" name="txtCodigoPostal" MaxLength="10" runat="server"> </asp:TextBox>
        </div>
    </div>
    <%} %>
    <%if (Convert.ToInt32(cboTipoCliente.SelectedValue) > 0)
        { %>
    <div id="divBotones" class="form-group col-xl-6 col-md-6" runat="server">
        <div class="form-group" style="display: flex; justify-content: center">
            <asp:Button ID="btnAgregarCliente" Text="Agregar cliente" type="button" class="btn btn-primary" runat="server" OnClick="btnAgregarCliente_Click" />
        </div>

        <div class="form-group" style="display: flex; justify-content: center">
            <asp:Button Text="Limpiar campos" type="button" class="btn btn-secondary" runat="server" />
        </div>
    </div>
    <%} %>

    <script>
        function colorControl(control) {
            if (control.value === null || control.value === "0") {
                control.style.borderColor = "red";
            }
            else {
                control.style.borderColor = "white";
            }
        }
    </script>

</asp:Content>

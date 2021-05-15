<%@ Page Title="" Language="C#" MasterPageFile="~/Header.Master" AutoEventWireup="true" CodeBehind="editar_proveedor.aspx.cs" Inherits="Easy_Stock.editar_proveedor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="col-md-6 col-xl-6 ">
        <div id="divMensaje" class="alert alert-success" visible="false" runat="server">
            <h6 id="hMensaje" runat="server"></h6>
        </div>

        <div id="divTitulo" class="col-md-6 col-xl-6" style="display: flex; justify-items: right" runat="server">
            <h2>Nuevo Proveedor</h2>
        </div>
        <div class="form-group">
            <label for="txtNombre" class="control-label">Nombre</label>
            <asp:TextBox type="text" class="form-control" ID="txtNombre" name="txtNombre" runat="server"> </asp:TextBox>
        </div>
        <div class="form-group">
            <label for="txtEmail" class="control-label">Email</label>
            <asp:TextBox type="text" class="form-control" ID="txtEmail" name="txtEmail" runat="server"> </asp:TextBox>
        </div>

        <div class="form-group">
            <label for="txtTelefono" class="control-label">Teléfono</label>
            <asp:TextBox type="text" class="form-control" ID="txtTelefono" name="txtTelefono" runat="server"> </asp:TextBox>
        </div>

        <div class="form-group">
            <label for="TxtCodigoPostal" class="control-label">Codigo Postal</label>
            <asp:TextBox type="text" class="form-control" ID="TxtCodigoPostal" name="TxtCodigoPostal" runat="server"> </asp:TextBox>
        </div>

        <div class="form-group">
            <label for="TxtDireccion" class="control-label">Dirección</label>
            <asp:TextBox type="text" class="form-control" ID="TxtDireccion" name="TxtDireccion" runat="server"> </asp:TextBox>
        </div>

        <div class="form-group">
            <label for="txtBarrio" class="control-label">Barrio</label>
            <asp:TextBox type="text" class="form-control" ID="txtBarrio" name="txtBarrio" runat="server"> </asp:TextBox>
        </div>

        <div class="form-group">
            <label for="localidad" class="control-label">Localidad</label>
            <asp:DropDownList class="form-control" ID="cboLocalidades" name="cboLocalidades" runat="server">
                <asp:ListItem Value="0">- Seleccione -</asp:ListItem>
            </asp:DropDownList>
        </div>

        <div class="form-group">
            <label for="Provincia" class="control-label">Provincia</label>
            <asp:DropDownList class="form-control" ID="cboProvincias" name="cboProvincias" runat="server">
                <asp:ListItem Value="0">- Seleccione -</asp:ListItem>
            </asp:DropDownList>
        </div>

        <div class="form-group" style="display: flex; justify-content: center">
            <asp:Button ID="btnAgregarProveedor" Text="Agregar proveedor" type="button" class="btn btn-primary" runat="server" OnClick="btnAgregarProveedor_Click" />
        </div>

        <div class="form-group" style="display: flex; justify-content: center">
            <asp:Button Text="Limpiar campos" type="button" class="btn btn-secondary" runat="server" />
        </div>

    </div>

</asp:Content>

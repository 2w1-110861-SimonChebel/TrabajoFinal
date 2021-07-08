<%@ Page Title="" Language="C#" MasterPageFile="~/Header.Master" AutoEventWireup="true" CodeBehind="editar_usuario.aspx.cs" Inherits="Easy_Stock.editar_usuario" %>
<%@ Import Namespace="Easy_Stock.Entidades" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-6 col-xl-6 ">

         <div id="divTitulo" class="alert alert-info" runat="server" style="padding:20px">
                <h3 id="hTitulo" runat="server">Nuevo usuario</h3>
        </div>
        <div id="divMensaje" runat="server">
                <h6 id="hMensaje" runat="server"></h6>
        </div>

        <div class="form-group">
            <label for="nombre" class="control-label">Nombre</label>
            <asp:TextBox type="text" class="form-control" ID="txtNombre" name="txtNombre" runat="server"> </asp:TextBox>
        </div>

        <div class="form-group">
            <label for="apellido" class="control-label">Apellido</label>
            <asp:TextBox type="text" class="form-control" ID="txtApellido" name="txtApellido" runat="server"> </asp:TextBox>
        </div>
   
        <div class="form-group">
            <label for="cboTipo" class="control-label">Tipo de usuario</label>
            <asp:DropDownList class="form-control" ID="cboTipoUsuario" name="cboTipoUsuario" runat="server">
                <asp:ListItem Value="0">- Seleccione -</asp:ListItem>
            </asp:DropDownList>
        </div>

        <div class="form-group">
            <label for="txtEmail" class="control-label">Email</label>
            <asp:TextBox type="text" class="form-control" ID="txtEmail" name="txtEmail" runat="server"> </asp:TextBox>
        </div>

        <div class="form-group">
            <label for="txtClave" class="control-label">Clave</label>
            <asp:TextBox type="text" class="form-control" ID="txtClave" name="txtClave" runat="server"> </asp:TextBox>
        </div>

        <div class="row" style="justify-content:center">

            <div class="form-group" style="display: flex;padding-left:10px"">
                <asp:Button ID="btnRegistrar" Text="Registrar" type="button" class="btn btn-success" runat="server" OnClientClick="return preguntarGuardar();" OnClick="btnRegistrar_Click" />
            </div>
        </div>


    </div>
</asp:Content>

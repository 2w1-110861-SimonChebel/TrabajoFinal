<%@ Page Title="" Language="C#" MasterPageFile="~/Header.Master" AutoEventWireup="true" CodeBehind="editar_cat.aspx.cs" Inherits="Easy_Stock.editar_cat" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row col-12" runat="server" id="divTitulo" style="margin: 1%">
        <h4 id="hTitulo" runat="server">Nueva categoria</h4>
    </div>

    <div class="col-12" runat="server" id="divMensaje">
        <h5 id="hMensaje" runat="server"></h5>
    </div>

    <div class="row col-12">
        <div id="divCampos" class="form-group col-xl-6 col-md-6" runat="server">
            <div class="form-group">
                <label for="telefono" class="control-label">Nombre (*)</label>
                <asp:TextBox type="text" class="form-control" ID="txtNombre" name="txtNombre" runat="server" MaxLength="70"> </asp:TextBox>
            </div>

            <div class="form-group">
                <label for="email" class="control-label">Descripción</label>
                <asp:TextBox type="text" class="form-control" ID="txtDesc" name="txtDesc" runat="server" MaxLength="70"> </asp:TextBox>
            </div>
        </div>

    </div>

    <div id="divBotones" class="form-group col-xl-6 col-md-6" runat="server">
        <div class="form-group" style="display: flex; justify-content: center">
            <asp:Button ID="btnAgregarCategoria" Text="Agregar" type="button" class="btn btn-primary" runat="server" OnClientClick="return preguntarGuardar();" OnClick="btnAgregarCliente_Click" />
        </div>

        <div class="form-group" style="display: flex; justify-content: center">
            <asp:Button Text="Limpiar campos" type="button" class="btn btn-secondary" runat="server" />
        </div>
    </div>
</asp:Content>

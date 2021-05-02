<%@ Page Title="" Language="C#" MasterPageFile="~/Header.Master" AutoEventWireup="true" CodeBehind="editar_deposito.aspx.cs" Inherits="Easy_Stock.editar_deposito" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:HiddenField id="hfIdDeposito" runat="server"/>
         <div class="col-md-6 col-xl-6 ">
            <div id="divMensaje" class="alert alert-success" runat="server">
                <h6 id="hMensaje" runat="server"></h6>
            </div>

        <%--    <div id="divErrorCargaProducto" class="alert alert-danger" style="display: none" runat="server">
                <h6>Hubo en error en la carga. Verifique los datos y vuelva a intentarlo</h6>
            </div>--%>

            <div id="divTitulo" class="col-md-6 col-xl-6" style="display: flex; justify-items: right" runat="server">
                <h2>Nuevo Deposito</h2>
            </div>
            <div class="form-group">
                <label for="nombre" class="control-label">Nombre</label>
                <asp:TextBox type="text" class="form-control" ID="txtNombreSucursal" name="txtNombreSucursal" runat="server"> </asp:TextBox>
            </div>
            <div class="form-group">
                <label for="descripcion" class="control-label">Descripcion</label>
                <asp:TextBox type="text" class="form-control" ID="txtDescripcion" name="txtDescripcion" runat="server"> </asp:TextBox>
            </div>      

            <div class="form-group">
                <label for="direccion" class="control-label">Dirección</label>
                <asp:TextBox type="text" class="form-control" ID="txtDireccionDeposito"  name="txtDireccionDeposito" runat="server"> </asp:TextBox>

            </div>

            <div class="form-group">
                <label for="localidad" class="control-label">Localidad</label>
                <asp:DropDownList class="form-control" ID="cboLocalidades" name="cboLocalidades" runat="server">
                    <asp:ListItem Value="0">- Seleccione -</asp:ListItem>
                </asp:DropDownList>
            </div>

            <div class="form-group">
                <label for="Provincia" class="control-label">Provincias</label>
                <asp:DropDownList class="form-control" ID="cboProvincias" name="cboProvincias" runat="server">
                    <asp:ListItem Value="0">- Seleccione -</asp:ListItem>
                </asp:DropDownList>
            </div>


            <div class="form-group">
                <label for="completo" class="control-label">Completo</label>
                <asp:DropDownList class="form-control" ID="cboCompleto" name="cboCompleto" runat="server">
                    <asp:ListItem Value="-1">- Seleccione -</asp:ListItem>
                    <asp:ListItem Value="0">No</asp:ListItem>
                    <asp:ListItem Value="1">Si</asp:ListItem>
                </asp:DropDownList>
            </div>

            <div class="form-group" style="display: flex; justify-content: center">
                <asp:Button ID="btnAgregarDeposito" Text="Agregar deposito" type="button" class="btn btn-primary" runat="server" OnClick="btnAgregarDeposito_Click" />
            </div>

            <div class="form-group" style="display: flex; justify-content: center">
                <asp:Button  Text="Limpiar campos" type="button" class="btn btn-secondary" runat="server" />
            </div>

        </div>

</asp:Content>

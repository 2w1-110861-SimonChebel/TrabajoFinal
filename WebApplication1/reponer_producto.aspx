<%@ Page Title="" Language="C#" MasterPageFile="~/Header.Master" AutoEventWireup="true" CodeBehind="reponer_producto.aspx.cs" Inherits="Easy_Stock.reponer_producto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="divMensaje" runat="server">
        <h4 id="hMensaje" runat="server"></h4>
    </div>
    <div class="row">
        <div class="col-md-6 col-xl-6" style="padding: 20px">
            <asp:TextBox ID="txtBuscar" runat="server" class="form-control mr-sm-2" aria-label="Buscar"></asp:TextBox>
        </div>
        <div class="col-md-6 col-xl-6" style="padding: 20px">
            <asp:Button runat="server" ID="btnBuscarProducto" type="button" class="btn btn-dark" Text="Buscar" OnClick="btnBuscarProducto_Click" />
        </div>
    </div>

    <%
     if (this.oProducto != null){ 
    %>
    <table id="tblProducto" class="table table-striped">
        <thead>
            <tr>
                <th scope="#">Código</th>
                <th scope="col">Nombre</th>
                <th scope="col">Cantidad restante</th>
                <th scope="col">Cantidad a reponer</th>
            </tr>
        </thead>
        <tbody>
            <tr>
                <th scope="row"><%#Eval(oProducto.idProducto.ToString())%></th>
                <td><%#Eval(oProducto.nombre)%></td>
                <td><%#Eval(oProducto.cantidadRestante.ToString())%></td>
                <td><%#Eval(oProducto.nombre)%></td>
            </tr>

        </tbody>
    </table>

 <%}%>
    <asp:GridView ID="grvProducto" runat="server" Height="277px" Width="897px" CssClass="mydatagrid; header; rows;">
        <Columns>
            <asp:TemplateField HeaderText="Código" HeaderStyle-CssClass="absolute" ItemStyle-CssClass="col-lg-5 col-xs-10">
                <ItemTemplate>
                    <div id="divCodigoProducto" style="padding-top: 10px;">
                        <b><%#Eval("idProducto")%></b>
                    </div>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Nombre" HeaderStyle-CssClass="absolute" ItemStyle-CssClass="col-lg-5 col-xs-10">
                <ItemTemplate>
                    <div id="divCodigoProducto" style="padding-top: 10px;">
                        <b><%#Eval("nombre")%></b>
                    </div>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Cantidad restante" HeaderStyle-CssClass="absolute" ItemStyle-CssClass="col-lg-5 col-xs-10">
                <ItemTemplate>
                    <div id="divCodigoProducto" style="padding-top: 10px;">
                        <b><%#Eval("cantidadRestante")%></b>
                    </div>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Cantidad a reponer" HeaderStyle-CssClass="absolute" ItemStyle-CssClass="col-lg-5 col-xs-10">
                <ItemTemplate>
                    <div id="divCodigoProducto" style="padding-top: 10px;">
                        <asp:TextBox ID="txtNuevaCantidad" runat="server"></asp:TextBox>
                    </div>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>

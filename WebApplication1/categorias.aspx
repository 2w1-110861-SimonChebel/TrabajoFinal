<%@ Page Title="" Language="C#" MasterPageFile="~/Header.Master" AutoEventWireup="true" CodeBehind="categorias.aspx.cs" Inherits="Easy_Stock.categorias" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="col-xl-12 col-md-12">

           <div class="row" style="padding-left: 10%">
            <div class="col-md-6 col-xl-6" style="padding: 20px">
                <asp:TextBox ID="txtBuscarCat" CssClass="form-control" PlaceHolder="Nombre" runat="server"></asp:TextBox>
            </div>
            <div class="col-md-6 col-xl-6" style="padding: 20px">
                <asp:Button runat="server" ID="btnBuscarCat" CssClass="btn btn-dark" type="button" Text="Buscar" OnClick="btnBuscarCat_Click" />
                <asp:Button runat="server" ID="btnRecargar" CssClass="btn btn-light" type="button" Text="Recargar" OnClick="btnRecargar_Click" ToolTip="Recargar el listado" />
                <asp:Button runat="server" ID="btnNuevaCat" CssClass="btn btn-success" type="button" Text="Nueva" OnClick="btnNuevaCat_Click" />
            </div>

        </div>


        <div class="row col-12">
            <div id="divMensaje" runat="server" visible="false">
                <h5 id="hMensaje" runat="server"></h5>
            </div>
        </div>
        <asp:GridView ID="grvCategorias" runat="server" Height="277px" Width="90%" CssClass="gridViewCarritoHeader gridViewCarrito" OnSelectedIndexChanged="grvCategorias_SelectedIndexChanged" OnRowCommand="grvCategorias_RowCommand" AutoGenerateColumns="False">
            <Columns>
                <asp:TemplateField HeaderText="ID" HeaderStyle-CssClass="absolute" ItemStyle-CssClass="col-lg-5 col-xs-10" Visible="false">
                    <ItemTemplate>
                        <div id="divCodigoProducto" style="padding-top: 10px;">
                            <b><%#Eval("idCategoria") %></b>
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Nombre" HeaderStyle-CssClass="absolute" ItemStyle-CssClass="col-lg-5 col-xs-10">
                    <ItemTemplate>
                        <div id="divCodigoProducto" style="padding-top: 10px;">
                            <b><%#Eval("nombre") %></b>
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Descripción" HeaderStyle-CssClass="absolute" ItemStyle-CssClass="col-lg-5 col-xs-10">
                    <ItemTemplate>
                        <div id="divCodigoProducto" style="padding-top: 10px;">
                            <b><%#Eval("descripcion") %></b>
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Acciones" HeaderStyle-CssClass="absolute" ItemStyle-CssClass="col-lg-5 col-xs-10">
                    <ItemTemplate>
                        <div id="divAcciones" style="padding-top: 10px;">
                            <b>
                                <asp:Button runat="server" ID="btnEditarCat" type="button" class="btn btn-info" Text="Editar" CommandArgument='<%#Eval("idCategoria")/*+","+ ((GridViewRow)Container).RowIndex.ToString()*/%>' CommandName="editar" OnClick="btnEditarCat_Click" /></b>
                            <b>
                                <asp:Button runat="server" ID="btnEliminarCat" type="button" class="btn btn-danger" CommandArgument='<%#Eval("idCategoria")/*+","+ ((GridViewRow)Container).RowIndex.ToString()*/%>' CommandName="eliminar" Text="Eliminar" OnClientClick="preguntarEliminarRegistro();" OnClick="btnEliminarCat_Click"></asp:Button></b>
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>



            </Columns>
        </asp:GridView>
    </div>

</asp:Content>

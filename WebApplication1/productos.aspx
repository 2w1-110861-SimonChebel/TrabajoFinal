<%@ Page Title="" Language="C#" MasterPageFile="~/Header.Master" AutoEventWireup="true" CodeBehind="productos.aspx.cs" Inherits="Easy_Stock.productos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="table-responsive">
        <div class="col-xl-12 col-md-12">

            <div id="divMensaje" class="alert alert-danger" style="display: none" runat="server">
                <h6>El usuario y/o contraseña son incorrectos</h6>
            </div>
            <asp:GridView ID="grvProductos" runat="server" Height="277px" Width="897px" CssClass="table table-condensed table-hover" OnSelectedIndexChanged="btnEditarProducto_Click" OnRowCommand="grvProductos_RowCommand">
                <Columns>
                    <asp:TemplateField HeaderText="Código" HeaderStyle-CssClass="absolute" ItemStyle-CssClass="col-lg-5 col-xs-10">
                        <ItemTemplate>
                            <div id="divIdProducto" style="padding-top: 10px;">
                                <b><%#Eval("idProducto") %></b>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Producto" HeaderStyle-CssClass="absolute" ItemStyle-CssClass="col-lg-5 col-xs-10">
                        <ItemTemplate>
                            <div id="divNombreProducto" style="padding-top: 10px;">
                                <b><%#Eval("nombre") %></b>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Descripción" HeaderStyle-CssClass="absolute" ItemStyle-CssClass="col-lg-5 col-xs-10">
                        <ItemTemplate>
                            <div id="divDescripcion" style="padding-top: 10px;">
                                <b><%#Eval("descripcion") %></b>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Marca" HeaderStyle-CssClass="absolute" ItemStyle-CssClass="col-lg-5 col-xs-10">
                        <ItemTemplate>
                            <div id="divMarca" style="padding-top: 10px;">
                                <b><%#Eval("marca.marca") %></b>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Precio de venta" HeaderStyle-CssClass="absolute" ItemStyle-CssClass="col-lg-5 col-xs-10">
                        <ItemTemplate>
                            <div id="divPrecioVenta" style="padding-top: 10px;">
                                <b>$<%#Eval("precioVenta") %></b>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Precio costo" HeaderStyle-CssClass="absolute" ItemStyle-CssClass="col-lg-5 col-xs-10">
                        <ItemTemplate>
                            <div id="divPrecioCosto" style="padding-top: 10px;">
                                <b>$<%#Eval("precioCosto") %></b>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Stock mínimo" HeaderStyle-CssClass="absolute" ItemStyle-CssClass="col-lg-5 col-xs-10">
                        <ItemTemplate>
                            <div id="divStockMin" style="padding-top: 10px;">
                                <b><%#Eval("stockMinimo") %> u.</b>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Stock máximo" HeaderStyle-CssClass="absolute" ItemStyle-CssClass="col-lg-5 col-xs-10">
                        <ItemTemplate>
                            <div id="divStockMax" style="padding-top: 10px;">
                                <b><%#Eval("stockMaximo") %> u.</b>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Categoria" HeaderStyle-CssClass="absolute" ItemStyle-CssClass="col-lg-5 col-xs-10">
                        <ItemTemplate>
                            <div id="divCategoria" style="padding-top: 10px;">
                                <b><%#Eval("categoria.nombre") %></b>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Cantidad restante" HeaderStyle-CssClass="absolute" ItemStyle-CssClass="col-lg-5 col-xs-10">
                        <ItemTemplate>
                            <div id="divCantidadRestante" style="padding-top: 10px;">
                                <b><%#Eval("cantidadRestante") %></b>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Proveedor" HeaderStyle-CssClass="absolute" ItemStyle-CssClass="col-lg-5 col-xs-10">
                        <ItemTemplate>
                            <div id="divProveedor" style="padding-top: 10px;">
                                <b><%#Eval("proveedor.nombre") %></b>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Acciones" HeaderStyle-CssClass="absolute" ItemStyle-CssClass="col-lg-5 col-xs-10">
                        <ItemTemplate>
                            <div id="divAcciones" style="padding-top: 10px;">
                                <b>
                                    <asp:Button runat="server" ID="btnEditarProducto" type="button" class="btn btn-info" Text="Editar" CommandArgument='<%#Eval("idProducto") %>' CommandName="editar" OnClick="btnEditarProducto_Click" /></b>
                                <b>
                                    <asp:Button runat="server" ID="btnEliminarProducto" type="button" class="btn btn-danger" CommandArgument='<%#Eval("idProducto") %>' CommandName="eliminar" Text="Eliminar" OnClientClick="if (!Confirm('¿Desea ELIMINAR éste producto? Esta acción no se puede deshacer')) return false" OnClick="btnEliminarProducto_Click"></asp:Button></b>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>

                </Columns>
            </asp:GridView>
        </div>
    </div>

</asp:Content>

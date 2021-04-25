<%@ Page Title="" Language="C#" MasterPageFile="~/Header.Master" AutoEventWireup="true" CodeBehind="productos.aspx.cs" Inherits="Easy_Stock.productos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <%--     <div class="row">
        <div class="col-xl-12 col-md-12">
            <table class="table">
                <thead class="thead-light">
                    <tr>
                        <th scope="col">Código</th>
                        <th scope="col">Producto</th>
                        <th scope="col">Descripcion</th>
                        <th scope="col">Marca</th>
                        <th scope="col">Precio de venta</th>
                        <th scope="col">Precio costo</th>
                        <th scope="col">Stock mínimo</th>
                        <th scope="col">Stock máximo</th>
                        <th scope="col">Categoria</th>
                        <th scope="col">Proveedor</th>

                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <th scope="row"></th>
                        <td>Mark</td>
                        <td>Otto</td>
                        <td>@mdo</td>
                        <td>@mdo</td>
                        <td>Mark</td>
                        <td>Otto</td>
                        <td>@mdo</td>
                        <td>@mdo</td>
                        <td>@mdo</td>
                        <td>@mdo</td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>--%>
    <div class="table-responsive">
        <div class="col-xl-12 col-md-12">
            <asp:GridView ID="grvProductos" runat="server" Height="277px" Width="897px" CssClass="table table-condensed table-hover">
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
                                <b><%#Eval("categoria.categoria") %></b>
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
                                <b><asp:Button runat="server" ID="btnEditar" type="button" class="btn btn-primary" Text="Editar"></asp:Button></b>
                                <b><asp:Button runat="server" ID="btnEliminar" type="button" class="btn btn-danger" Text="Eliminar" ></asp:Button></b>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>

                </Columns>
            </asp:GridView>
        </div>
    </div>

</asp:Content>

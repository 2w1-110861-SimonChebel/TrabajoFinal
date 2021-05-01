<%@ Page Title="" Language="C#" MasterPageFile="~/Header.Master" AutoEventWireup="true" CodeBehind="depositos.aspx.cs" Inherits="Easy_Stock.depositos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="table-responsive">
        <div class="col-xl-12 col-md-12">

            <div id="divMensaje" class="alert alert-danger" style="display: none" runat="server">
                <h6>El usuario y/o contraseña son incorrectos</h6>
            </div>

            <div class="row">
                <div class="col-md-6 col-xl-6" style="padding: 20px">
                    <asp:TextBox ID="btnBuscar" runat="server"></asp:TextBox>
                </div>
                <div class="col-md-6 col-xl-6" style="padding: 20px">
                    <asp:Button runat="server" ID="btnBuscarProducto" type="button" class="btn btn-dark" Text="Buscar" />
                </div>
            </div>

            <asp:GridView ID="grvProductos" runat="server" Height="277px" Width="897px" CssClass="mydatagrid; header; rows;" OnSelectedIndexChanged="btnEditarProducto_Click" OnRowCommand="grvProductos_RowCommand">
                <Columns>
                    <asp:TemplateField HeaderText="Deposito (sucursal)" HeaderStyle-CssClass="absolute" ItemStyle-CssClass="col-lg-5 col-xs-10">
                        <ItemTemplate>
                            <div id="divDeposito" style="padding-top: 10px;">
                                <b><%#Eval("nombre") %></b>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Ubicación" HeaderStyle-CssClass="absolute" ItemStyle-CssClass="col-lg-5 col-xs-10">
                        <ItemTemplate>
                            <div id="divDireccionDeposito" style="padding-top: 10px;">
                                <b><%#Eval("direccion") %></b>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Localidad" HeaderStyle-CssClass="absolute" ItemStyle-CssClass="col-lg-5 col-xs-10">
                        <ItemTemplate>
                            <div id="divLocalidadDeposito" style="padding-top: 10px;">
                                <b><%#Eval("localidad.localidad") %></b>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Provincia" HeaderStyle-CssClass="absolute" ItemStyle-CssClass="col-lg-5 col-xs-10">
                        <ItemTemplate>
                            <div id="divProvinciaDeposito" style="padding-top: 10px;">
                                <b><%#Eval("provincia.provincia") %></b>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Completo" HeaderStyle-CssClass="absolute" ItemStyle-CssClass="col-lg-5 col-xs-10">
                        <ItemTemplate>
                            <div id="divDepositoCompleto" style="padding-top: 10px;">
                                <b>$<%#Eval("deposito.completo") %></b>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Precio costo" HeaderStyle-CssClass="absolute" ItemStyle-CssClass="col-lg-5 col-xs-10">
                        <ItemTemplate>
                            <div id="divAccionDeposito" style="padding-top: 10px;">
                                <a href="<%string.Format("https://www.google.com/maps/search/?api=1&query={0}", oSucursal.direccion);%>">Ver en mapa</a>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>


                    <asp:TemplateField HeaderText="Acciones" HeaderStyle-CssClass="absolute" ItemStyle-CssClass="col-lg-5 col-xs-10">
                        <ItemTemplate>
                            <div id="divAcciones" style="padding-top: 10px;">
                                <b>
                                    <asp:Button runat="server" ID="btnEditarProducto" type="button" class="btn btn-info" Text="Editar" CommandArgument='<%#Eval("idProducto") %>' CommandName="editar" OnClick="btnEditarProducto_Click" /></b>
                                <b>
                                    <asp:Button runat="server" ID="btnEliminarProducto" type="button" class="btn btn-danger" CommandArgument='<%#Eval("idProducto") %>' CommandName="eliminar" Text="Eliminar" OnClientClick="if (!Confirm('¿Desea ELIMINAR éste producto? Esta acción no se puede deshacer')) return false;" OnClick="btnEliminarProducto_Click"></asp:Button></b>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>

                </Columns>
            </asp:GridView>
        </div>
    </div>

</asp:Content>

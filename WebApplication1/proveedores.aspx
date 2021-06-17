<%@ Page Title="" Language="C#" MasterPageFile="~/Header.Master" AutoEventWireup="true" CodeBehind="proveedores.aspx.cs" Inherits="Easy_Stock.proveedores" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="table-responsive">
        <div class="col-xl-12 col-md-12">

            <div class="row">

                <div class="col-md-6 col-xl-6" style="padding: 20px">
                    <asp:TextBox ID="txtBuscarProveedor" CssClass="form-control" PlaceHolder="Buscar proveedores" runat="server"></asp:TextBox>
                </div>
                <div class="col-md-6 col-xl-6" style="padding: 20px">
                    <asp:Button runat="server" ID="btnBuscarProveedores" type="button" class="btn btn-dark" Text="Buscar" OnClick="btnBuscarProveedores_Click" />
                </div>
            </div>

            <div id="divMensaje" class="alert alert-danger" style="padding: 20px" runat="server">
                <h6 id="hMensaje" runat="server"></h6>
            </div>


            <asp:GridView ID="grvProveedores" runat="server" Height="277px" Width="90%" CssClass="gridView gridViewHeader" OnRowCommand="grvProveedores_RowCommand" AllowPaging="True" AutoGenerateColumns="False">
                <Columns>
                    <asp:TemplateField HeaderText="Nombre" HeaderStyle-CssClass="absolute" Visible="true" ItemStyle-CssClass="col-lg-5 col-xs-10">
                        <ItemTemplate>
                            <div id="divNombre" style="padding-top: 10px;">
                                <b><%#Eval("nombre")%></b>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Email" HeaderStyle-CssClass="absolute" ItemStyle-CssClass="col-lg-5 col-xs-10">
                        <ItemTemplate>
                            <div id="divEmail" style="padding-top: 10px;">
                                <b><%#Eval("email") %></b>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Teléfono" HeaderStyle-CssClass="absolute" ItemStyle-CssClass="col-lg-5 col-xs-10">
                        <ItemTemplate>
                            <div id="divTelefono" style="padding-top: 10px;">
                                <b><%#Eval("telefono") %></b>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Dirección" HeaderStyle-CssClass="absolute" ItemStyle-CssClass="col-lg-5 col-xs-10">
                        <ItemTemplate>
                            <div id="divDireccion" style="padding-top: 10px;">
                                <b><%#Eval("direccion") %></b>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>


                    <asp:TemplateField HeaderText="Barrio" HeaderStyle-CssClass="absolute" ItemStyle-CssClass="col-lg-5 col-xs-10">
                        <ItemTemplate>
                            <div id="divBarrio" style="padding-top: 10px;">
                                <b><%#Eval("barrio") %></b>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Localidad" HeaderStyle-CssClass="absolute" ItemStyle-CssClass="col-lg-5 col-xs-10">
                        <ItemTemplate>
                            <div id="divLocalidad" style="padding-top: 10px;">
                                <b><%#Eval("localidad.localidad") %></b>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Provincia" HeaderStyle-CssClass="absolute" ItemStyle-CssClass="col-lg-5 col-xs-10">
                        <ItemTemplate>
                            <div id="divProvincia" style="padding-top: 10px;">
                                <b><%#Eval("provincia.provincia") %></b>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Codigo Postal" HeaderStyle-CssClass="absolute" ItemStyle-CssClass="col-lg-5 col-xs-10">
                        <ItemTemplate>
                            <div id="divCodigoPostal" style="padding-top: 10px;">
                                <b><%#Eval("codigoPostal") %></b>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Mapa" HeaderStyle-CssClass="absolute" ItemStyle-CssClass="col-lg-5 col-xs-10">
                        <ItemTemplate>
                            <div id="divMapa" style="padding-top: 10px;">
                                 <a href="<%# string.Format("https://www.google.com/maps/search/?api=1&query={0}", Eval("direccion"))%>" target="_blank">Ver en mapa</a>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Acciones" HeaderStyle-CssClass="absolute" ItemStyle-CssClass="col-lg-5 col-xs-10">
                        <ItemTemplate>
                            <div id="divAcciones" style="padding-top: 10px;">
                                <b>
                                    <asp:Button runat="server" ID="btnEditarProveedor" type="button" class="btn btn-info" CommandArgument='<%#Eval("idProveedor")%>'  CommandName="editar" Text="Editar" /></b>
                                <b>
                                    <asp:Button runat="server" ID="btnEliminarProveedor" type="button" class="btn btn-danger" CommandArgument='<%#Eval("idProveedor") %>' OnClientClick="preguntarEliminarRegistro();" CommandName="eliminar" Text="Eliminar"></asp:Button></b>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>

                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Header.Master" AutoEventWireup="true" CodeBehind="depositos.aspx.cs" Inherits="Easy_Stock.depositos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="table-responsive">
        <div class="col-xl-12 col-md-12">

            <div id="divMensaje" class="alert alert-danger" runat="server">
                <h6 id="hMensaje" runat="server">El usuario y/o contraseña son incorrectos</h6>
            </div>

            <div class="row">

                <div class="col-md-6 col-xl-6" style="padding: 20px">
                    <asp:TextBox ID="txtBuscarDeposito" CssClass="form-control" PlaceHolder="Buscar depositos" runat="server"></asp:TextBox>
                </div>
                <div class="col-md-6 col-xl-6" style="padding: 20px">
                    <asp:Button runat="server" ID="btnBuscarDeposito" type="button" class="btn btn-dark" Text="Buscar" OnClick="btnBuscarDeposito_Click" />
                </div>
            </div>


            <asp:GridView ID="grvDepositos" runat="server" Height="277px" Width="85%" CssClass="gridViewCarrito gridViewCarritoHeader" OnRowCommand="grvDepositos_RowCommand" AllowPaging="True" OnPageIndexChanging="grvDepositos_PageIndexChanging" AutoGenerateColumns="False">
                <Columns>


                    <asp:TemplateField HeaderText="Código" HeaderStyle-CssClass="absolute" Visible="false" ItemStyle-CssClass="col-lg-5 col-xs-10">
                        <ItemTemplate>
                            <div id="divCodigoProducto" style="padding-top: 10px;">
                                <b><%#Eval("idSucursal")%></b>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Deposito (sucursal)" HeaderStyle-CssClass="absolute" ItemStyle-CssClass="col-lg-5 col-xs-10">
                        <ItemTemplate>
                            <div id="divDeposito" style="padding-top: 10px;">
                                <b><%#Eval("nombre") %></b>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Descripción" HeaderStyle-CssClass="absolute" ItemStyle-CssClass="col-lg-5 col-xs-10">
                        <ItemTemplate>
                            <div id="divDescripcionDeposito" style="padding-top: 10px;">
                                <b><%#Eval("deposito.descripcion") %></b>
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
                                <b><%#Convert.ToBoolean(Eval("deposito.completo")) ? "No" : "Si" %></b>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Mapa" HeaderStyle-CssClass="absolute" ItemStyle-CssClass="col-lg-5 col-xs-10">
                        <ItemTemplate>
                            <div id="divAccionDeposito" style="padding-top: 10px;">
                                <a href="<%# string.Format("https://www.google.com/maps/search/?api=1&query={0}", Eval("direccion"))%>" target="_blank">Ver en mapa</a>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>


                    <asp:TemplateField HeaderText="Acciones" HeaderStyle-CssClass="absolute" ItemStyle-CssClass="col-lg-5 col-xs-10" Visible="true">
                        <ItemTemplate>
                            <div id="divAcciones" style="padding-top: 10px;">
                                <b>
                                    <asp:Button runat="server" ID="btnEditarDeposito" type="button" class="btn btn-info" Text="Editar" CommandArgument='<%#Eval("idSucursal")%>' CommandName="editar" /></b>
                                <b>
                                    <asp:Button runat="server" ID="btnEliminarDeposito" type="button" class="btn btn-danger" CommandArgument='<%#Eval("idSucursal") %>' CommandName="eliminar" Text="Eliminar" OnClientClick="preguntarEliminarRegistro();"></asp:Button></b>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>
                     
                </Columns>
            <PagerStyle BackColor="#284775" ForeColor="Black" HorizontalAlign="Left" CssClass="pagination"/>
            </asp:GridView>
        </div>
    </div>

</asp:Content>

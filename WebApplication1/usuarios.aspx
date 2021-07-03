<%@ Page Title="" Language="C#" MasterPageFile="~/Header.Master" AutoEventWireup="true" CodeBehind="usuarios.aspx.cs" Inherits="Easy_Stock.usuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="table-responsive">
        <div class="col-xl-12 col-md-12">

            <div class="row" style="padding-left:5%">

                <div class="col-md-6 col-xl-6" style="padding: 20px">
                    <asp:TextBox ID="txtBuscarUsuario" CssClass="form-control" PlaceHolder="Buscar usuarios" runat="server"></asp:TextBox>
                </div>
                <div class="col-md-6 col-xl-6" style="padding: 20px">
                    <asp:Button runat="server" ID="btnBuscarUsuario" type="button" class="btn btn-dark" Text="Buscar" OnClick="btnBuscarUsuario_Click" />
                </div>
            </div>

            <div id="divMensaje" class="alert alert-danger" style="padding: 20px" runat="server">
                <h6 id="hMensaje" runat="server"></h6>
            </div>


            <asp:GridView ID="grvUsuarios" runat="server" Height="277px" Width="90%" CssClass="gridViewCarritoHeader gridView" OnRowCommand="grvUsuarios_RowCommand" AllowPaging="True" OnPageIndexChanging="grvUsuarios_PageIndexChanging" AutoGenerateColumns="False">
                <Columns>

                    <asp:TemplateField HeaderText="Nombre" HeaderStyle-CssClass="absolute" Visible="false" ItemStyle-CssClass="col-lg-5 col-xs-10">
                        <ItemTemplate>
                            <div id="divNombre" style="padding-top: 10px;">
                                <b><%#Eval("nombre")%></b>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Apellido" HeaderStyle-CssClass="absolute" ItemStyle-CssClass="col-lg-5 col-xs-10">
                        <ItemTemplate>
                            <div id="divApellido" style="padding-top: 10px;">
                                <b><%#Eval("apellido") %></b>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Tipo" HeaderStyle-CssClass="absolute" ItemStyle-CssClass="col-lg-5 col-xs-10">
                        <ItemTemplate>
                            <div id="divDescripcionDeposito" style="padding-top: 10px;">
                                <b><%#Eval("tipoUsuario.tipoUsuario") %></b>
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

                    <asp:TemplateField HeaderText="Clave" HeaderStyle-CssClass="absolute" ItemStyle-CssClass="col-lg-5 col-xs-10">
                        <ItemTemplate>
                            <div id="divClave" style="padding-top: 10px;">
                                <b><%#Eval("clave") %></b>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Acciones" HeaderStyle-CssClass="absolute" ItemStyle-CssClass="col-lg-5 col-xs-10">
                        <ItemTemplate>
                            <div id="divAcciones" style="padding-top: 10px;">
                                <b>
                                    <asp:Button runat="server" ID="btnEditarUsuario" type="button" class="btn btn-info" CommandArgument='<%#Eval("idUsuario")%>' CommandName="editar" Text="Editar" /></b>
                                <b>
                                    <asp:Button runat="server" ID="btnEliminarUsuario" type="button" class="btn btn-danger" CommandArgument='<%#Eval("idUsuario") %>' OnClientClick="preguntarEliminarRegistro();" CommandName="eliminar" Text="Eliminar"></asp:Button></b>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>

                </Columns>
                <PagerStyle BackColor="#284775" ForeColor="Black" HorizontalAlign="Left" CssClass="pagination"/>
            </asp:GridView>
        </div>
    </div>
</asp:Content>

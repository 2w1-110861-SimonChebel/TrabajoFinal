<%@ Page Title="" Language="C#" MasterPageFile="~/Header.Master" AutoEventWireup="true" CodeBehind="clientes.aspx.cs" Inherits="Easy_Stock.clientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:HiddenField ID="hfTipoCliente" runat="server" />
    <div class="container">
        <div class="col-xl-12 col-md-12">

            <div class="row">
                <div class="col-md-6 col-xl-6" style="padding: 20px">
                    <asp:TextBox ID="txtBuscarCliente" CssClass="form-control" PlaceHolder="Buscar clientes" runat="server"></asp:TextBox>
                </div>
                <div class="col-md-6 col-xl-6" style="padding: 20px">
                    <asp:Button runat="server" ID="btnBuscarCliente" CssClass="btn btn-dark" type="button" Text="Buscar" OnClick="BtnBuscarCliente_Click" />
                </div>
            </div>


            <div id="divMensaje" class="alert alert-warning" style="padding-top: 20px" visible="false" runat="server">
                <h6 id="hMensaje" runat="server">No se econtraron resultados</h6>
            </div>

            <div class="col-xs-12 col-md-10 col-xl-10 table table-responsive">

                <asp:GridView ID="grvClientes" runat="server" Height="277px" Width="95%" CssClass="gridViewHeader gridView" OnSelectedIndexChanged="BtnEditarCliente_Click" OnRowCommand="grvClientes_RowCommand" AutoGenerateColumns="False">
                    <Columns>

                        <asp:TemplateField HeaderText="Nombre o razón social" HeaderStyle-CssClass="absolute" ItemStyle-CssClass="col-lg-5 col-xs-10">
                            <ItemTemplate>
                                <div id="divNombreCliente" style="padding-top: 10px;">
                                    <b><%#(int)Eval("tipoCliente.idTipoCliente")==1 ? Eval("nombre") : Eval("razonSocial") %></b>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Apellido" HeaderStyle-CssClass="absolute" ItemStyle-CssClass="col-lg-5 col-xs-10">
                            <ItemTemplate>
                                <div id="divApellidoCliente" style="padding-top: 10px;">
                                    <b><%# (int)Eval("tipoCliente.idTipoCliente")==1 ? Eval("apellido") : "-" %></b>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Télefono" HeaderStyle-CssClass="absolute" ItemStyle-CssClass="col-lg-5 col-xs-10">
                            <ItemTemplate>
                                <div id="divTelefonoCliente" style="padding-top: 10px;">
                                    <b><%#Eval("telefono")%></b>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>


                        <asp:TemplateField HeaderText="DNI o CUIT" HeaderStyle-CssClass="absolute" ItemStyle-CssClass="col-lg-5 col-xs-10">
                            <ItemTemplate>
                                <div id="divApellidoCliente" style="padding-top: 10px;">
                                    <b><%# (int)Eval("tipoCliente.idTipoCliente")==1 ? Eval("dni") : Eval("cuit") %></b>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Sexo" HeaderStyle-CssClass="absolute" ItemStyle-CssClass="col-lg-5 col-xs-10">
                            <ItemTemplate>
                                <div id="divSexo" style="padding-top: 10px;">
                                    <b><%#(int)Eval("tipoCliente.idTipoCliente")==1 ? Eval("sexo.sexo") : "-" %></b>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Fecha nacimiento" HeaderStyle-CssClass="absolute" ItemStyle-CssClass="col-lg-5 col-xs-10">
                            <ItemTemplate>
                                <div id="divSexo" style="padding-top: 10px;">
                                    <b><%#(int)Eval("tipoCliente.idTipoCliente")==1 ? devolverFechaSinHorario((DateTime) Eval("fechaNacimiento")) : "-" %></b>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Tipo de cliente" HeaderStyle-CssClass="absolute" ItemStyle-CssClass="col-lg-5 col-xs-10">
                            <ItemTemplate>
                                <div id="divTipoCliente" style="padding-top: 10px;">
                                    <b><%#Eval("tipoCliente.tipoCliente") %></b>
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

                        <asp:TemplateField HeaderText="Cod. Postal" HeaderStyle-CssClass="absolute" ItemStyle-CssClass="col-lg-5 col-xs-10">
                            <ItemTemplate>
                                <div id="divCodigoPostal" style="padding-top: 10px;">
                                    <b><%#Eval("codigoPostal") %></b>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Tipo de empresa" HeaderStyle-CssClass="absolute" ItemStyle-CssClass="col-lg-5 col-xs-10">
                            <ItemTemplate>
                                <div id="divTipoEmpresa" style="padding-top: 10px;">
                                    <b><%#(int)Eval("tipoCliente.idTipoCliente")==1? "-": Eval("tipoEmpresa.tipoEmpresa") %></b>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Deuda" HeaderStyle-CssClass="absolute" ItemStyle-CssClass="col-lg-5 col-xs-10">
                            <ItemTemplate>
                                <div id="divDeuda" style="padding-top: 10px;">
                                    <b><%# string.Format("{0}{1}","$",Eval("deuda.monto"))%></b>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Acciones" HeaderStyle-CssClass="absolute" ItemStyle-CssClass="col-lg-5 col-xs-10">
                            <ItemTemplate>
                                <div id="divAcciones" style="padding-top: 10px;">
                                    <b>
                                        <asp:Button runat="server" ID="btnEditarCliente" type="button" class="btn btn-info" Text="Editar" CommandArgument='<%#string.Format("{0}{1}{2}",Eval("idCliente"),",",Eval("tipoCliente.idTipoCliente")) %>' CommandName="editar" OnClick="BtnEditarCliente_Click" /></b>
                                    <b>
                                        <asp:Button runat="server" ID="btnEliminarCliente" type="button" class="btn btn-danger" CommandArgument='<%#Eval("idCliente") %>' CommandName="eliminar" Text="Eliminar" OnClick="BtnEliminarCliente_Click"></asp:Button></b>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>

        </div>
    </div>
</asp:Content>

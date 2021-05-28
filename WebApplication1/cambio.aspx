<%@ Page Title="" Language="C#" MasterPageFile="~/Header.Master" AutoEventWireup="true" CodeBehind="cambio.aspx.cs" Inherits="Easy_Stock.cambio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row" style="padding: 20px" id="divMensaje" runat="server">
        <h5 id="hMensaje" runat="server">Devolución de productos</h5>
    </div>

    <div class="col-12">
        <div class="row col-12">
            <div class="form-group col-4">
                <label for="txtNroCompra" class="control-label">Por N° de venta</label>
                <asp:TextBox type="number" class="form-control" ID="txtNroVenta" PlaceHolder="N° de venta" name="txtNroVenta" runat="server" MaxLength="50"> </asp:TextBox>
            </div>
            <div class="form-group col-4">
                <label for="txtCliente" class="control-label">Por cliente</label>
                <asp:TextBox type="text" class="form-control" ID="txtCliente" PlaceHolder="Nombre o razón social" name="txtCliente" runat="server" MaxLength="50"> </asp:TextBox>
            </div>


            <div class="form-group col-4">
                <label for="cboUsuario" class="control-label">Usuario</label>
                <asp:DropDownList class="form-control" ID="cboUsuario" name="cboUsuario" runat="server">
                    <asp:ListItem Value="0">- Seleccione -</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <div class="row col-12">
            <div class="form-group col-4">
                <label for="dtpFecha" class="control-label">Por fecha</label>
                <asp:TextBox type="date" class="form-control" ID="dtpFecha" name="dtpFecha" runat="server"></asp:TextBox>
            </div>

        </div>
        <div class="row">
            <div class="form-group col-6" style="padding-left: 3%">
                <asp:Button ID="btnBuscar" Text="Buscar" type="button" class="btn btn-dark" runat="server" OnClick="btnBuscar_Click" />
            </div>
        </div>

    </div>

    <div class="row" style="padding: 20px" id="divMensajeResult" runat="server">
        <h5 id="hResult" runat="server"></h5>
    </div>


    <div class="col-xs-12 col-md-10 col-xl-10 table table-responsive">

        <asp:GridView ID="grvVentas" runat="server" Height="150px" Width="95%" CssClass="gridViewHeader gridView" OnSelectedIndexChanged="chkSeleccion_CheckedChanged" OnRowCommand="grvVentas_RowCommand" AutoGenerateColumns="False">
            <Columns>

                <asp:TemplateField HeaderText="N° de venta" HeaderStyle-CssClass="absolute" ItemStyle-CssClass="col-lg-5 col-xs-10">
                    <ItemTemplate>
                        <div id="divIdTransaccion" style="padding-top: 10px;">
                            <b><%#Eval("idTransaccion")%></b>
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Fecha y hora" HeaderStyle-CssClass="absolute" ItemStyle-CssClass="col-lg-5 col-xs-10">
                    <ItemTemplate>
                        <div id="divFecha" style="padding-top: 10px;">
                            <b><%#Eval("fecha")%></b>
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Descripción" HeaderStyle-CssClass="absolute" ItemStyle-CssClass="col-lg-5 col-xs-10">
                    <ItemTemplate>
                        <div id="divDescripcion" style="padding-top: 10px;">
                            <b><%#Eval("descripcion")%></b>
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Cliente" HeaderStyle-CssClass="absolute" ItemStyle-CssClass="col-lg-5 col-xs-10">
                    <ItemTemplate>
                        <div id="divNombreCliente" style="padding-top: 10px;">
                            <b><%#(int)Eval("cliente.tipoCliente.idTipoCliente")==(int) Tipo.tipoCliente.persona? string.Format("{0} {1}", Eval("cliente.nombre"),Eval("cliente.apellido")) : Eval("cliente.razonSocial") %></b>
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="N° Factura" HeaderStyle-CssClass="absolute" ItemStyle-CssClass="col-lg-5 col-xs-10">
                    <ItemTemplate>
                        <div id="divNroFactura" style="padding-top: 10px;">
                            <b><%#Eval("factura.nroFactura") %></b>
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Total" HeaderStyle-CssClass="absolute" ItemStyle-CssClass="col-lg-5 col-xs-10">
                    <ItemTemplate>
                        <div id="divTotalFactura" style="padding-top: 10px;">
                            <b><%#string.Format("{0}{1}","$", Eval("factura.total")) %></b>
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Operador" HeaderStyle-CssClass="absolute" ItemStyle-CssClass="col-lg-5 col-xs-10">
                    <ItemTemplate>
                        <div id="divOperador" style="padding-top: 10px;">
                            <b><%#String.Format("{0} {1}" ,Eval("usuario.nombre"),Eval("usuario.apellido"))%></b>
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="" HeaderStyle-CssClass="absolute" ItemStyle-CssClass="col-lg-5 col-xs-10">
                    <ItemTemplate>
                        <div id="divAcciones" style="padding-top: 10px;">
                            <b>
                                <asp:Button runat="server" ID="btnElegirVenta" type="button" class="btn btn-info" Text="Elegir" CommandArgument='<%#string.Format("{0}{1}{2}",Eval("idTransaccion"),",",Eval("cliente.idCliente"))%>' CommandName="editar" OnClick="btnElegirVenta_Click" /></b>
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>


</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Header.Master" AutoEventWireup="true" CodeBehind="pago_carrito.aspx.cs" Inherits="Easy_Stock.pago_carrito" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="divMensaje" class="alert alert-warning" style="padding-top: 20px" visible="false" runat="server">
        <h6 id="hMensaje" runat="server"></h6>
    </div>

    <div class="col-10">
        <div class="row" id="divCliente" runat="server">
            <h6 id="hNombreCliente" style="padding-right: 10px" runat="server"></h6>
            <h6 id="hNombreUsuario" style="padding-right: 10px" runat="server"></h6>
        </div>
    </div>
    <div class="row col-12">
        <div class="form-group col-4" style="padding: 10px; padding-bottom: 2px">
            <h5>Cliente</h5>
        </div>

        <div class="form-group col-4" style="padding: 10px; padding-bottom: 2px">
            <h5>Productos</h5>
        </div>

        <div class="form-group col-4" style="padding: 10px; padding-bottom: 2px">
            <h5>Forma de pago</h5>
        </div>
    </div>

    <div class="row col-12">

        <div id="divDatosCliente" class="form-group col-xl-3 col-md-3 col-xs-12" runat="server">
            <div class="form-group">
                <label for="txtCliente" class="control-label">Cliente</label>
                <asp:TextBox type="text" ReadOnly="true" class="form-control" ID="txtCliente" name="txtCliente" runat="server" MaxLength="70"> </asp:TextBox>
            </div>

            <div class="form-group">
                <label for="txtDniCLiente" class="control-label">Documento, CUIT O CUIL</label>
                <asp:TextBox type="text" ReadOnly="true" class="form-control" ID="txtDniCLiente" name="txtDniCLiente" runat="server" MaxLength="70"> </asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtDireccion" class="control-label">Dirección</label>
                <asp:TextBox type="text" ReadOnly="true" class="form-control" ID="txtDireccion" name="txtDireccion" runat="server" MaxLength="70"> </asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtBarrio" class="control-label">Barrio</label>
                <asp:TextBox type="text" ReadOnly="true" class="form-control" ID="txtBarrio" name="txtBarrio" runat="server" MaxLength="70"> </asp:TextBox>
            </div>

            <div class="form-group">
                <label for="txtLocalidad" class="control-label">Localidad</label>
                <asp:TextBox type="text" ReadOnly="true" class="form-control" ID="txtLocalidad" name="txtLocalidad" runat="server" MaxLength="70"> </asp:TextBox>
            </div>

            <div class="form-group">
                <label for="txtProvincia" class="control-label">Provincia</label>
                <asp:TextBox type="text" ReadOnly="true" class="form-control" ID="txtProvincia" name="txtProvincia" runat="server" MaxLength="70"> </asp:TextBox>
            </div>
        </div>


        <div id="divProductos" class="form-group col-xl-5 col-md-5 col-xs-12" runat="server">
            <div class="form-group">
                <div id="accordion">
                    <div class="card">
                        <div class="card-header" id="headingOne">
                            <div class="row">
                                <div class="col-6">

                                    <h5 class="mb-0"></h5>
                                </div>
                            </div>
                        </div>

                        <asp:GridView ID="grvProductos" runat="server" Height="150px" Width="90%" CssClass="gridViewCarritoHeader gridViewCarrito" OnSelectedIndexChanged="grvProductos_SelectedIndexChanged" OnRowCommand="grvProductos_RowCommand" AutoGenerateColumns="False">
                            <Columns>
                                <asp:TemplateField HeaderText="Código" HeaderStyle-CssClass="absolute" ItemStyle-CssClass="col-lg-5 col-xs-10">
                                    <ItemTemplate>
                                        <div id="divCodCarrito" style="padding-top: 10px;">
                                            <b><%#Eval("codigo") %></b>
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Producto" HeaderStyle-CssClass="absolute" ItemStyle-CssClass="col-lg-5 col-xs-10">
                                    <ItemTemplate>
                                        <div id="divNombreCarrito" style="padding-top: 10px;">
                                            <b><%#Eval("nombre") %></b>
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Precio venta" HeaderStyle-CssClass="absolute" ItemStyle-CssClass="col-lg-5 col-xs-10">
                                    <ItemTemplate>
                                        <div id="divPrecioCarrito" style="padding-top: 10px;">
                                            <b><%#string.Format("{0}{1}", "$",Eval("precioVenta"))%></b>
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Cantidad" HeaderStyle-CssClass="absolute" ItemStyle-CssClass="col-lg-5 col-xs-10">
                                    <ItemTemplate>
                                        <div id="divCodCarrito" style="padding-top: 10px;">
                                            <b><%#Eval("cantidad") %></b>
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Subtotal" HeaderStyle-CssClass="absolute" ItemStyle-CssClass="col-lg-5 col-xs-10">
                                    <ItemTemplate>
                                        <div id="divCodCarrito" style="padding-top: 10px;">
                                            <b><%#string.Format("{0}{1}", "$", float.Parse(Eval("precioVenta").ToString())* float.Parse(Eval("cantidad").ToString())) %></b>
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>

                            </Columns>

                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>

        <div id="divFormaPago" runat="server" class="form-group col-xl-4 col-md-4 col-xs-12">

            <div class="form-group">
                <label for="txtTipoTran" class="control-label">Acción</label>
                <asp:TextBox type="text" ReadOnly="true" class="form-control" ID="txtTipoTran" name="txtTipoTran" runat="server" MaxLength="70"> </asp:TextBox>
            </div>

            <div class="form-group">
                <label for="cboFormaPago" class="control-label">Forma de pago</label>
                <asp:DropDownList class="form-control" ID="cboFormaPago" name="cboFormaPago" runat="server" AutoPostBack="true" OnSelectedIndexChanged="cboFormaPago_SelectedIndexChanged">
                    <asp:ListItem Value="0">- Seleccione -</asp:ListItem>
                </asp:DropDownList>
            </div>

            <div class="form-group">
                <label for="cboTipoFactura" class="control-label">Tipo de factura</label>
                <asp:DropDownList class="form-control" ID="cboTipoFactura" name="cboTipoFactura" runat="server">
                    <asp:ListItem Value="0">- Seleccione -</asp:ListItem>
                </asp:DropDownList>
            </div>

            <h6 id="hTotalSinRecargo" runat="server">Total sin recargo: $0,0</h6>
            <h6 id="hRecargo" runat="server">Recargo: $0,0</h6>
            <h6 id="hIva" runat="server"> IVA: 21%</h6>
            <h4 id="hTotal" runat="server"></h4>
            <div class="row" style="padding: 5px">
                <div style="padding: 5px">
                    <asp:Button ID="btnConfirmar" Text="Confirmar" type="button" class="btn btn-primary btn-lg" runat="server" OnClick="btnConfirmar_Click" />
                </div>
                <div style="padding: 5px">
                    <asp:Button ID="btnCancelar" Text="Cancelar y volver" type="button" class="btn btn-danger btn-lg" runat="server" OnClick="btnCancelar_Click" />
                </div>
            </div>
            <div>
                <asp:LinkButton ID="btnVolverCarrito" runat="server" OnClick="btnVolverCarrito_Click">Volver al carrito</asp:LinkButton>
            </div>
        </div>
    </div>

</asp:Content>

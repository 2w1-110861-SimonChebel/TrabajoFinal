<%@ Page Title="" Language="C#" MasterPageFile="~/Header.Master" AutoEventWireup="true" CodeBehind="movimientos.aspx.cs" Inherits="Easy_Stock.movimientos" %>

<%@ Import Namespace="Easy_Stock.Entidades" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="row alert alert-info" id="divTitulo" runat="server">
        <div class="col-12">
            <div class="col-6">
                <h4 id="hTitulo" runat="server">Movimientos</h4>
            </div>
        </div>
    </div>

    <div class="col-12">
        <div class="row col-12">
            <div class="form-group  col-xs-12 col-md-10 col-lg-4">
                <label for="txtNroCompra" class="control-label">Por N° transaccion</label>
                <asp:TextBox type="number" class="form-control" ID="txtNroTran" PlaceHolder="N° de venta" name="txtNroTran" runat="server" MaxLength="50"> </asp:TextBox>
            </div>
            <div class="form-group  col-xs-12 col-md-10 col-lg-4">
                <label for="txtCliente" class="control-label">Por cliente</label>
                <asp:TextBox type="text" class="form-control" ID="txtCliente" PlaceHolder="Nombre o razón social" name="txtCliente" runat="server" MaxLength="50"> </asp:TextBox>
            </div>


            <div class="form-group  col-xs-12 col-md-10 col-lg-4">
                <label for="cboUsuario" class="control-label">Usuario</label>
                <asp:DropDownList class="form-control" ID="cboUsuario" name="cboUsuario" runat="server">
                    <asp:ListItem Value="0">- Seleccione -</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <div class="row col-12">
            <div class="form-group  col-xs-12 col-md-10 col-lg-4">
                <label for="dtpFechaInicio" class="control-label">Por fecha (inicio)</label>
                <asp:TextBox type="date" class="form-control" ID="dtpFechaInicio" name="dtpFechaInicio" runat="server"></asp:TextBox>
            </div>

            <div class="form-group  col-xs-12 col-md-10 col-lg-4">
                <label for="dtpFechaFin" class="control-label">Por fecha (fin)</label>
                <asp:TextBox type="date" class="form-control" ID="dtpFechaFin" name="dtpFechaFin" runat="server"></asp:TextBox>
            </div>
            <div class="form-group  col-xs-12 col-md-10 col-lg-4">
                <label for="cboProveedor" class="control-label">Proveedor</label>
                <asp:DropDownList class="form-control" ID="cboProveedor" name="cboProveedor" runat="server">
                    <asp:ListItem Value="0">- Seleccione -</asp:ListItem>
                </asp:DropDownList>
            </div>

        </div>

        <div class="form-group col-xs-12 col-md-10 col-lg-4">
            <label for="cboTipoTransaccion" class="control-label">Por tipo de movimiento</label>
            <asp:DropDownList class="form-control" ID="cboTipoTransaccion" AutoPostBack="true" name="cboTipoTransaccion" OnSelectedIndexChanged="cboTipoTransaccion_SelectedIndexChanged" runat="server">
                <asp:ListItem Value="0">- Seleccione -</asp:ListItem>
            </asp:DropDownList>
        </div>

    </div>


    <div class="row col-12">
        <div class="form-group col-xs-12" style="padding-left: 3%">
            <asp:Button ID="btnBuscar" Text="Buscar" type="button" class="btn btn-dark" runat="server" OnClick="btnBuscar_Click" />
        </div>
    </div>

    <asp:GridView ID="grvTransacciones" runat="server" Height="277px" Width="95%" CssClass="gridViewHeader gridView table table-responsive" OnSelectedIndexChanged="btnVerDetalle_Click" OnRowCommand="grvTransacciones_RowCommand" AutoGenerateColumns="False">
        <Columns>

            <asp:TemplateField HeaderText="ID Unico" HeaderStyle-CssClass="absolute" ItemStyle-CssClass="col-lg-5 col-xs-10">
                <ItemTemplate>
                    <div id="divIdTransaccion" style="padding-top: 10px;">
                        <b><%#Eval("idTransaccion")%></b>
                    </div>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Fecha" HeaderStyle-CssClass="absolute" ItemStyle-CssClass="col-lg-5 col-xs-10">
                <ItemTemplate>
                    <div id="divFecha" style="padding-top: 10px;">
                        <b><%#Eval("fecha")%></b>
                    </div>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Descripción" HeaderStyle-CssClass="absolute" ItemStyle-CssClass="col-lg-5 col-xs-10">
                <ItemTemplate>
                    <div id="divDescripcion" style="padding-top: 10px;">
                        <b><%#string.IsNullOrEmpty(Eval("descripcion").ToString()) ? "-": Eval("descripcion")%></b>
                    </div>
                </ItemTemplate>
            </asp:TemplateField>


            <asp:TemplateField HeaderText="Cliente" HeaderStyle-CssClass="absolute" ItemStyle-CssClass="col-lg-5 col-xs-10">
                <ItemTemplate>
                    <div id="divCliente" style="padding-top: 10px;">
                        <b><%#(int)Eval("cliente.tipoCliente.idTipoCliente")==(int)Tipo.tipoCliente.persona ? string.Format("{0} {1}",Eval("cliente.nombre"),Eval("cliente.apellido")) : Eval("cliente.razonSocial") %></b>
                    </div>
                </ItemTemplate>
            </asp:TemplateField>

            <%--   <asp:TemplateField HeaderText="Proveedor" HeaderStyle-CssClass="absolute" ItemStyle-CssClass="col-lg-5 col-xs-10">
                        <ItemTemplate>
                            <div id="divProveedor" style="padding-top: 10px;">
                                <b><%#string.IsNullOrEmpty(Eval("proveedor.nombre").ToString()) && Convert.ToInt32(Eval("proveedor.idProveedor").ToString()) > 0  ? Eval("proveedor.nombre") : "-" %></b>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>--%>

            <asp:TemplateField HeaderText="Tipo de movimiento" HeaderStyle-CssClass="absolute" ItemStyle-CssClass="col-lg-5 col-xs-10">
                <ItemTemplate>
                    <div id="divTipo" style="padding-top: 10px;">
                        <b><%#Eval("tipoTransaccion.tipoTransaccion")%></b>
                    </div>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Operador" HeaderStyle-CssClass="absolute" ItemStyle-CssClass="col-lg-5 col-xs-10">
                <ItemTemplate>
                    <div id="divTipoCliente" style="padding-top: 10px;">
                        <b><%#string.Format("{0} {1}", Eval("usuario.nombre"),Eval("usuario.apellido"))%></b>
                    </div>
                </ItemTemplate>
            </asp:TemplateField>


            <asp:TemplateField HeaderText="Acciones" HeaderStyle-CssClass="absolute" ItemStyle-CssClass="col-lg-5 col-xs-10">
                <ItemTemplate>
                    <div id="divAcciones" style="padding-top: 10px;">
                        <b>
                            <asp:Button runat="server" ID="btnVerDetalle" type="button" class="btn btn-info" Text="Ver detalle" CommandArgument='<%#string.Format("{0}{1}{2}",Eval("idTransaccion"),",",Eval("tipoTransaccion.idTipoTransaccion")) %>' CommandName="editar" OnClick="btnVerDetalle_Click" /></b>
                    </div>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    <div class="row" style="padding: 20px" id="divMensajeResult" runat="server">
        <h5 id="hResult" runat="server"></h5>
    </div>


    <div class="row" style="padding: 20px" id="divMensaje" visible="false" runat="server">
        <h5 id="hMensaje" runat="server"></h5>
    </div>


    <script type="text/javascript">
        var coll = document.getElementsByClassName("collapsible");
        var i;

        for (i = 0; i < coll.length; i++) {
            coll[i].addEventListener("click", function () {
                this.classList.toggle("active");
                var content = this.nextElementSibling;
                if (content.style.maxHeight) {
                    content.style.maxHeight = null;
                } else {
                    content.style.maxHeight = content.scrollHeight + "px";
                }
            });
        }

    </script>

</asp:Content>

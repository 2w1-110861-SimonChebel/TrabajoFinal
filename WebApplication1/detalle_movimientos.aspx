<%@ Page Title="" Language="C#" MasterPageFile="~/Header.Master" AutoEventWireup="true" CodeBehind="detalle_movimientos.aspx.cs" Inherits="Easy_Stock.detalle_movimientos" %>

<%@ Import Namespace="Easy_Stock.Entidades" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="divTitulo">
        <h4 id="hTitulo" runat="server" style="margin: 1%">Detalle de movimiento</h4>
    </div>

    <div class="row col-md-12 col-xs-12">
        <div class="col-md-12 col-xs-12">
            <div class="row alert-info" style="padding: 20px">
                <div class="row col-12">
                    <h5>Datos de movimiento</h5>
                </div>
                <div class="col-xs-12 col-md-6 col-xl-6">

                    <div class="row">
                        <h6 id="hTipoMov" runat="server">Tipo de movimiento: </h6>
                    </div>

                    <div class="row">
                        <h6 id="hNroTran" runat="server">N° de transacción: </h6>
                    </div>
                    <div class="row">
                        <h6 id="hFecha" runat="server">Fecha: </h6>
                    </div>
                    <div class="row">
                        <h6 id="hObservaciones" runat="server">Observaciones: </h6>
                    </div>
                    <%if (idTipoTran == (int)Tipo.tipoTransaccion.cambioProductoDeCliente ||
                                    idTipoTran == (int)Tipo.tipoTransaccion.devolucionDeCliente ||
                                     idTipoTran == (int)Tipo.tipoTransaccion.ventaCliente)
                        {
                    %>
                    <div class="row">
                        <h6 id="hCliente" runat="server">Cliente: </h6>
                    </div>
                    <%}
                        else
                        {%>
                    <div class="row">
                        <h6 id="hProveedor" runat="server">Proveedor: </h6>
                    </div>
                    <%} %>
                    <div class="row">
                        <h6 id="hOperador" runat="server">Operador: </h6>
                    </div>

                </div>
                <h6 id="hMensMov" runat="server" visible="false">No se econtraron registros</h6>
            </div>
        </div>


        <%if (idTipoTran > 0 && idTipoTran == (int)Tipo.tipoTransaccion.ventaCliente)
            {%>


        <div class="row col-12" style="padding: 10px">
            <div class="col-12">
                <h4 id="hTituloDetalle">Listado de productos</h4>
            </div>
        </div>

        <div class="col-md-12 col-xs-12" style="padding-top: 20px">
            <table class="table table-striped">
                <thead class="thead-light">
                    <tr>
                        <th scope="col">Producto</th>
                        <th scope="col">Cantidad</th>
                        <th scope="col">Precio unitario</th>
                        <th scope="col">Iva (%)</th>
                        <th scope="col">Sub Total</th>
                    </tr>
                </thead>
                <tbody>
                    <%
                        if (oVenta != null)
                        {
                            foreach (var item in oVenta.factura.detallesFactura)
                            {

                    %>
                    <tr>
                        <th scope="row"><%=item.producto.nombre%></th>
                        <td><%=item.cantidad%></td>
                        <td><%=item.precio %></td>
                        <td>21</td>
                        <td><%=item.subTotal%></td>
                    </tr>
                    <%
                            }
                        }
                        else hMensMov.Visible = true;
                    %>
                </tbody>
            </table>


        </div>

        <div class="row alert alert-primary" style="float: right; padding-left: 1%">
            <div class="col-12">
                <h5 id="hTotalSinIva" runat="server">Total sin IVA: $<%=((oVenta.factura.SumarSubTotalesDetalle()).ToString())%></h5>
                <h5 id="hIva" runat="server">IVA: $<%=(oVenta.factura.CalcularIvaSobreTotal((decimal)0.21).ToString())%></h5>
                <h3 id="hTotal" runat="server">Total: $<%=oVenta.factura.ObtenerTotalConIva().ToString().Replace(".",",")%></h3>
            </div>
        </div>


        <%}
            else
            {
                if (idTipoTran == (int)Tipo.tipoTransaccion.devolucionDeCliente || idTipoTran == (int)Tipo.tipoTransaccion.cambioProductoDeCliente)
                {%>


        <div class="col-md-12 col-xs-12" style="padding-top: 20px">
            <div class="row col-12">
                <h5 id="hProductosRecibidos" runat="server">Productos devueltos </h5>
            </div>
            <table class="table table-striped">
                <thead class="thead-light">
                    <tr>
                        <th scope="col">Codigo Único</th>
                        <th scope="col">Producto</th>
                        <th scope="col">Precio unitario</th>
                    </tr>
                </thead>
                <tbody>
                    <%}
                        if (oCambio != null)
                        {
                            foreach (var item in oCambio.productosRecibidos)
                            {

                    %>
                    <tr>
                        <th scope="row"><%=item.codigoUnico%></th>
                        <td><%=item.nombre%></td>
                        <td><%=string.Format("{0}{1}","$ ", item.precioVenta)%></td>
                    </tr>
                    <%
                            }
                        }
                        else hMensMov.Visible = true;
                    %>
                </tbody>
            </table>

        </div>


        <%if (oCambio != null && oCambio.productosEntregados.Count > 0)
            {%>
        <div class="col-md-12 col-xs-12" style="padding-top: 20px">
            <div class="row col-12">
                <h5 id="hProductosEntregados" runat="server">Productos entregados </h5>
            </div>
            <table class="table table-striped">
                <thead class="thead-light">
                    <tr>
                        <th scope="col">Codigo Único</th>
                        <th scope="col">Producto</th>
                        <th scope="col">Precio unitario</th>
                    </tr>
                </thead>
                <tbody>
                    <%
                        if (oCambio != null)
                        {
                            foreach (var item in oCambio.productosEntregados)
                            {

                    %>
                    <tr>
                        <th scope="row"><%=item.codigoUnico%></th>
                        <td><%=item.nombre%></td>
                        <td><%=string.Format("{0}{1}", "$ ", item.precioVenta)%></td>
                    </tr>
                    <%
                            }
                        }
                        else hMensMov.Visible = true;
                    %>
                </tbody>
            </table>


        </div>

        <%} %>



        <%if (oCompra != null && oCompra.pedido.detallesPedido.Count() > 0)
            {%>
        <div class="col-md-12 col-xs-12" style="padding-top: 20px">
            <div class="row col-12">
                <h5 id="h1" runat="server">Productos  </h5>
            </div>
            <table class="table table-striped">
                <thead class="thead-light">
                    <tr>
                        <th scope="col">ID</th>
                        <th scope="col">Producto</th>
                        <th scope="col">Cantidad</th>
                        <th scope="col">Precio costo</th>
                        <th scope="col">Subtotal</th>
                    </tr>
                </thead>
                <tbody>
                    <%
                        if (oCompra != null)
                        {
                            foreach (var item in oCompra.pedido.detallesPedido)
                            {

                    %>
                    <tr>
                        <th scope="row"><%=item.producto.idProducto%></th>
                        <td><%=item.producto.nombre%></td>
                        <td><%=item.cantidad%></td>
                        <td><%=string.Format("{0}{1}", "$ ", item.precio)%></td>
                        <td><%=string.Format("{0}{1}", "$ ", item.subTotal)%></td>
                    </tr>
                    <%
                            }
                        }
                        else hMensMov.Visible = true;
                    %>
                </tbody>
            </table>

        </div>

        <div class="row alert alert-primary" style="float: right; margin-right: 1%">
            <div class="col-12">
                <h5 id="hTotalPedidoSinInva" runat="server">Total sin IVA: $<%=((oCompra.pedido.SumarSubTotalesDetalle()).ToString())%></h5>
                <h5 id="hIvaPedido" runat="server">IVA: $<%=(oCompra.pedido.CalcularIvaSobreTotal((decimal)0.21).ToString())%></h5>
                <h3 id="hTotalConIvaPedido" runat="server">Total: $<%=oCompra.pedido.ObtenerTotalConIva().ToString().Replace(".",",")%></h3>
            </div>
        </div>

        <%} %>


        <%} %>
    </div>


</asp:Content>

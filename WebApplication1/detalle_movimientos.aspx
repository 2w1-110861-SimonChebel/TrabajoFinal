<%@ Page Title="" Language="C#" MasterPageFile="~/Header.Master" AutoEventWireup="true" CodeBehind="detalle_movimientos.aspx.cs" Inherits="Easy_Stock.detalle_movimientos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="row col-md-12 col-xs-12">
        <div class="col-md-12 col-xs-12">
            <div class="row alert-info" style="padding: 20px">
                <div class="row col-12">
                    <h5>Datos de transacción</h5>
                </div>
                <div class="col-xs-12 col-md-6 col-xl-6">
                    <div class="row">
                        <h6 id="hNroTran" runat="server">N° de transacción: </h6>
                    </div>
                    <div class="row">
                        <h6 id="hFecha" runat="server">Fecha: </h6>
                    </div>
                    <div class="row">
                        <h6 id="hCliente" runat="server">Cliente: </h6>
                    </div>
                    <div class="row">
                        <h6 id="hOperador" runat="server">Operador: </h6>
                    </div>

                </div>
                <h6 id="hMensMov" runat="server" visible="false">No se econtraron registros</h6>
            </div>
        </div>

        <div class="row col-12" style="padding:10px">
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
                        <td><%=item.iva%></td>
                        <td><%=item.subTotal%></td>
                    </tr>
                    <%
                            }
                        }
                        else hMensMov.Visible = true;
                    %>
                </tbody>
            </table>
            <div class="row alert alert-primary" style="float: right; padding-left: 1%">
                <div class="col-12">
                    <h5 id="hTotalSinIva" runat="server">Total sin IVA: $<%=(oVenta.factura.total.ToString().Substring(0,6))%></h5>
                    <h5 id="hIva" runat="server">IVA: $<%=(oVenta.factura.total*Convert.ToDecimal(0.21)).ToString().Substring(0,7)%></h5>
                    <h3 id="hTotal" runat="server">Total: $<%=oVenta.factura.total.ToString().Replace(".",",")%></h3>
                </div>
            </div>

        </div>
    </div>


</asp:Content>

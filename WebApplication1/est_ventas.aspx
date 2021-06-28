<%@ Page Title="" Language="C#" MasterPageFile="~/Estadisticas.Master" AutoEventWireup="true" CodeBehind="est_ventas.aspx.cs" Inherits="Easy_Stock.est_ventas" %>

<%@ Import Namespace="Easy_Stock.Entidades" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">




    <div class="row col-12" style="padding-bottom: 4%">

        <div class="col-12">

            <div class="col-12 alert alert-info" style="padding-left: 10%">
                <h5>Productos más vendidos (Primeros 5)</h5>
            </div>

            <div class="col-12">
                <table id="tblRankingProductos" class="table table-striped" style="padding-left: 3%">
                    <thead class="thead-dark">
                        <tr>
                            <th scope="col">Producto</th>
                            <th scope="col"></th>
                            <th scope="col"></th>
                            <th scope="col"></th>
                            <th scope="col">Total </th>
                        </tr>
                    </thead>
                    <tbody>
                        <%if (oReVentaProd != null && oReVentaProd.totalesProductosxFactura.Count > 0)
                            { %>

                        <%foreach (var item in oReVentaProd.totalesProductosxFactura)
                            { %>
                        <tr>
                            <th scope="row"><%=item.producto.nombre%></th>
                            <th scope="row"></th>
                            <th scope="row"></th>
                            <th scope="row"></th>
                            <th scope="row"><%=string.Format("{0}{1}","$", item.factura.total)%></th>
                        </tr>
                        <%} %>


                        <% } %>
                    </tbody>
                </table>
            </div>
        </div>
    </div>



    <div class="row col-12" style="padding-bottom: 4%">

        <div class="col-12">

            <div class="col-12 alert alert-info" style="padding-left: 10%">
                <h5>Categorias con más ventas (Primeras 5)</h5>
            </div>

            <div class="col-12">
                <table id="tblRankingCategorias" class="col-12 table  table-striped" style="padding-left: 3%">
                    <thead class="thead-dark">
                        <tr>
                            <th scope="col">Categoria</th>
                            <th scope="col"></th>
                            <th scope="col"></th>
                            <th scope="col"></th>
                            <th scope="col">Total </th>
                        </tr>
                    </thead>
                    <tbody>
                        <%if (oReVentaCat != null && oReVentaCat.totalesCategoriasxFactura.Count > 0)
                            { %>

                        <%foreach (var item in oReVentaCat.totalesCategoriasxFactura)
                            { %>
                        <tr>
                            <th scope="row"><%=item.categoria.nombre %></th>
                            <th scope="row"></th>
                            <th scope="row"></th>
                            <th scope="row"></th>
                            <th scope="row"><%=string.Format("{0}{1}","$", item.factura.total)%></th>
                        </tr>
                        <%} %>


                        <% } %>
                    </tbody>
                </table>
            </div>

        </div>


    </div>


    <div class="row col-12">

        <div class="col-12">

            <div class="col-12 alert alert-info">
                <h5>Facturacion por categoria</h5>
            </div>

            <div class="form-group col-12">
                <label for="cboCategorias" class="control-label">Categorias</label>
                <asp:DropDownList class="form-control" ID="cboCategorias" name="cboCategorias" runat="server" AutoPostBack="true" OnSelectedIndexChanged="cboCategorias_SelectedIndexChanged">
                    <asp:ListItem Value="0">- Seleccione -</asp:ListItem>
                </asp:DropDownList>
            </div>

            <div id="divMensajeNoEncontrado" runat="server" class="col-12 alert alert-warning" style="padding-left: 10%">
                <h6>No se encontraron resultados</h6>
            </div>

            <div class="row col-12" runat="server" id="divGrafico" style="display: none">

                <div id="divChart" runat="server" class="col-12">
                    <asp:Chart ID="crtVentasCategoria" runat="server" CssClass="table table-bordered table-condensed table-responsive" Width="380px">
                        <Series>
                            <asp:Series Name="Series" XValueMember="0" YValueMembers="2" IsValueShownAsLabel="true">
                            </asp:Series>
                        </Series>
                        <ChartAreas>
                            <asp:ChartArea Name="ChartArea">
                                <AxisY Title="Total facturado"></AxisY>
                                <AxisX Title="Cateogoria"></AxisX>
                            </asp:ChartArea>
                        </ChartAreas>
                    </asp:Chart>
                </div>

            </div>


        </div>
    </div>

    <div class="dropdown-divider"></div>
    <div class="dropdown-divider"></div>
    <div class="dropdown-divider"></div>

    <div class="col-12 col-xs-12">

        <div class="col-12" style="padding: 20px">
            <h5 class="alert alert-info">Productos con bajo stock</h5>
            <h6 id="h1" runat="server" visible="false">No se econtraron registros</h6>
        </div>
        <% if (lstProductosStock != null && lstProductosStock.Count > 0)
            {%>
        <div style="margin-bottom: 15px">
            <asp:Button runat="server" ID="btnGenerarReporteStock" CssClass="btn btn-secondary" type="button" Text="Generar reporte" OnClick="btnGenerarReporteStock_Click" /></div>
        <table class="table table-striped">
            <thead class="thead-dark">
                <tr>
                    <th scope="col">ID</th>
                    <th scope="col">Producto</th>
                    <th scope="col">Categoria</th>
                    <th scope="col">Cantidad restante</th>
                    <th scope="col">Stock mínimo</th>
                    <th scope="col">Stock máximo</th>

                </tr>
            </thead>
            <tbody>
                <%
                    foreach (var item in lstProductosStock)
                    {
                %>
                <tr>
                    <th scope="row"><%=item.idProducto%></th>
                    <th scope="row"><%=item.nombre%></th>
                    <td><%=item.categoria.nombre%></td>
                    <td><%=item.cantidadRestante %></td>
                    <td><%=item.stockMinimo %></td>
                    <td><%=item.stockMaximo %></td>
                </tr>
                <%
                        }
                    }
                    //else hMensProd.Visible = true;
                %>
            </tbody>
        </table>
    </div>

</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Estadisticas.Master" AutoEventWireup="true" CodeBehind="est_clientes_ranking_ventas.aspx.cs" Inherits="Easy_Stock.est_clientes_ranking_ventas" %>

<%@ Import Namespace="Easy_Stock.Entidades" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div>


        <div class="row col-6 col-xs-12 col-sm-12">
            <h5></h5>
        </div>
        <div class="row col-xs-12 col-sm-12 col-md-6 col-lg-6 col-xl-6">
            <div class="row col-md-6 col-lg-6 col-xl-6 col-xs-12 col-sm-12 alert alert-info" style="padding-left: 10%">
                <h5>Clientes con mayor facturacion historica (10 primeros)</h5>
            </div>


            <table id="tblRankingClientes" class="table table-responsive table-striped" style="padding-left:3%">
                <thead class="thead-light">
                    <tr>
                        <th scope="col">ID cliente</th>
                        <th scope="col">Cliente</th>
                        <th scope="col">Documento / CUIT / CUIL</th>
                        <th scope="col">Total facturado</th>
                        <th scope="col">Cantidad total de compras</th>
                    </tr>
                </thead>
                <tbody>
                    <%if (lstFacturas != null && lstFacturas.Count > 0)
                        { %>

                    <%foreach (var item in lstFacturas)
                        { %>
                    <tr>
                        <th scope="row"><%=item.cliente.idCliente%></th>
                        <th scope="row"><%=item.cliente.tipoCliente.idTipoCliente == (int)Tipo.tipoCliente.persona ? string.Format("{0} {1}",item.cliente.nombre,item.cliente.apellido): item.cliente.razonSocial %></th>
                        <th scope="row"><%=item.cliente.tipoCliente.idTipoCliente == (int)Tipo.tipoCliente.persona ? item.cliente.dni : item.cliente.cuit%></th>
                        <th scope="row"><%=string.Format("{0}{1}","$", item.total)%></th>
                        <th scope="row"><%=item.cantidadFacutasPorCliente%></th>
                    </tr>
                    <%} %>


                    <% } %>
                </tbody>
            </table>

        </div>

    </div>

</asp:Content>

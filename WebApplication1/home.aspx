﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Header.Master" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="Easy_Stock.home" %>

<%@ Import Namespace="Easy_Stock.Entidades" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
    </div>
    <div class="row" style="padding: 20px" id="divMensaje" runat="server">
        <h6 id="hMensaje" runat="server" visible="true"></h6>
    </div>
    <div class="row col-md-12 col-xs-12">
        <div class="col-md-6 col-xs-12">
            <div class="row" style="padding: 20px">
                <h5>Utlimos 5 movimientos</h5>
                <h6 id="hMensMov" runat="server" visible="false">No se econtraron registros</h6>
            </div>
            <table class="table table-striped table-info">
                <thead class="thead-light">
                    <tr>
                        <th scope="col">Fecha</th>
                        <th scope="col">Cliente</th>
                        <th scope="col">Tipo</th>
                        <th scope="col">Operador</th>
                    </tr>
                </thead>
                <tbody>
                    <%
                        if (lstTransacciones != null && lstTransacciones.Count > 0)
                        {
                            foreach (var item in lstTransacciones)
                            {
                                string ape = item.cliente.tipoCliente.idTipoCliente.Equals(1) ? item.cliente.apellido : string.Empty;
                                string nombre = item.cliente.tipoCliente.idTipoCliente.Equals(1) ? item.cliente.nombre : item.cliente.razonSocial;
                    %>
                    <tr>
                        <th scope="row"><%=item.fecha%></th>
                        <td><%=(string.Format("{0} {1}", nombre, ape))%></td>
                        <td><%=item.tipoTransaccion.tipoTransaccion %></td>
                        <td><%=string.Format("{0} {1}",item.usuario.nombre,item.usuario.apellido)%></td>
                    </tr>
                    <%
                            }
                        }
                        else hMensMov.Visible = true;
                    %>
                </tbody>
            </table>
        </div>

        <div class="col-md-6 col-xs-12">

             <div class="row" style="padding: 20px">
                <h5>Productos próximos a vencer</h5>
                <h6 id="hMensProd" runat="server" visible="false">No se econtraron registros</h6>
            </div>
            <% if (lstProductos != null && lstProductos.Count > 0)
            {%>
            <table class="table table-striped table-warning">
                <thead class="thead-light">
                    <tr>
                        <th scope="col">Producto</th>
                        <th scope="col">Fecha Vencimiento</th>
                        <th scope="col">Fecha Ingreso</th>
                    </tr>
                </thead>
                <tbody>
                    <%
                            foreach (var item in lstProductos)
                            {
                    %>
                    <tr>
                        <th scope="row"><%=item.nombre%></th>
                        <td><%=item.fechaVenc.ToShortDateString()%></td>
                        <td><%=item.fechaIngreso %></td>
                    </tr>
                <%
                            }
                }
                else hMensProd.Visible = true;
               %>
                </tbody>
            </table>
        </div>

    </div>

</asp:Content>

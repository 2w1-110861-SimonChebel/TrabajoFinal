<%@ Page Title="" Language="C#" MasterPageFile="~/Header.Master" AutoEventWireup="true" CodeBehind="productos.aspx.cs" Inherits="Easy_Stock.productos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <%--<div class="row">
        <div class="col-xl-12 col-md-12">
            <table class="table">
                <thead class="thead-light">
                    <tr>
                        <th scope="col">#</th>
                        <th scope="col">Fecha</th>
                        <th scope="col">Descripcion</th>
                        <th scope="col">Cliente</th>
                        <th scope="col">Proveedor</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <th scope="row">1</th>
                        <td>Mark</td>
                        <td>Otto</td>
                        <td>@mdo</td>
                        <td>@mdo</td>
                    </tr>
                    <tr>
                        <th scope="row">2</th>
                        <td>Jacob</td>
                        <td>Thornton</td>
                        <td>@fat</td>
                        <td>@mdo</td>
                    </tr>
                    <tr>
                        <th scope="row">3</th>
                        <td>Larry</td>
                        <td>the Bird</td>
                        <td>@twitter</td>
                        <td>@mdo</td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>--%>
     <asp:GridView ID="grvProductos" class="table" runat="server" Height="277px" Width="897px">
         <Columns>
             <asp:BoundField HeaderText="Codigo" ReadOnly="True" />
             <asp:BoundField HeaderText="Producto" ReadOnly="True" />
             <asp:BoundField HeaderText="Descripción" ReadOnly="True" />
             <asp:BoundField HeaderText="Marca" ReadOnly="True" />
             <asp:BoundField HeaderText="Precio de venta" ReadOnly="True" />
             <asp:BoundField HeaderText="Precio costo" ReadOnly="True" />
             <asp:BoundField HeaderText="Stock mínimo" ReadOnly="True" />
             <asp:BoundField HeaderText="Categoria" ReadOnly="True" />
             <asp:BoundField HeaderText="Proveedor" ReadOnly="True" />
         </Columns>
     </asp:GridView>
</asp:Content>

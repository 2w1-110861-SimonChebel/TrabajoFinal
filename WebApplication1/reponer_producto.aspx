<%@ Page Title="" Language="C#" MasterPageFile="~/Header.Master" AutoEventWireup="true" CodeBehind="reponer_producto.aspx.cs" Inherits="Easy_Stock.reponer_producto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="divMensaje" runat="server">
        <h4 id="hMensaje" runat="server"></h4>
    </div>
    <div class="row" style="padding-left:50px">
        <div class="col-md-6 col-xl-6" style="padding: 20px">
            <asp:TextBox ID="txtBuscar" runat="server" class="form-control mr-sm-2" aria-label="Buscar" PlaceHolder="Buscar producto(s) a reponer"></asp:TextBox>
        </div>
        <div class="col-md-6 col-xl-6" style="padding: 20px">
            <asp:Button runat="server" ID="btnBuscarProducto" type="button" class="btn btn-dark" Text="Buscar" OnClick="btnBuscarProducto_Click" />
        </div>
    </div>

    <%--  <asp:GridView ID="grvProductos" runat="server" Height="277px" Width="897px">
                <Columns>
                    <asp:TemplateField HeaderText="Código" HeaderStyle-CssClass="absolute" ItemStyle-CssClass="col-lg-5 col-xs-10">
                        <ItemTemplate>
                            <div id="divCodigoProducto" style="padding-top: 10px;">
                                <b><%#Eval("idProducto") %></b>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>

                        <asp:TemplateField HeaderText="Nombre" HeaderStyle-CssClass="absolute" ItemStyle-CssClass="col-lg-5 col-xs-10">
                        <ItemTemplate>
                            <div id="divNombreProducto" style="padding-top: 10px;">
                                <b><%#Eval("nombre") %></b>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Cantidad restante" HeaderStyle-CssClass="absolute" ItemStyle-CssClass="col-lg-5 col-xs-10">
                        <ItemTemplate>
                            <div id="divCantidadRestante" style="padding-top: 10px;">
                                <b><%#Eval("Cantidad restante") %></b>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Localidad" HeaderStyle-CssClass="absolute" ItemStyle-CssClass="col-lg-5 col-xs-10">
                        <ItemTemplate>
                            <div id="divLocalidadDeposito" style="padding-top: 10px;">
                                <b><%#Eval("Cantidad a reponer") %></b>
                            </div>

                             <div id="divTxtNuevaCantidad" style="padding-top: 10px;">
                                <b>
                                    <asp:TextBox runat="server" ID="txtNuevaCantidad" type="number" class="form-control mr-sm-2"/></b>                          
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>            

                </Columns>
            </asp:GridView>--%>


    <asp:GridView ID="grvProducto" runat="server" Height="170px" Width="90%" CssClass="gridViewHeader gridView" AutoGenerateColumns="False">
        <Columns>
            <asp:TemplateField HeaderText="Código" HeaderStyle-CssClass="absolute" ItemStyle-CssClass="col-lg-5 col-xs-10">
                <ItemTemplate>
                    <div id="divCodigoProducto" style="padding-top: 10px;">
                        <b><%#Eval("codigo")%></b>
                    </div>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Nombre" HeaderStyle-CssClass="absolute" ItemStyle-CssClass="col-lg-5 col-xs-10">
                <ItemTemplate>
                    <div id="divCodigoProducto" style="padding-top: 10px;">
                        <b><%#Eval("nombre")%></b>
                    </div>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Cantidad restante" HeaderStyle-CssClass="absolute" ItemStyle-CssClass="col-lg-5 col-xs-10">
                <ItemTemplate>
                    <div id="divCodigoProducto" style="padding-top: 10px;">
                        <b><%#Eval("cantidadRestante")%></b>
                    </div>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Cantidad a reponer" HeaderStyle-CssClass="absolute" ItemStyle-CssClass="col-lg-5 col-xs-10">
                <ItemTemplate>
                    <div id="divCodigoProducto" style="padding-top: 10px;">
                        <asp:TextBox ID="txtNuevaCantidad" type="number" class="form-control" runat="server"></asp:TextBox>
                    </div>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    <style>
        .gridView {
            margin: 0 auto;
            font-size: 11px;
            text-align: center;
            border: hidden;
        }
            /*Selecciona las filas pares y las colorea*/
            .gridView tr:nth-child(even) {
                background-color: lightblue;
            }
            /*Selecciona las filas impares y las colorea*/
            .gridView tr:nth-child(odd) {
                background-color: #fff;
            }
            /*Estilo para las casillas del gridView*/
            .gridView td {
                padding-left: 3px;
                padding-right: 3px;
                border: hidden;
            }
        /*Color de fondo para la paginación*/
        .gridViewPaginacion td {
            background-color: #435B14;
        }

        /*Bordes redondeados para la paginacion*/

        .gridViewPaginacion > td {
            border-radius: 0px 0px 5px 5px;
        }

        /*Centramos la tabla que contiene los enlaces para las paginas*/

        .gridViewPaginacion table {
            margin: 2px auto;
        }

        /*El span representa el enlace a la pagina en la que estamos actualmente*/

        .gridViewPaginacion span {
            display: block;
            margin: 0;
            padding: 5px;
            width: 18px;
            height: 18px;
            border-radius: 50% 50%;
            background: #B1C689;
            color: #3743a1;
        }

        /*Estilo para los enlaces redondos*/

        .gridViewPaginacion a {
            display: block;
            text-decoration: none;
            margin: 0;
            padding: 5px;
            width: 15px;
            height: 15px;
            border-radius: 50% 50%;
            background: #367DEE;
            color: #fff;
        }

            .gridViewPaginacion a:hover {
                display: block;
                margin: 0;
                padding: 5px;
                width: 18px;
                height: 18px;
                border-radius: 50% 50%;
                background: #B1C689;
                color: #3743a1;
                box-shadow: 0 0 .5em rgba(0, 0, 0, .8);
            }

        .gridViewHeader {
            height: 35px;
        }

            .gridViewHeader th {
                background-color: steelblue;
                padding: 5px;
                border: hidden;
                color: #fff;
            }

                /*Redondeamos el borde superior izquierdo de la primera casilla del header*/

                .gridViewHeader th:first-child {
                    border-radius: 5px 0 0 0;
                }

                /*Y el borde superior derecho de la ultima casilla*/

                .gridViewHeader th:last-child {
                    border-radius: 0 5px 0 0;
                }

                /*Estilo para los enlaces del header...*/

                .gridViewHeader th a {
                    padding: 5px;
                    text-decoration: none;
                    color: #435B14;
                    background-color: #a9c673;
                    border-radius: 5px;
                }

                    .gridViewHeader th a:hover {
                        color: #435B14;
                        background-color: #B1C689;
                        box-shadow: 0 0 .9em rgba(0, 0, 0, .8);
                    }
    </style>

</asp:Content>

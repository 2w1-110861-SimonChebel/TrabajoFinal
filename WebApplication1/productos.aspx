<%@ Page Title="" Language="C#" MasterPageFile="~/Header.Master" AutoEventWireup="true" CodeBehind="productos.aspx.cs" Inherits="Easy_Stock.productos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="col-xl-12 col-md-12">

            <div class="row">
                <div class="col-md-6 col-xl-6" style="padding: 20px">
                    <asp:TextBox ID="txtBuscarProducto" CssClass="form-control" PlaceHolder="Buscar productos" runat="server"></asp:TextBox>
                </div>
                <div class="col-md-6 col-xl-6" style="padding: 20px">
                    <asp:Button runat="server" ID="btnBuscarProducto" CssClass="btn btn-dark" type="button" Text="Buscar" OnClick="btnBuscarProducto_Click" />
                </div>
            </div>


            <div id="divMensaje" class="alert alert-warning" style="display: inherit; padding-top: 20px" runat="server">
                <h6>No se econtraron resultados</h6>
            </div>

            <asp:GridView ID="grvProductos" runat="server" Height="277px" Width="897px" CssClass="gridViewHeader gridView" OnSelectedIndexChanged="btnEditarProducto_Click" OnRowCommand="grvProductos_RowCommand" AutoGenerateColumns="False">
                <Columns>
                    <asp:TemplateField HeaderText="Código" HeaderStyle-CssClass="absolute" ItemStyle-CssClass="col-lg-5 col-xs-10">
                        <ItemTemplate>
                            <div id="divIdProducto" style="padding-top: 10px;">
                                <b><%#Eval("codigo") %></b>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Producto" HeaderStyle-CssClass="absolute" ItemStyle-CssClass="col-lg-5 col-xs-10">
                        <ItemTemplate>
                            <div id="divNombreProducto" style="padding-top: 10px;">
                                <b><%#Eval("nombre") %></b>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Descripción" HeaderStyle-CssClass="absolute" ItemStyle-CssClass="col-lg-5 col-xs-10">
                        <ItemTemplate>
                            <div id="divDescripcion" style="padding-top: 10px;">
                                <b><%#Eval("descripcion") %></b>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Fecha vencimiento" HeaderStyle-CssClass="absolute" ItemStyle-CssClass="col-lg-5 col-xs-10">
                        <ItemTemplate>
                            <div id="divFechaVenc" style="padding-top: 10px;">
                                <b><%#Eval("fechaVenc") %></b>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>

                       <asp:TemplateField HeaderText="Fecha elaboración" HeaderStyle-CssClass="absolute" ItemStyle-CssClass="col-lg-5 col-xs-10">
                        <ItemTemplate>
                            <div id="divFechaVenc" style="padding-top: 10px;">
                                <b><%#Eval("fechaElab") %></b>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Marca" HeaderStyle-CssClass="absolute" ItemStyle-CssClass="col-lg-5 col-xs-10">
                        <ItemTemplate>
                            <div id="divMarca" style="padding-top: 10px;">
                                <b><%#Eval("marca.marca") %></b>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Precio de venta" HeaderStyle-CssClass="absolute" ItemStyle-CssClass="col-lg-5 col-xs-10">
                        <ItemTemplate>
                            <div id="divPrecioVenta" style="padding-top: 10px;">
                                <b>$<%#Eval("precioVenta") %></b>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Precio costo" HeaderStyle-CssClass="absolute" ItemStyle-CssClass="col-lg-5 col-xs-10">
                        <ItemTemplate>
                            <div id="divPrecioCosto" style="padding-top: 10px;">
                                <b>$<%#Eval("precioCosto") %></b>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Stock mínimo" HeaderStyle-CssClass="absolute" ItemStyle-CssClass="col-lg-5 col-xs-10">
                        <ItemTemplate>
                            <div id="divStockMin" style="padding-top: 10px;">
                                <b><%#Eval("stockMinimo") %> u.</b>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Stock máximo" HeaderStyle-CssClass="absolute" ItemStyle-CssClass="col-lg-5 col-xs-10">
                        <ItemTemplate>
                            <div id="divStockMax" style="padding-top: 10px;">
                                <b><%#Eval("stockMaximo") %> u.</b>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Categoria" HeaderStyle-CssClass="absolute" ItemStyle-CssClass="col-lg-5 col-xs-10">
                        <ItemTemplate>
                            <div id="divCategoria" style="padding-top: 10px;">
                                <b><%#Eval("categoria.nombre") %></b>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Cantidad restante" HeaderStyle-CssClass="absolute" ItemStyle-CssClass="col-lg-5 col-xs-10">
                        <ItemTemplate>
                            <div id="divCantidadRestante" style="padding-top: 10px;">
                                <b><%#Eval("cantidadRestante") %></b>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Proveedor" HeaderStyle-CssClass="absolute" ItemStyle-CssClass="col-lg-5 col-xs-10">
                        <ItemTemplate>
                            <div id="divProveedor" style="padding-top: 10px;">
                                <b><%#Eval("proveedor.nombre") %></b>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Acciones" HeaderStyle-CssClass="absolute" ItemStyle-CssClass="col-lg-5 col-xs-10">
                        <ItemTemplate>
                            <div id="divAcciones" style="padding-top: 10px;">
                                <b>
                                    <asp:Button runat="server" ID="btnEditarProducto" type="button" class="btn btn-info" Text="Editar" CommandArgument='<%#Eval("idProducto") %>' CommandName="editar" OnClick="btnEditarProducto_Click" /></b>
                                <b>
                                    <asp:Button runat="server" ID="btnEliminarProducto" type="button" class="btn btn-danger" CommandArgument='<%#Eval("idProducto") %>' CommandName="eliminar" Text="Eliminar" OnClientClick="if (!Confirm('¿Desea ELIMINAR éste producto? Esta acción no se puede deshacer')) return false;" OnClick="btnEliminarProducto_Click"></asp:Button></b>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>

                </Columns>
            </asp:GridView>
        </div>
    </div>


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

    <script type="text/javascript">

</script>

</asp:Content>

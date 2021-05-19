<%@ Page Title="" Language="C#" MasterPageFile="~/Header.Master" AutoEventWireup="true" CodeBehind="productos.aspx.cs" Inherits="Easy_Stock.productos" %>

<%@ Import Namespace="Easy_Stock.Entidades" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:HiddenField ID="hfCodigoQuitar" Value="" runat="server" />
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

            <%if (Session["carrito"] != null)
                { %>
            <div id="accordion">
                <div class="card">
                    <div class="card-header" id="headingOne">
                        <div class="row">
                            <div class="col-6">
                                <h5 class="mb-0">
                                    <button class="btn btn-link" data-toggle="collapse" data-target="#collapseOne" aria-expanded="true" aria-controls="collapseOne">
                                        Carrito
                                    </button>
                                    <asp:LinkButton ID="btnDescartar" Text="Descartar" type="button" class="btn btn-warning" CommandName="descartar" runat="server" OnClick="btnDescartar_Click"></asp:LinkButton>
                                    <asp:LinkButton ID="btnContinuar" Text="Continuar" type="button" class="btn btn-success" runat="server" OnClick="btnContinuar_Click"></asp:LinkButton>

                                </h5>
                            </div>
                        </div>
                    </div>

                    <div class="row" id="divTotal" runat="server" visible="false" style="padding: 5px">
                        <div class="col-12">
                            <h4 id="hTotal" runat="server">Total: $</h4>
                        </div>
                    </div>
                    <asp:GridView ID="grvCarrito" runat="server" Height="150px" Width="80%" CssClass="gridViewCarritoHeader gridViewCarrito" OnSelectedIndexChanged="grvCarrito_SelectedIndexChanged" OnRowCommand="grvCarrito_RowCommand" AutoGenerateColumns="False">
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
                                        <b><%#string.Format("{0}{1}", "$",Eval("precioVenta")) %></b>
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
                                        <b><%# string.Format("{0}{1}", "$", float.Parse(Eval("precioVenta").ToString())* float.Parse(Eval("cantidad").ToString())) %></b>
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Acciones" HeaderStyle-CssClass="absolute" ItemStyle-CssClass="col-lg-5 col-xs-10">
                                <ItemTemplate>
                                    <div id="divAccionesCarrito" style="padding-top: 10px;" runat="server">
                                        <b>
                                            <asp:Button ID="btnQuitarProductoCarrito" Text="Quitar" CssClass="btn btn-danger" runat="server" CommandArgument='<%#Eval("idProducto") %>' CommandName="quitarCarrito" OnClick="btnQuitarProductoCarrito_Click" /></td>
                                        </b>
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <div style="padding: 15px">
                    </div>

                </div>

                <%--         <div id="accordion">
                <div class="card">
                    <div class="card-header" id="headingOne">
                        <div class="row">
                            <div class="col-6">
                                <h5 class="mb-0">
                                    <button class="btn btn-link" data-toggle="collapse" data-target="#collapseOne" aria-expanded="true" aria-controls="collapseOne">
                                        Carrito
                                    </button>
                                    <asp:LinkButton ID="btnDescartar" Text="Descartar" type="button" class="btn btn-warning" runat="server"></asp:LinkButton>
                                    <asp:LinkButton ID="btnContinuar" Text="Continuar" type="button" class="btn btn-success" runat="server"></asp:LinkButton>

                                </h5>
                            </div>

                        </div>

                    </div>
                    <%if (Session["carrito"] != null)
                        { %>
                    <div id="collapseOne" class="collapse show" aria-labelledby="headingOne" data-parent="#accordion">
                        <div class="card-body">

                            <table class="table table-striped" id="tblCarrito">
                                <thead>
                                    <tr>
                                        <th scope="col" id="thCodigo">Código</th>
                                        <th scope="col">Producto</th>
                                        <th scope="col">Precio venta</th>
                                        <th scope="col">Cantidad</th>
                                        <th scope="col">subtotal</th>
                                        <th scope="col"></th>
                                    </tr>
                                </thead>
                                <%
                                    Carrito auxCarrito = Session["carrito"] != null ? (Carrito)Session["carrito"] : null;
                                    if (auxCarrito != null)
                                    {
                                        foreach (var item in auxCarrito.lstProductos)
                                        {
                                %>
                                <tbody>
                                    <tr id="trTabla">
                                        <td id="tdCodigo"><%=item.codigo%></td>
                                        <td><%=item.nombre%></td>
                                        <td><%=string.Format("{0}{1}", "$", item.precioVenta)%></td>
                                        <td><%=item.cantidad%></td>
                                        <td><%=string.Format("{0}{1}", "$", auxCarrito.calculcarSubTotalProducto(item.idProducto))%></td>
                                        <td>
                                            <asp:Button ID="btnQuitarProductoCarrito" Text="Quitar" CssClass="btn btn-danger" runat="server" OnClick="btnQuitarProductoCarrito_Click" /></td>
                                    </tr>

                                </tbody>

                                <%
                                        }
                                    }
                                %>
                                <div class="row">
                                    <div class="col-12">
                                        <h4 id="hTotal" runat="server">Total: $</h4>
                                    </div>
                                </div>
                            </table>

                        </div>
                    </div>
                    <%} %>
                </div>
            </div>--%>
                <%} %>
                <asp:GridView ID="grvProductos" runat="server" Height="277px" Width="897px" CssClass="gridViewHeader gridView" OnSelectedIndexChanged="btnEditarProducto_Click" OnRowCommand="grvProductos_RowCommand" AutoGenerateColumns="False">
                    <Columns>
                        <asp:TemplateField HeaderText="Código" HeaderStyle-CssClass="absolute" ItemStyle-CssClass="col-lg-5 col-xs-10">
                            <ItemTemplate>
                                <div id="divCodigoProducto" style="padding-top: 10px;">
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

                        <asp:TemplateField HeaderText="Fecha de ingreso" HeaderStyle-CssClass="absolute" ItemStyle-CssClass="col-lg-5 col-xs-10">
                            <ItemTemplate>
                                <div id="divFechaIngreso" style="padding-top: 10px;">
                                    <b><%#Eval("fechaIngreso") %></b>
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


                        <asp:TemplateField HeaderText="Acciones" HeaderStyle-CssClass="absolute" ItemStyle-CssClass="col-lg-5 col-xs-10">
                            <ItemTemplate>
                                <div id="divAccionesCarrito" style="padding-top: 10px;" runat="server">
                                    <b>
                                        <asp:LinkButton runat="server" ID="btnAgregarProductoCarrito" type="button" class="btn btn-info" Text="Agregar" CommandArgument='<%#Eval("idProducto")+","+ ((GridViewRow)Container).RowIndex.ToString()%>' CommandName="agregarCarrito" OnClick="btnAgregarProductoCarrito_Click"></asp:LinkButton>
                                    </b>
                                    <b>
                                        <asp:TextBox ID="txtCantidadProducto" runat="server" MaxLength="3" PlaceHolder="Cant." CssClass="form-control" TextMode="Number"></asp:TextBox>
                                    </b>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>


                    </Columns>
                </asp:GridView>

                <%if (!string.IsNullOrEmpty(Request.QueryString["accion"]) && Request.QueryString["accion"].Equals("carrito"))
                    {

                %>
                <%
                    }
                %>
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

            .gridViewCarrito {
                margin: 0 auto;
                font-size: 11px;
                text-align: center;
                border: hidden;
            }
                /*Selecciona las filas pares y las colorea*/
                .gridViewCarrito tr:nth-child(even) {
                    background-color: lightgray;
                }
                /*Selecciona las filas impares y las colorea*/
                .gridViewCarrito tr:nth-child(odd) {
                    background-color: #fff;
                }
                /*Estilo para las casillas del gridView*/
                .gridViewCarrito td {
                    padding-left: 3px;
                    padding-right: 3px;
                    border: hidden;
                }
            /*Color de fondo para la paginación*/
            .gridViewCarritoPaginacion td {
                background-color: #435B14;
            }

            /*Bordes redondeados para la paginacion*/

            .gridViewCarritoPaginacion > td {
                border-radius: 0px 0px 5px 5px;
            }

            /*Centramos la tabla que contiene los enlaces para las paginas*/

            .gridViewCarritoPaginacion table {
                margin: 2px auto;
            }

            /*El span representa el enlace a la pagina en la que estamos actualmente*/

            .gridViewCarritoPaginacion span {
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

            .gridViewCarritoPaginacion a {
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

                .gridViewCarritoPaginacion a:hover {
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

            .gridViewCarritoHeader {
                height: 35px;
            }

                .gridViewCarritoHeader th {
                    background-color: black;
                    padding: 5px;
                    border: hidden;
                    color: #fff;
                }

                    /*Redondeamos el borde superior izquierdo de la primera casilla del header*/

                    .gridViewCarritoHeader th:first-child {
                        border-radius: 5px 0 0 0;
                    }

                    /*Y el borde superior derecho de la ultima casilla*/

                    .gridViewCarritoHeader th:last-child {
                        border-radius: 0 5px 0 0;
                    }

                    /*Estilo para los enlaces del header...*/

                    .gridViewCarritoHeader th a {
                        padding: 5px;
                        text-decoration: none;
                        color: #435B14;
                        background-color: #a9c673;
                        border-radius: 5px;
                    }

                        .gridViewCarritoHeader th a:hover {
                            color: #435B14;
                            background-color: #B1C689;
                            box-shadow: 0 0 .9em rgba(0, 0, 0, .8);
                        }
        </style>

        <script type="text/javascript">
            function obtenerCodigo() {
                var a = document.getElementById("tblCarrito").childNodes[3].innerText;
                for (var i = 0; i < a.lenght; i++) {
                    console.log(a[i]).inn;
                }
                var b = document.getElementById("hfCodigoQuitar");
                console.log(a);
                alert(a);
            }

        </script>
</asp:Content>


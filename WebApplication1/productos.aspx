﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Header.Master" AutoEventWireup="true" CodeBehind="productos.aspx.cs" Inherits="Easy_Stock.productos" %>

<%@ Import Namespace="Easy_Stock.Entidades" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function preguntar() {
            return confirm("¿Descartar y volver al menú principal");
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="divTitulo" class="row col-12 alert alert-info" runat="server">
        <h5 id="hTitulo" runat="server" style="margin: 1%">Categorias</h5>
    </div>

    <div class="col-xl-12 col-md-12" style="margin: 15px">
        <%if (Request.QueryString["accion"] != null && Request.QueryString["accion"].Equals("pedido"))
            { %>

        <div class="row" style="padding-left: 10%">
            <div class="col-md-6 col-xl-6" style="padding: 20px">

                <label for="cboProveedor" class="control-label">Proveedor</label>
                <asp:DropDownList class="form-control" ID="cboProveedor" name="cboProveedor" runat="server" AutoPostBack="false" OnSelectedIndexChanged="cboProveedor_SelectedIndexChanged">
                    <asp:ListItem Value="0">- Seleccione -</asp:ListItem>
                </asp:DropDownList>
            </div>

        </div>
        <%} %>
        <div class="row" style="padding-left: 10%">
            <div class="col-md-6 col-xl-6" style="padding: 20px">
                <asp:TextBox ID="txtBuscarProducto" CssClass="form-control" PlaceHolder="Buscar producto por Id, codigo, o nombre" runat="server"></asp:TextBox>
            </div>
            <div class="col-md-6 col-xl-6" style="padding: 20px">
                <asp:Button runat="server" ID="btnBuscarProducto" CssClass="btn btn-dark" type="button" Text="Buscar" OnClick="btnBuscarProducto_Click" />
                <asp:Button runat="server" ID="btnRecargar" CssClass="btn btn-secondary" type="button" Text="Recargar" OnClick="btnRecargar_Click" ToolTip="Recargar el listado" />
            </div>

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
                    <div class="col-12">
                        <button type="button" class="accordion">Productos</button>
                        <div class="panel" id="divTotal" runat="server" visible="false" style="margin: 5px">
                            <asp:GridView ID="grvCarrito" runat="server" Height="150px" Width="90%" CssClass="gridViewCarritoHeader gridViewCarrito margin2" OnSelectedIndexChanged="grvCarrito_SelectedIndexChanged" OnRowCommand="grvCarrito_RowCommand" AutoGenerateColumns="False">
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

                                    <asp:TemplateField HeaderText="cantRestante" HeaderStyle-CssClass="absolute" ItemStyle-CssClass="col-lg-5 col-xs-10" Visible="false">
                                        <ItemTemplate>
                                            <div id="divCodCarrito" style="padding-top: 10px;">
                                                <b><%#Eval("cantidadRestante") %></b>
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

                            <div class="col-12 margin2">
                                <h4 id="hTotal" runat="server">Total: $<%=Session["carrito"]!= null ? ((Carrito)Session["carrito"]).calcularTotalProductos().ToString() : "0.0" %></h4>
                            </div>
                        </div>

                    </div>
                </div>
            </div>

            <%--  <div class="row" id="divTotal" runat="server" visible="false" style="padding: 5px">
                    <div class="col-12">
                        <h4 id="hTotal" runat="server">Total: $<%=Session["carrito"]!= null ? ((Carrito)Session["carrito"]).calcularTotalProductos().ToString() : "0.0" %></h4>
                    </div>
                </div>--%>
        </div>
        <div class="row col-12" style="margin: 1%">
            <asp:LinkButton ID="btnDescartar" Text="Descartar" type="button" class="btn btn-warning margin1" CommandName="descartar" runat="server" OnClientClick="return preguntar();" OnClick="btnDescartar_Click"></asp:LinkButton>
            <asp:LinkButton ID="btnContinuar" Text="Continuar" type="button" class="btn btn-success" runat="server" OnClientClick="return ValidarProveedor();" OnClick="btnContinuar_Click"></asp:LinkButton>
        </div>
        <br />
        <%} %>
        <asp:GridView ID="grvProductos" runat="server" Height="277px" Width="90%" CssClass="gridViewCarritoHeader gridViewCarrito" OnSelectedIndexChanged="btnEditarProducto_Click" OnRowCommand="grvProductos_RowCommand" AutoGenerateColumns="False" AllowPaging="true" OnPageIndexChanging="grvProductos_PageIndexChanging">
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
                                <asp:Button runat="server" ID="btnEditarProducto" type="button" class="btn btn-info" Text="Editar" CommandArgument='<%#Eval("idProducto")+","+ ((GridViewRow)Container).RowIndex.ToString()%>' CommandName="editar" OnClick="btnEditarProducto_Click" /></b>
                            <b>
                                <asp:Button runat="server" ID="btnEliminarProducto" type="button" class="btn btn-danger" CommandArgument='<%#Eval("idProducto")+","+ ((GridViewRow)Container).RowIndex.ToString()%>' CommandName="eliminar" Text="Eliminar" OnClientClick="preguntarEliminarRegistro();" OnClick="btnEliminarProducto_Click"></asp:Button></b>
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
            <PagerStyle BackColor="#284775" ForeColor="Black" HorizontalAlign="Left" CssClass="pagination" />
        </asp:GridView>
    </div>

    <style>
        .panel {
            padding: 0 18px;
            background-color: white;
            max-height: 0;
            overflow: hidden;
            transition: max-height 0.2s ease-out;
        }

        .accordion {
            background-color: #eee;
            color: #444;
            cursor: pointer;
            padding: 18px;
            width: 100%;
            text-align: left;
            border: none;
            outline: none;
            transition: 0.4s;
        }

            .accordion:after {
                content: '\02795'; /* Unicode character for "plus" sign (+) */
                font-size: 13px;
                color: #777;
                float: right;
                margin-left: 5px;
            }

        .active:after {
            content: "\2796"; /* Unicode character for "minus" sign (-) */
        }

        /* Add a background color to the button if it is clicked on (add the .active class with JS), and when you move the mouse over it (hover) */
        .active, .accordion:hover {
            background-color: #ccc;
        }
    </style>


    <script type="text/javascript">
        var acc = document.getElementsByClassName("accordion");
        var i;

        for (i = 0; i < acc.length; i++) {
            acc[i].addEventListener("click", function () {
                this.classList.toggle("active");
                var panel = this.nextElementSibling;
                if (panel.style.maxHeight) {
                    panel.style.maxHeight = null;
                } else {
                    panel.style.maxHeight = panel.scrollHeight + "px";
                }
            });
        }

        function ValidarProveedor() {
            let prov = document.getElementById('ContentPlaceHolder1_cboProveedor');
            if (prov !== undefined && ValidarProveedor !== null) {
                if (prov.value === "0") { alert("Seleccione el proveedor"); return false; }
                return true;
            }
        }
    </script>


</asp:Content>


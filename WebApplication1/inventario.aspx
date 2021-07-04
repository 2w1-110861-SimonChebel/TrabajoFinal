<%@ Page Title="" Language="C#" MasterPageFile="~/Header.Master" AutoEventWireup="true" CodeBehind="inventario.aspx.cs" Inherits="Easy_Stock.inventario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="divTitulo" class="alert alert-info" style="padding-top: 20px" visible="true" runat="server">
        <h5 id="hTitulo" runat="server">Inventario</h5>
    </div>


    <div id="divMensaje" class="alert alert-warning" style="padding-top: 20px" visible="false" runat="server">
        <h6 id="hMensaje" runat="server">No se econtraron resultados</h6>
    </div>

    <div id="accordion">
        <div class="card">
            <div class="card-header" id="headingOne">
                <div class="row">
                    <div class="col-12">

                        <button id="btnAcordion" type="button" class="accordion" runat="server">Buscador</button>
                        <div class="panel" style="margin: 20px">

                            <div class="row col-12">
                                <div class="form-group  col-xs-12 col-md-10 col-lg-4">
                                    <label for="txtCodigoUnico" class="control-label">ID Único</label>
                                    <asp:TextBox type="text" class="form-control" ID="txtCodigoUnico" name="txtCodigoUnico" runat="server" MaxLength="50"> </asp:TextBox>
                                </div>
                                <div class="form-group  col-xs-12 col-md-10 col-lg-4">
                                    <label for="txtCodigo" class="control-label">Código</label>
                                    <asp:TextBox type="text" class="form-control" ID="txtCodigo" name="txtCodigo" runat="server" MaxLength="60"> </asp:TextBox>
                                </div>

                                <div class="form-group  col-xs-12 col-md-10 col-lg-4">
                                    <label for="txtNombre" class="control-label">Nombre</label>
                                    <asp:TextBox type="text" class="form-control" ID="txtNombre" name="txtNombre" runat="server" MaxLength="100"> </asp:TextBox>
                                </div>

                                <div class="form-group  col-xs-12 col-md-10 col-lg-4">
                                    <label for="cboEstado" class="control-label">Estado</label>
                                    <asp:DropDownList class="form-control" ID="cboEstado" name="cboEstado" runat="server">
                                        <asp:ListItem Value="0">- Seleccione -</asp:ListItem>
                                    </asp:DropDownList>
                                </div>

                                <div class="form-group  col-xs-12 col-md-10 col-lg-4">
                                    <label for="dtpFechaInicio" class="control-label">Fecha de ingreso (desde)</label>
                                    <asp:TextBox type="date" class="form-control" ID="dtpFechaInicio" name="dtpFechaInicio" runat="server"></asp:TextBox>
                                </div>

                                <div class="form-group  col-xs-12 col-md-10 col-lg-4">
                                    <label for="dtpFechaFin" class="control-label">Fecha de ingreso (hasta)</label>
                                    <asp:TextBox type="date" class="form-control" ID="dtpFechaFin" name="dtpFechaFin" runat="server"></asp:TextBox>
                                </div>

                                <div class="col-12" style="display:flex;justify-items:right">
                                    <asp:Button runat="server" ID="btnBuscar" type="button" class="btn btn-dark" Text="Buscar" OnClick="btnBuscar_Click"></asp:Button>
                                </div>

                            </div>

                        </div>
                    </div>

                </div>
            </div>
        </div>
    </div>

    <div class="col-12" style="margin: 25px">


        <asp:GridView ID="grvInventario" runat="server" Height="277px" Width="95%" CssClass="gridView gridViewHeader" OnRowCommand="grvInventario_RowCommand" AllowPaging="True" OnPageIndexChanging="grvInventario_PageIndexChanging" AutoGenerateColumns="False">
            <Columns>

                <asp:TemplateField HeaderText="ID único" HeaderStyle-CssClass="absolute" Visible="true" ItemStyle-CssClass="col-lg-5 col-xs-10">
                    <ItemTemplate>
                        <div id="divIdUnico" style="padding-top: 10px;">
                            <b><%#string.Format("{0}-{1}", Eval("idInventario") , Eval("producto.codigo"))%></b>
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Código" HeaderStyle-CssClass="absolute" ItemStyle-CssClass="col-lg-5 col-xs-10">
                    <ItemTemplate>
                        <div id="divCodigo" style="padding-top: 10px;">
                            <b><%#Eval("producto.codigo") %></b>
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Nombre" HeaderStyle-CssClass="absolute" ItemStyle-CssClass="col-lg-5 col-xs-10">
                    <ItemTemplate>
                        <div id="divNombre" style="padding-top: 10px;">
                            <b><%#Eval("producto.nombre") %></b>
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Estado" HeaderStyle-CssClass="absolute" ItemStyle-CssClass="col-lg-5 col-xs-10">
                    <ItemTemplate>
                        <div id="divEstado" style="padding-top: 10px;">
                            <b><%#Eval("estado.estadoProducto") %></b>
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Fecha de ingreso" HeaderStyle-CssClass="absolute" ItemStyle-CssClass="col-lg-5 col-xs-10">
                    <ItemTemplate>
                        <div id="divFechaIngreso" style="padding-top: 10px;">
                            <b><%#Eval("producto.fechaIngreso") %></b>
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>



                <%--            <asp:TemplateField HeaderText="Acciones" HeaderStyle-CssClass="absolute" ItemStyle-CssClass="col-lg-5 col-xs-10" Visible="true">
                <ItemTemplate>
                    <div id="divAcciones" style="padding-top: 10px;">
                        <b>
                            <asp:Button runat="server" ID="btnEditarDeposito" type="button" class="btn btn-info" Text="Editar" CommandArgument='<%#Eval("idSucursal")%>' CommandName="editar" /></b>
                        <b>
                            <asp:Button runat="server" ID="btnEliminarDeposito" type="button" class="btn btn-danger" CommandArgument='<%#Eval("idSucursal") %>' CommandName="eliminar" Text="Eliminar" OnClientClick="preguntarEliminarRegistro();"></asp:Button></b>
                    </div>
                </ItemTemplate>
            </asp:TemplateField>--%>
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
                content: '\02795';
                font-size: 13px;
                color: #777;
                float: right;
                margin-left: 5px;
            }

        .active:after {
            content: "\2796";
        }


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
    </script>

</asp:Content>

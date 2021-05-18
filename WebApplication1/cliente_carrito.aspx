<%@ Page Title="" Language="C#" MasterPageFile="~/Header.Master" AutoEventWireup="true" CodeBehind="cliente_carrito.aspx.cs" Inherits="Easy_Stock.cliente_carrito" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="divTitulo" runat="server" style="padding: 5px">
        <h4 id="hTitulo" runat="server">Elija el cliente</h4>
    </div>
    <div id="divSubtitulo" runat="server" style="padding: 5px">
        <div class="alert alert-info">
            <h6>Ingrese el número de documento, cuil o cuit del cliente. O bien, registre un nuevo cliente</h6>
        </div>
    </div>

    <div class="row" style="padding: 10px; padding-left:35px">
        <div class="col-md-6 col-xl-6" style="padding: 10px">
            <asp:TextBox ID="txtBuscarCliente" CssClass="form-control" PlaceHolder="Documento, Cuil o Cuit" runat="server" MaxLength="40"></asp:TextBox>
        </div>
        <div class="col-md-6 col-xl-6" style="padding: 10px">
            <asp:Button runat="server" ID="btnBuscarCliente" CssClass="btn btn-dark" type="button" Text="Buscar" OnClick="btnBuscarCliente_Click" />
            <asp:Button runat="server" ID="btnAgregarNuevoCliente" CssClass="btn btn-success" type="button" Text="Nuevo" OnClick="btnAgregarNuevoCliente_Click" />
        </div>
    </div>

    <div id="divMensaje" runat="server" style="padding: 5px" visible="false">
        <div class="alert alert-warning">
            <h6 id="hMensaje" runat="server">No se encontraron resultados</h6>
        </div>
    </div>

    <asp:GridView ID="grvClienteCarrito" runat="server" Height="150px" Width="95%" CssClass="gridViewHeader gridView" OnSelectedIndexChanged="grvClienteCarrito_SelectedIndexChanged" OnRowCommand="grvClienteCarrito_RowCommand" AutoGenerateColumns="False">
        <Columns>
            <asp:TemplateField HeaderText="Nombre o razón social" HeaderStyle-CssClass="absolute" ItemStyle-CssClass="col-lg-5 col-xs-10">
                <ItemTemplate>
                    <div id="divNombreCliente" style="padding-top: 10px;">
                        <b><%#(int)Eval("tipoCliente.idTipoCliente")==1 ? Eval("nombre") : Eval("razonSocial") %></b>
                    </div>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Apellido" HeaderStyle-CssClass="absolute" ItemStyle-CssClass="col-lg-5 col-xs-10">
                <ItemTemplate>
                    <div id="divApellidoCliente" style="padding-top: 10px;">
                        <b><%# (int)Eval("tipoCliente.idTipoCliente")==1 ? Eval("apellido") : "-" %></b>
                    </div>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Télefono" HeaderStyle-CssClass="absolute" ItemStyle-CssClass="col-lg-5 col-xs-10">
                <ItemTemplate>
                    <div id="divTelefonoCliente" style="padding-top: 10px;">
                        <b><%#Eval("telefono")%></b>
                    </div>
                </ItemTemplate>
            </asp:TemplateField>


            <asp:TemplateField HeaderText="DNI o CUIT" HeaderStyle-CssClass="absolute" ItemStyle-CssClass="col-lg-5 col-xs-10">
                <ItemTemplate>
                    <div id="divApellidoCliente" style="padding-top: 10px;">
                        <b><%# (int)Eval("tipoCliente.idTipoCliente")==1 ? Eval("dni") : Eval("cuit") %></b>
                    </div>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Sexo" HeaderStyle-CssClass="absolute" ItemStyle-CssClass="col-lg-5 col-xs-10">
                <ItemTemplate>
                    <div id="divSexo" style="padding-top: 10px;">
                        <b><%#(int)Eval("tipoCliente.idTipoCliente")==1 ? Eval("sexo.sexo") : "-" %></b>
                    </div>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Fecha nacimiento" HeaderStyle-CssClass="absolute" ItemStyle-CssClass="col-lg-5 col-xs-10">
                <ItemTemplate>
                    <div id="divSexo" style="padding-top: 10px;">
                        <b><%#(int)Eval("tipoCliente.idTipoCliente")==1 ? devolverFechaSinHorario((DateTime) Eval("fechaNacimiento")) : "-" %></b>
                    </div>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Tipo de cliente" HeaderStyle-CssClass="absolute" ItemStyle-CssClass="col-lg-5 col-xs-10">
                <ItemTemplate>
                    <div id="divTipoCliente" style="padding-top: 10px;">
                        <b><%#Eval("tipoCliente.tipoCliente") %></b>
                    </div>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Dirección" HeaderStyle-CssClass="absolute" ItemStyle-CssClass="col-lg-5 col-xs-10">
                <ItemTemplate>
                    <div id="divDireccion" style="padding-top: 10px;">
                        <b><%#Eval("direccion") %></b>
                    </div>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Barrio" HeaderStyle-CssClass="absolute" ItemStyle-CssClass="col-lg-5 col-xs-10">
                <ItemTemplate>
                    <div id="divBarrio" style="padding-top: 10px;">
                        <b><%#Eval("barrio") %></b>
                    </div>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Localidad" HeaderStyle-CssClass="absolute" ItemStyle-CssClass="col-lg-5 col-xs-10">
                <ItemTemplate>
                    <div id="divLocalidad" style="padding-top: 10px;">
                        <b><%#Eval("localidad.localidad") %></b>
                    </div>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Provincia" HeaderStyle-CssClass="absolute" ItemStyle-CssClass="col-lg-5 col-xs-10">
                <ItemTemplate>
                    <div id="divProvincia" style="padding-top: 10px;">
                        <b><%#Eval("provincia.provincia") %></b>
                    </div>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Cod. Postal" HeaderStyle-CssClass="absolute" ItemStyle-CssClass="col-lg-5 col-xs-10">
                <ItemTemplate>
                    <div id="divCodigoPostal" style="padding-top: 10px;">
                        <b><%#Eval("codigoPostal") %></b>
                    </div>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Tipo de empresa" HeaderStyle-CssClass="absolute" ItemStyle-CssClass="col-lg-5 col-xs-10">
                <ItemTemplate>
                    <div id="divTipoEmpresa" style="padding-top: 10px;">
                        <b><%#(int)Eval("tipoCliente.idTipoCliente")==1? "-": Eval("tipoEmpresa.tipoEmpresa") %></b>
                    </div>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Deuda" HeaderStyle-CssClass="absolute" ItemStyle-CssClass="col-lg-5 col-xs-10">
                <ItemTemplate>
                    <div id="divDeuda" style="padding-top: 10px;">
                        <b><%# string.Format("{0}{1}","$",Eval("deuda.monto"))%></b>
                    </div>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderStyle-CssClass="absolute" ItemStyle-CssClass="col-lg-5 col-xs-10">
            <itemtemplate>
                        <div id="divAccionesCarrito" style="padding-top: 10px;" runat="server">
                            <b>
                                <asp:LinkButton runat="server" ID="btnElegirCliente" type="button" class="btn btn-dark" Text="Elegir" CommandArgument='<%#Eval("idCliente")%>' CommandName="elegirCliente"></asp:LinkButton>
                            </b>
                        </div>
                    </itemtemplate>
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

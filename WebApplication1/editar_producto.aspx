<%@ Page Title="" Language="C#" MasterPageFile="~/Header.Master" AutoEventWireup="true" CodeBehind="editar_producto.aspx.cs" Inherits="Easy_Stock.editar_producto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


        <div class="col-md-6 col-xl-6 ">
            <div id="divMensaje" visible="false" runat="server">
                <h6 id="hMensaje" runat="server"></h6>
            </div>
            <div id="divErrorCargaProducto" class="alert alert-danger" style="display: none" runat="server">
                <h6>Hubo en error en la carga. Verifique los datos y vuelva a intentarlo</h6>
            </div>
            <div id="divTitulo" class="col-md-6 col-xl-6" style="display: flex; justify-items: right" runat="server">
                <h2>Nuevo producto</h2>
            </div>
            <div class="form-group">
                <label for="txtCodigo" class="control-label">Codigo</label>
                <asp:TextBox type="text" class="form-control" ID="txtCodigo" name="txtCodigo" runat="server" MaxLength="50"> </asp:TextBox>
            </div>

            <div class="form-group">
                <label for="nombre" class="control-label">Nombre</label>
                <asp:TextBox type="text" class="form-control" ID="txtNombreProducto" name="txtNombreProducto" runat="server"> </asp:TextBox>
            </div>
            <div class="form-group">
                <label for="nombre" class="control-label">Cantidad</label>
                <asp:TextBox type="number" class="form-control" ID="txtCantidad" name="txtCantidad" runat="server"> </asp:TextBox>
            </div>

            <%if (!string.IsNullOrEmpty(Request.QueryString["accion"]))
              { %>
            <div class="form-group">
                <label for="dtpFechaIngreso" class="control-label">Fecha de ingreso</label>
                <asp:TextBox type="date" class="form-control" ID="dtpFechaIngreso" name="dtpFechaIngreso" runat="server"></asp:TextBox>
            </div>
            <%} %>

            <div class="form-group">
                <label for="fechaElab" class="control-label">Fecha Elaboración</label>
                <asp:TextBox type="date" class="form-control" ID="dtpFechaElab" name="dtpFechaElab" runat="server"></asp:TextBox>
            </div>


            <div class="form-group">
                <label for="fechaVenc" class="control-label">Fecha vencimiento</label>
                <asp:TextBox type="date" class="form-control" ID="dtpFechaVenc" name="dtpFechaVenc" runat="server"></asp:TextBox>
            </div>

            <div class="form-group">
                <label for="street1_id" class="control-label">Marca</label>
                <asp:DropDownList class="form-control" ID="cboMarcas" name="cboMarca" runat="server">
                    <asp:ListItem Value="0">- Seleccione -</asp:ListItem>
                </asp:DropDownList>
            </div>

            <div class="form-group">
                <label for="precioVenta" class="control-label">Precio de venta</label>
                <asp:TextBox type="number" class="form-control" ID="txtPrecioVenta" PlaceHolder="$" name="txtPrecioVenta" step="any" runat="server"> </asp:TextBox>

            </div>

            <div class="form-group">
                <label for="precioCosto" class="control-label">Precio de Costo</label>
                <asp:TextBox type="number" class="form-control" ID="txtPrecioCosto" PlaceHolder="$" name="txtprecioCosto" step="any" runat="server"> </asp:TextBox>
            </div>
            <div class="form-group">
                <label for="categoria" class="control-label">Categoria</label>
                <asp:DropDownList class="form-control" ID="cboCategorias" name="cboCategoria" runat="server">
                    <asp:ListItem Value="0">- Seleccione -</asp:ListItem>
                </asp:DropDownList>
            </div>

            <div class="form-group">
                <label for="Proveedor" class="control-label">Proveedor</label>
                <asp:DropDownList class="form-control" ID="cboProveedores" name="cboProveedor" runat="server">
                    <asp:ListItem Value="0">- Seleccione -</asp:ListItem>
                </asp:DropDownList>
            </div>


            <div class="form-group">
                <label for="deposito" class="control-label">Deposito (opcional)</label>
                <asp:DropDownList class="form-control" ID="cboDepositos" name="cboDeposito" runat="server">
                    <asp:ListItem Value="0">- Seleccione -</asp:ListItem>
                </asp:DropDownList>
            </div>

            <div class="form-group">
                <label for="StockMinimo" class="control-label">Stock mínimo</label>
                <asp:TextBox type="number" class="form-control" ID="txtStockMinimo" name="txtStockMinimo" runat="server"></asp:TextBox>
            </div>

            <div class="form-group">
                <label for="stockMaximo" class="control-label">Stock máximo</label>
                <asp:TextBox type="number" class="form-control" ID="txtStockMaximo" name="txtStockMaximo" runat="server"></asp:TextBox>
            </div>

            <div class="form-group">
                <label for="descripcion" class="control-label">Descripción (opcional)</label>
                <asp:TextBox type="text" class="form-control" ID="txtDescripcion" name="txtprecioCosto" MaxLength="150" runat="server" TextMode="MultiLine"></asp:TextBox>
            </div>


            <div class="form-group" style="display: flex; justify-content: center">
                <asp:Button ID="btnAgregarProducto" Text="Agregar producto" type="button" class="btn btn-primary" runat="server" OnClientClick="return preguntarGuardar();" OnClick="btnAgregarProducto_Click" />
            </div>

            <div class="form-group" style="display: flex; justify-content: center">
                <asp:Button Text="Limpiar campos" type="button" class="btn btn-secondary" runat="server" />
            </div>

        </div>



    <style>
    
    </style>



</asp:Content>

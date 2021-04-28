<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="editar_producto.aspx.cs" Inherits="Easy_Stock.editar_producto" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">
    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js" integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q" crossorigin="anonymous"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl" crossorigin="anonymous"></script>
    <link href="Bootstrap/css/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="Bootstrap/css/bootstrap.grid.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="frmEditarProducto" runat="server">

        <div class="col-md-6 col-xl-6 ">
            <div class="col-md-6 col-xl-6" style="display: flex; justify-items: right">
                <h2>Nuevo producto</h2>
            </div>
            <div class="form-group">
                <label for="nombre" class="control-label">Nombre</label>
                <asp:TextBox type="text" class="form-control" ID="txtNombreProducto" name="txtNombreProducto" runat="server"> </asp:TextBox>
            </div>
             <div class="form-group">
                <label for="nombre" class="control-label">Cantidad</label>
                <asp:TextBox type="number" class="form-control" ID="txtCantidad" name="txtCantidad" runat="server"> </asp:TextBox>
            </div>

            <div class="form-group">
                <label for="street1_id" class="control-label">Marca</label>
                <asp:DropDownList class="form-control" ID="cboMarcas" name="cboMarca" runat="server">
                    <asp:ListItem Value="0">- Seleccione -</asp:ListItem>
                </asp:DropDownList>
            </div>

            <div class="form-group">
                <label for="precioVenta" class="control-label">Precio de venta</label>
                <asp:TextBox type="number" class="form-control" ID="txtPrecioVenta" PlaceHolder="$" name="txtPrecioVenta" runat="server"> </asp:TextBox>

            </div>

            <div class="form-group">
                <label for="precioCosto" class="control-label">Precio de Costo</label>
                <asp:TextBox type="number" class="form-control" ID="txtPrecioCosto" PlaceHolder="$" name="txtprecioCosto" runat="server"> </asp:TextBox>
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
                <asp:Button Text="Agregar producto" type="submit" class="btn btn-primary" runat="server" OnClick="btnAgregarProducto_Click" />
            </div>

            <div class="form-group" style="display: flex; justify-content: center">
                <asp:Button ID="btnAgregarProducto" Text="Limpiar campos" type="button" class="btn btn-secondary" runat="server" />
            </div>

        </div>

    </form>

    <style>
    
    </style>
</body>
</html>

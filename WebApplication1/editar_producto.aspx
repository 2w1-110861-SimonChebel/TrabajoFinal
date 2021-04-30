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

        <nav class="navbar navbar-expand-lg navbar-light bg-light">
            <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarTogglerDemo01" aria-controls="navbarTogglerDemo01" aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
            </button>
            <div class="collapse navbar-collapse" id="navbarTogglerDemo01">
                <a class="navbar-brand" href="home.aspx">EasyStock</a>
                <%-- <a class="navbar-brand" href="#">
                        <img src="//Assets\ES_Logo.png" width="30" height="30" class="d-inline-block align-top" alt="">
                     EasyStock
                    </a>--%>
                <ul class="navbar-nav mr-auto mt-2 mt-lg-0">
                    <li class="nav-item">
                        <a class="nav-link dropdown-toggle" href="#" id="dropDownProductos" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Productos
                        </a>
                        <div class="dropdown-menu" aria-labelledby="navbarDropdown">
                            <a class="dropdown-item" href="productos.aspx">Ver todos</a>
                            <div class="dropdown-divider"></div>
                            <a class="dropdown-item" href="editar_producto.aspx">Nuevo Producto</a>
                            <a class="dropdown-item" href="#">Reponer Producto</a>
                        </div>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="movimientos.aspx">Movimientos</a>
                    </li>
                    <li class="nav-item dropdown">
                        <a class="nav-link dropdown-toggle" href="#" id="navbarDropdown" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Estadisticas
                        </a>
                        <div class="dropdown-menu" aria-labelledby="navbarDropdown">
                            <a class="dropdown-item" href="#">Productos defectuosos</a>
                            <a class="dropdown-item" href="#">Productos prontos a vencer</a>
                            <a class="dropdown-item" href="#">Productos en deposito</a>
                            <div class="dropdown-divider"></div>
                            <a class="dropdown-item" href="#">Stock disponible</a>
                            <a class="dropdown-item" href="#">Stock faltante</a>
                            <div class="dropdown-divider"></div>
                            <a class="dropdown-item" href="#">Something else here</a>
                        </div>
                    </li>
                </ul>
                <form class="form-inline my-2 my-lg-0">
                    <%-- <input class="form-control mr-sm-2" type="search" placeholder="Buscar" aria-label="Buscar">--%>
                    <button class="btn btn-outline-primary my-2 my-sm-0" type="submit">Buscar</button>
                </form>
            </div>
        </nav>

        <div class="col-md-6 col-xl-6 ">
            <div id="divProductoCargado" class="alert alert-succes" style="display: none" runat="server">
                <h6>Producto(s) cargado(s) correctamente</h6>
            </div>
            <div id="divErrorCargaProducto" class="alert alert-danger" style="display: none" runat="server">
                <h6>Hubo en error en la carga. Verifique los datos y vuelva a intentarlo</h6>
            </div>
            <div id="divTitulo" class="col-md-6 col-xl-6" style="display: flex; justify-items: right" runat="server">
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

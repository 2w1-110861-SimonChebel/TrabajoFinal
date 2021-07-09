<%@ Page Title="" Language="C#" MasterPageFile="~/Header.Master" AutoEventWireup="true" CodeBehind="ayuda.aspx.cs" Inherits="Easy_Stock.ayuda" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h4 style="margin: 2%">Preguntas frecuentes</h4>

    <div class="row col-12 alert alert-info">
        <h5>Productos</h5>
    </div>
    <button type="button" class="accordion">¿Como cargo un nuevo producto?</button>
    <div class="panel">
        <p>
            Para cargar un nuevo producto, dirijase a la barra de opciones superior, pestaña <strong>Productos</strong> y seleccione <strong>Nuevo</strong> .
            Una vez dentro, complete todos los datos necesarios para la carga del producto (se identifican con un (*) al lado de ellos).
        </p>
    </div>

    <button type="button" class="accordion">¿Como edito o elimino un producto cargado?</button>
    <div class="panel">
        <p>
            Para editar o eliminar un producto ya cargado en el sistema,  dirijase a la barra de opciones superior, pestaña <strong>Productos</strong> y seleccione <strong>Ver todos</strong>, luego, elija de la lista el producto que desea editar, o bien busquelo por su ID , código o nombre en la barra de busqueda ubicada en la zona superior de la pantalla.
        Cuando encuentre el producto, seleccione <strong>Editar</strong> para editar el producto, o <strong>Eliminar</strong> para darlo de baja (<strong>La acción de eliminar un producto no puede cancelarse, elimine un producto estando completamente seguro</strong>.)
        </p>
    </div>
    <button type="button" class="accordion">Cambio o devolución</button>
    <div class="panel">
        <p>
            Para realizar un cambio o devolución de productos, dirijase a la barra de opciones superior, pestaña <strong>Productos</strong> y seleccione <strong>Cambio</strong> o <strong>Devolución</strong> según corresponda.
            Luego, busque la transacción original en la cual se vendieron los productos a devolver por al menos <strong>un (1)</strong> filtro de los que se muestran en pantalla.
            <br />
            <asp:Image ID="imgFiltroDevolucion" CssClass="img" runat="server" Height="300px" ImageUrl="~/Images/filtroCambioDev.png" Width="90%" AlternateText="Imagen no disponible" ImageAlign="TextTop" runat="server" />
            <br />
            Posteriormente, seleccione la transacción deseada de la lista con el botón <strong>Elegir</strong>:
            <br />
            <asp:Image ID="Image1" CssClass="img" runat="server" Height="350px" ImageUrl="~/Images/listaDev.png" Width="90%" AlternateText="Imagen no disponible" ImageAlign="TextTop" runat="server" />
            <br />
            <br />
            Por último, seleccione el tipo de devolución, y si corresponde, la forma de devolución del dinero al cliente (esto es solo válido para devoluciones de productos).
            <br />
            <asp:Image ID="Image2" CssClass="img" runat="server" Height="350px" ImageUrl="~/Images/devProd.png" Width="90%" AlternateText="Imagen no disponible" ImageAlign="TextTop" runat="server" />
            <br />
            <br />
            Para finalizar, complete el campo de observaciones y pulse el botón <strong>Finalizar</strong>.

        </p>
    </div>


    <button type="button" class="accordion">¿Como realizo una venta?</button>
    <div class="panel">
        <p>
            Para realizar una una nueva venta, dirijase a la barra de opciones superior, pestaña <strong>Productos</strong> y seleccione <strong>Nueva venta</strong>
            Luego, seleccionede la lista el o los productos que desea vender, o bien busquelos por ID, código o nombre en el a barra de busqueda ubicada en la zona superior de la pantalla, y elija la cantidad
            especifica que desea de ese producto. Para agregarlo al carrito de venta, presione <strong>Agregar</strong>
            <br />
            <asp:Image ID="Image3" CssClass="img" runat="server" Height="400px" ImageUrl="~/Images/cantProductos.png" Width="90%" AlternateText="Imagen no disponible" ImageAlign="TextTop" runat="server" />
            <br />
            Una vez seleccionados todos los productos deseados, seleccion el botón <strong>Continuar</strong> que aparecerá en el margen superior de la pantalla, o bien, <strong>Descartar</strong>, para descartar
            la transacción y volver a la pantalla principal.<br />
            <asp:Image ID="Image4" CssClass="img" runat="server" Height="100%" ImageUrl="~/Images/carrito.png" Width="90%" AlternateText="Imagen no disponible" ImageAlign="TextTop" runat="server" />
            <br />
            Posteriormente, seleccione el cliente que realiza la compra buscandolo por documento o cuit (según corresponda) en la barra de busqueda. En casa de ser un nuevo cliente,
            seleccion <strong>Nuevo</strong> para cargar un nuevo cliente. En éste último caso, una vez cargado el nuevo cliente, se redireccionará a la patantalla de pago.<br />

            Buscar cliente o cargar uno nuevo
            <asp:Image ID="Image5" CssClass="img" runat="server" Height="100%" ImageUrl="~/Images/buscCliVen.png" Width="90%" AlternateText="Imagen no disponible" ImageAlign="TextTop" runat="server" />
            <br />

            Seleccionar el cliente y continuar a la pantalla de pago
            <br />
            <asp:Image ID="Image6" CssClass="img" runat="server" Height="100%" ImageUrl="~/Images/buscCliVenElegir.png" Width="90%" AlternateText="Imagen no disponible" ImageAlign="TextTop" runat="server" />
            <br />
            Por último, seleccione la forma de pago y el tipo de factura a generar, y confirme la venta. En caso de querer cancelar la venta, pulsar el boton <strong>Cancelar y volver</strong>
            <br />
            <asp:Image ID="Image7" CssClass="img" runat="server" Height="100%" ImageUrl="~/Images/pagoCarrito.png" Width="90%" AlternateText="Imagen no disponible" ImageAlign="TextTop" runat="server" />

        </p>
    </div>

    <br />
    <div class="row col-12 alert alert-info">
        <h5>Clientes</h5>
    </div>

    <button type="button" class="accordion">¿Como cargo un nuevo cliente?</button>
    <div class="panel">
        <p>
            Para cargar un nuevo cliente, dirijase a la barra de opciones superior, pestaña <strong>Clientes</strong> y seleccione <strong>Nuevo</strong> .
            Una vez dentro, complete todos los datos necesarios para la carga del clientes (se identifican con un (*) al lado de ellos).
        </p>
    </div>

    <button type="button" class="accordion">¿Como edito o elimino un cliente?</button>
    <div class="panel">
        <p>
            Para editar o eliminar un cliente ya cargado en el sistema,  dirijase a la barra de opciones superior, pestaña <strong>Productos</strong> y seleccione <strong>Ver todos</strong>, luego, elija de la lista el cliente que desea editar, o bien busquelo por su nombre en la barra de busqueda ubicada en la zona superior de la pantalla.
        Cuando encuentre el cliente, seleccione <strong>Editar</strong> para editarlo, o <strong>Eliminar</strong> para darlo de baja (<strong>La acción de eliminar un cliente no puede cancelarse, elimine un producto estando completamente seguro</strong>.)
        </p>
    </div>
    <br>

    <div class="row col-12 alert alert-info">
        <h5>Proveedores</h5>
    </div>

    <button type="button" class="accordion">¿Como cargo un nuevo proveedor?</button>
    <div class="panel">
        <p>
            Para cargar un nuevo proveedor, dirijase a la barra de opciones superior, pestaña <strong>Proveedores</strong> y seleccione <strong>Nuevo proveedor</strong> .
            Una vez dentro, complete todos los datos necesarios para la carga del nuevo proveedor.
        </p>
    </div>
    <button type="button" class="accordion">¿Como realizo un pedido a un proveedor?</button>
       <div class="panel">
        <p>
            Para realizar un pedido, dirijase a la barra de opciones superior, pestaña <strong>Proveedores</strong> y seleccione <strong>Realizar pedido</strong> .
            Una vez dentro, complete todos los datos necesarios para la carga del nuevo proveedor.
        </p><br />
           <p>

               <strong>1)</strong> Seleccione el proveedor al que se le va a realizar el pedido. De no seleccionar ningún proveedor, no podrá continuar con el proceso.<br />
               <asp:Image ID="Image8" CssClass="img" style="margin:2%" runat="server" Height="100%" ImageUrl="~/Images/1_pedido_prov.jpg" Width="90%" AlternateText="Imagen no disponible" ImageAlign="TextTop" runat="server" /> <br />
               <strong>2)</strong> Seleccione los productos involucrados en el pedido.<br />
               <asp:Image ID="Image9" CssClass="img" style="margin:2%" runat="server" Height="100%" ImageUrl="~/Images/2_pedido_prov.jpg" Width="90%" AlternateText="Imagen no disponible" ImageAlign="TextTop" runat="server" /><br />
               <strong>3)</strong> Si desea cancelar la operación, seleccione descartar, de lo contrario seleccione continuar.<br />
               <asp:Image ID="Image10" CssClass="img" style="margin:2%" runat="server" Height="100%" ImageUrl="~/Images/3_pedido_prov.jpg" Width="90%" AlternateText="Imagen no disponible" ImageAlign="TextTop" runat="server" /><br />
                <strong>4)</strong> Por último, verifique los datos de la operación, y presione confirmar para confirmarla. De lo contrario, presione cancelar y volver para cancelar la operación y regresar al menú principal.<br />
               <asp:Image ID="Image11" CssClass="img" style="margin:2%" runat="server" Height="100%" ImageUrl="~/Images/3_pedido_prov.jpg" Width="90%" AlternateText="Imagen no disponible" ImageAlign="TextTop" runat="server" /><br />

           </p>
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

        .img {
            display: block;
            margin: 0 auto;
            max-width: 100%;
            width: 90%;
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

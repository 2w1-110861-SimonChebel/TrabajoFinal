using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Easy_Stock.Entidades
{
    public class Producto
    {
        public int idProducto { get; set; } = 0;
        public string codigo { get; set; } = string.Empty;
        public string descripcion { get; set; } = string.Empty;
        public string nombre { get; set; } = string.Empty;
        public Marca marca { get; set; } = null;
        public float precioVenta { get; set; } = 0;
        public float precioCosto { get; set; } = 0;
        public Categoria categoria { get; set; } = null;
        public Proveedor proveedor { get; set; } = null;
        public Deposito deposito { get; set; } = null;
        public int stockMaximo { get; set; } = 0;
        public int stockMinimo { get; set; } = 0;
        public int cantidadRestante { get; set; } = 0;
        public DateTime fechaVenc { get; set; } = DateTime.Today;
        public DateTime fechaElab { get; set; } = DateTime.Today;
        public DateTime fechaIngreso { get; set; } = DateTime.Today;
        public int cantidad { get; set; } = 0;//solo se usa para el carrito
        public float subTotal { get; set; } = 0;//solo se usa para el carrito

        public Producto() {
            idProducto = 0;
            codigo = string.Empty;
            descripcion = string.Empty;
            nombre = string.Empty;
            marca = new Marca();
            precioCosto = 0;
            precioVenta = 0;
            categoria = new Categoria();
            proveedor = new Proveedor();
            deposito = new Deposito();
            stockMaximo = 0;
            stockMinimo = 0;
            cantidadRestante = 0;
            fechaVenc = DateTime.Today;
            fechaElab = DateTime.Today;
            fechaIngreso = DateTime.Today;
        }

        public float calcularSubTotal()
        {
            return (precioVenta*cantidad);
        }

    }
}
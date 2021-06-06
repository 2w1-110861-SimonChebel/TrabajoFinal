using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Easy_Stock.Entidades
{
    public class Factura
    {
        public int nroFactura { get; set; } = 0;
        public DateTime fecha { get; set; } = DateTime.Now;
        public decimal total { get; set; } = 0;
        public string observaciones { get; set; } = string.Empty;
        public Cliente cliente { get; set; } = null;
        public Empresa empresa { get; set; } = null;
        public List<DetalleFactura> detallesFactura { get; set; } = null;
        public TipoFactura tipoFactura { get; set; } = null;
        public Usuario usuario { get; set; } = null;
        public int iva { get; set; } = 0;

        public Factura()
        {
            empresa = new Empresa();
            detallesFactura = new List<DetalleFactura>();
            tipoFactura = new TipoFactura();
            usuario = new Usuario();
            cliente = new Cliente();
        }

        public int cantidadTotalDeProductos()
        {
            int cantTotal = 0;
            foreach (var item in detallesFactura)
            {
                cantTotal += item.cantidad;
            }
            return cantTotal;
        }

        //meotodo para devolver individualmente productos que esten en el detalle de una factura
        // Ej: si en un renglon del detalle tengo 3 productos A, este metodo devolveria:
        // producto A, producto A, producto A. Los 3 por separado 
        public List<DetalleFactura> listaProductosIndividuales()
        {
            List<DetalleFactura> lstResultado = new List<DetalleFactura>();
            foreach (var detalle in detallesFactura)
            {
                for (int i = 0; i < detalle.cantidad; i++)
                {
                    Producto auxProducto = detalle.producto;
                    auxProducto.cantidad = detalle.cantidad / detalle.cantidad;
                    lstResultado.Add(
                        new DetalleFactura
                        {
                            idDetalle = detalle.idDetalle,
                            cantidad = auxProducto.cantidad,
                            precio = detalle.precio,
                            producto = auxProducto
                        }
                    );
                }

            }
            lstResultado.OrderBy(r => r.producto.idProducto);
            return lstResultado;
        }

        public decimal CalcularIvaSobreTotal(decimal porcIva)
        {
            return this.total * Convert.ToDecimal(porcIva);
        }

        public decimal ObtenerTotalConIva(decimal porcIva=0)
        {
            return this.total + this.CalcularIvaSobreTotal(porcIva);
        }

    }
}
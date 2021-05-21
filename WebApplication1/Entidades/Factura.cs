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
        public float total { get; set; } = 0;
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

    }
}
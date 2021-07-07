using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Easy_Stock.Entidades
{
    public class Pedido
    {
        public int idPedido { get; set; }
        public DateTime fecha { get; set; }
        public string descripcion { get; set; }
        public Empresa empresa { get; set; }
        public decimal total { get; set; } = 0;
        public Proveedor proveedor { get; set; }
        public Usuario usuario { get; set; } = null;
        public int iva { get; set; } = 0;

        public List<DetallePedido> detallesPedido { get; set; }

        public Pedido()
        {
            usuario = new Usuario();
            empresa = new Empresa();
            proveedor = new Proveedor();
            detallesPedido = new List<DetallePedido>();
        }

        public decimal SumarSubTotalesDetalle()
        {
            decimal resultado = 0;

            foreach (var item in detallesPedido)
            {
                resultado += item.subTotal;
            }

            return resultado;
        }


        public decimal CalcularIvaSobreTotal(decimal porcIva)
        {
            return SumarSubTotalesDetalle() * Convert.ToDecimal(porcIva);
        }

        public decimal ObtenerTotalConIva(decimal porcIva = 0)
        {
            decimal resultado = SumarSubTotalesDetalle() * (decimal)1.21;
            return resultado;
        }


    }
}
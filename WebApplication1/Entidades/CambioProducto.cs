using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Easy_Stock.Entidades
{
    public class CambioProducto : Transaccion
    {
        //los productos que salen al momento de hacer el cambio
        // es decir, los nuevos productos que se entregan
        public List<Producto> productosEntregados { get; set; } = null;

        //productos que se reciben para cambiar por parte del cliente/proveedor
        public List<Producto> productosRecibidos { get; set; } = null;
        public CambioProducto() : base()
        {
            productosEntregados = new List<Producto>();
            productosRecibidos = new List<Producto>();
        }
    }
}
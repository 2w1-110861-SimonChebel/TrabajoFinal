using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Easy_Stock.Entidades
{
    public static class Tipo
    {

        public static List<int> tiposDevolucion { get; } = new List<int> {
            (int)tipoTransaccion.devolucionDeCliente,
            (int)tipoTransaccion.devolucionAproveedor
        };

        public static List<int> tiposCambio { get; } = new List<int> {
            (int)tipoTransaccion.cambioProductoAproveedor,
            (int)tipoTransaccion.cambioProductoDeCliente
        };

        public enum tipoCliente
        {
            persona = 1,
            empresa = 2
        }
        public enum tipoEmpresa { 
            pyme = 1,
            sa = 2,
            srl =3,
            autonomo = 4
        }
        public enum tipoFactura
        {
            facturaA = 1,
            facturaB = 2,
            facturaC = 3
        }
        public enum tipoTransaccion
        {
            ventaCliente = 1,
            compraProveedor = 2,
            devolucionDeCliente = 3,
            devolucionAproveedor = 4,
            cambioProductoDeCliente = 5,
            cambioProductoAproveedor = 6
        }
        public enum tipoUsuario
        {
            administrador = 1,
            vendedor = 2,
            invitado = 3
        }

        public enum estadoProducto { 
            disponible = 1,
            noDisponible =2,
            devuelto = 3,
            defectuoso = 4,
            cambio = 5
        }

        public enum tipoDevolucionDineroCliente
        {
            montoDevueltoAcliente =1,
            creditoAfavorDeCliente = 2
        }

    }
}
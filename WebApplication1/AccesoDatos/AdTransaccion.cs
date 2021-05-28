﻿using Easy_Stock.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace Easy_Stock.AccesoDatos
{
    public static class AdTransaccion
    {
        static StringBuilder sbSql = null;
        private static readonly string cadenaConexion = System.Configuration.ConfigurationManager.ConnectionStrings["conexion"].ConnectionString.ToString();



        public static bool DevolverProductos(Factura oFactura, int idCliente = 0,decimal montoDevuelto = 0,int idTransaccion=0, DateTime fecha = default, int idTipoDevolcion = 0,int idTipoTransaccion= 0, int idUsuario=0)
        {
            sbSql = null;
            try
            {
                sbSql = new StringBuilder("SP_DevolverProducto");
                foreach (var item in oFactura.detallesFactura)
                {
                    SqlParameter[] parametros = {
                    new SqlParameter("@idProducto", item.producto.idProducto),
                    new SqlParameter("@idInventario", item.producto.codigoUnico.Split('-')[0]),
                    new SqlParameter("@codigo", item.producto.codigo),
                    new SqlParameter("@cantidadProducto",item.producto.cantidad),
                   // oVentaCliente.proveedor!= null && oVentaCliente.proveedor.idProveedor > 0 ?new SqlParameter("@idProveedor", oVentaCliente.proveedor.idProveedor) : null,
                    new SqlParameter("@idEstado", (int)Tipo.estadoProducto.devuelto),
                    new SqlParameter("@idCliente", idCliente),
                    new SqlParameter("@montoDevuelto", montoDevuelto),
                    new SqlParameter("@idTransaccion", idTransaccion),
                    new SqlParameter("@fecha", fecha),
                    new SqlParameter("@tipoDevolucion", idTipoDevolcion),
                    new SqlParameter("@idTipoTransaccion", idTipoTransaccion),
                    new SqlParameter("@idUsuario", idUsuario)

                    };

                    try
                    {
                        SqlHelper.ExecuteNonQuery(cadenaConexion, CommandType.StoredProcedure, sbSql.ToString(), parametros);
                    }
                    catch (Exception ex)
                    {
                        return false;
                        throw ex;
                    }
                }
              
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }

            return true;
        }


        public static bool RegistrarVenta(VentaCliente oVentaCliente)
        {
            sbSql = null;
            try
            {
                sbSql = new StringBuilder("SP_RegistrarVenta");

                SqlParameter[] parametros = {
                    new SqlParameter("@fecha", oVentaCliente.fecha),
                    new SqlParameter("@desc", oVentaCliente.factura.observaciones),
                    new SqlParameter("@idCliente", oVentaCliente.factura.cliente.idCliente),
                    new SqlParameter("@idEmpresa", oVentaCliente.factura.empresa.idEmpresa),
                    oVentaCliente.proveedor!= null && oVentaCliente.proveedor.idProveedor > 0 ?new SqlParameter("@idProveedor", oVentaCliente.proveedor.idProveedor) : null,
                    new SqlParameter("@descuento", oVentaCliente.descuento),
                    new SqlParameter("@total", oVentaCliente.total),
                    new SqlParameter("@idFormaPago", oVentaCliente.formaPago.idFormaPago),
                    new SqlParameter("@idTipoTransaccion", oVentaCliente.tipoTransaccion.idTipoTransaccion),
                    new SqlParameter("@idUsuario", oVentaCliente.factura.usuario.idUsuario),
                };

                using (SqlDataReader dr = SqlHelper.ExecuteReader(cadenaConexion, CommandType.StoredProcedure, sbSql.ToString(), parametros))
                {


                    int idFactura = obtenerUltimoNroFactura();
                    string sql = "SP_InsertarDetalle_QuitarDeInventario";       
                    for (int i = 0; i < oVentaCliente.factura.detallesFactura.Count; i++)
                    {
                        var item = oVentaCliente.factura.detallesFactura[i];
                     

                        for (int e = 0; e < item.cantidad; e++)
                        {
                            int aux = item.producto.cantidad - 1 - e;
                            SqlParameter[] paramDetalle =  {
                            new SqlParameter("@nroFact", idFactura),
                            new SqlParameter("@cantidadProducto", item.cantidad/item.cantidad),
                            new SqlParameter("@idProducto", item.producto.idProducto),
                            new SqlParameter("@iva", 0),
                            new SqlParameter("@subTotal", item.producto.calcularSubTotal()),
                            new SqlParameter("@precio", item.precio),
                            new SqlParameter("@cantActualizada", aux),
                            new SqlParameter("@codigoProducto", (item.producto.codigo)),
                            new SqlParameter("@idEstado",(int)Tipo.estadoProducto.noDisponible)

                             };
                            try
                            {
                                SqlHelper.ExecuteNonQuery(cadenaConexion, CommandType.StoredProcedure, sql, paramDetalle);
                            }
                            catch (Exception ex)
                            {
                                return false;
                                throw ex;
                            }
                        }
                    

                    }
                }
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
            return true;
        }

        public static List<Transaccion> obtenerTransacciones(bool top5 = false, int idVenta = 0, Cliente oCliente = null, Usuario oUsuario = null, string fecha = "")
        {
            sbSql = null;
            List<Transaccion> lstTransacciones = null;
            SqlParameter[] param = { };
            try
            {
                if (top5) sbSql = new StringBuilder(" SELECT TOP 5 t.idTransaccion,t.idTipoTransaccion,tt.tipoTransaccion, t.fecha,t.descripcion,");
                else sbSql = new StringBuilder("SELECT t.idTransaccion,t.idTipoTransaccion,tt.tipoTransaccion, t.fecha,t.descripcion, ");
                sbSql.Append(" c.idCliente,c.nombre,c.apellido,c.dni,c.cuit,c.direccion,c.barrio,lo.idLocalidad,lo.localidad,p.idProvincia,p.provincia,pr.idProveedor, pr.nombre, c.razonSocial, tc.idTipoCliente,tc.tipoCliente, u.idUsuario,u.nombre,u.apellido  ");
                sbSql.Append(" FROM Transacciones t ");
                sbSql.Append(" JOIN Clientes c on T.idCliente = C.idCliente");
                sbSql.Append(" JOIN Localidades lo ON c.idLocalidad = lo.idLocalidad");
                sbSql.Append(" JOIN Provincias p ON c.idProvincia = p.idProvincia");
                sbSql.Append(" JOIN Tipos_Clientes tc ON c.idTipoCliente = tc.idTipoCliente");
                sbSql.Append(" JOIN Tipos_Transacciones tt ON t.idTipoTransaccion = tt.idTipoTransaccion");
                sbSql.Append(" LEFT JOIN Proveedores pr ON t.idProveedor = pr.idProveedor");
                sbSql.Append(" JOIN Usuarios u ON t.idUsuario = u.idUsuario");
                if (idVenta > 0 || oCliente != null || oUsuario != null || !string.IsNullOrEmpty(fecha))
                {
                    sbSql.Append(" WHERE t.devuelto=0 AND ");
                    if (idVenta > 0) sbSql.Append(" idTransaccion = @idTran ");
                    if (oCliente != null)
                    {
                        if (idVenta > 0) sbSql.Append(" AND(c.nombre LIKE '%@nombreCliente%' OR c.apellido LIKE '%@apellidoCliente%') OR c.razonSocial LIKE '%@razonSocial%'");
                        else sbSql.Append(" (c.nombre LIKE '%@nombreCliente%' OR c.apellido LIKE '%@apellidoCliente%') OR c.razonSocial LIKE '%@razonSocial%'");
                    }
                    if (oUsuario != null)
                    {
                        if (oCliente != null) sbSql.Append(" AND u.idUsuario = @idUsuario");
                        else sbSql.Append(" u.idUsuario=@idUsuario");
                    }
                    if (!string.IsNullOrEmpty(fecha))
                    {
                        if (oUsuario != null) sbSql.Append(" AND fecha = @fecha");
                        else sbSql.Append(" fecha = @fecha");
                    }
                    param = new SqlParameter[] {
                    new SqlParameter("@nombreCliente",oCliente!= null ? oCliente.nombre:string.Empty),
                    new SqlParameter("@apellidoCliente",oCliente!= null ?oCliente.apellido:string.Empty),
                    new SqlParameter("@razonSocial",oCliente!= null? oCliente.razonSocial:string.Empty),
                    new SqlParameter("@idUsuario",oUsuario!=null?oUsuario.idUsuario:0),
                    new SqlParameter("@fecha",fecha),
                    new SqlParameter("@idTran",idVenta)
                    };
                }

                if (top5) sbSql.Append(" ORDER BY t.fecha DESC");


                using (SqlDataReader dr = SqlHelper.ExecuteReader(cadenaConexion, CommandType.Text, sbSql.ToString(), param))
                {
                    if (dr.HasRows)
                    {
                        lstTransacciones = new List<Transaccion>();
                        while (dr.Read())
                        {

                            lstTransacciones.Add(
                                 new Transaccion
                                 {
                                     idTransaccion = dr.IsDBNull(0) ? default(int) : dr.GetInt32(0),
                                     tipoTransaccion = new TipoTransaccion
                                     {
                                         idTipoTransaccion = dr.IsDBNull(1) ? default(int) : dr.GetInt32(1),
                                         tipoTransaccion = dr.IsDBNull(2) ? default(string) : dr.GetString(2)
                                     },
                                     fecha = dr.IsDBNull(3) ? default(DateTime) : dr.GetDateTime(3),
                                     descripcion = dr.IsDBNull(4) ? default(string) : dr.GetString(4),
                                     cliente = new Cliente
                                     {
                                         idCliente = dr.IsDBNull(5) ? default(int) : dr.GetInt32(5),
                                         nombre = dr.IsDBNull(6) ? default(string) : dr.GetString(6),
                                         apellido = dr.IsDBNull(7) ? default(string) : dr.GetString(7),
                                         razonSocial = dr.IsDBNull(18) ? default(string) : dr.GetString(18),
                                         dni = dr.IsDBNull(8) ? default(string) : dr.GetString(8),
                                         cuit = dr.IsDBNull(9) ? default(string) : dr.GetString(9),
                                         direccion = dr.IsDBNull(10) ? default(string) : dr.GetString(10),
                                         barrio = dr.IsDBNull(11) ? default(string) : dr.GetString(11),
                                         localidad = new Localidad
                                         {
                                             idLocalidad = dr.IsDBNull(12) ? default(int) : dr.GetInt32(12),
                                             localidad = dr.IsDBNull(13) ? default(string) : dr.GetString(13)
                                         },
                                         provincia = new Provincia
                                         {
                                             idProvincia = dr.IsDBNull(14) ? default(int) : dr.GetInt32(14),
                                             provincia = dr.IsDBNull(15) ? default(string) : dr.GetString(15)
                                         },
                                         tipoCliente = new TipoCliente
                                         {
                                             idTipoCliente = dr.IsDBNull(19) ? default(int) : dr.GetInt32(19),
                                             tipoCliente = dr.IsDBNull(20) ? default(string) : dr.GetString(20)
                                         }
                                     },
                                     proveedor = new Proveedor
                                     {
                                         idProveedor = dr.IsDBNull(16) ? default(int) : dr.GetInt32(16),
                                         nombre = dr.IsDBNull(17) ? default(string) : dr.GetString(17)
                                     },
                                     usuario = new Usuario
                                     {
                                         idUsuario = dr.IsDBNull(21) ? default(int) : dr.GetInt32(21),
                                         nombre = dr.IsDBNull(22) ? default(string) : dr.GetString(22),
                                         apellido = dr.IsDBNull(23) ? default(string) : dr.GetString(23)
                                     }

                                 }
                         );


                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
                throw ex;
            }
            return lstTransacciones;
        }

        public static List<VentaCliente> obtenerVentasCliente(int idVenta = 0, Cliente oCliente = null, Usuario oUsuario = null, string fecha = "")
        {
            sbSql = null;
            List<VentaCliente> lstVentas = null;
            SqlParameter[] param = { };
            try
            {
                sbSql = new StringBuilder("SELECT t.idTransaccion,t.idTipoTransaccion,tt.tipoTransaccion, t.fecha,t.descripcion, ");
                sbSql.Append(" c.idCliente,c.nombre,c.apellido,c.dni,c.cuit,c.direccion, c.razonSocial,");
                sbSql.Append(" u.idUsuario,u.nombre,u.apellido, f.nroFactura,f.total, dc.idDeuda,dc.monto,dc.montoAfavor ");
                sbSql.Append(" FROM Transacciones t ");
                sbSql.Append(" JOIN Clientes c on T.idCliente = C.idCliente");
                sbSql.Append(" JOIN Tipos_Clientes tc ON c.idTipoCliente = tc.idTipoCliente");
                sbSql.Append(" JOIN Tipos_Transacciones tt ON t.idTipoTransaccion = tt.idTipoTransaccion");
                sbSql.Append(" JOIN Facturas f ON f.idTransaccion = t.idTransaccion");
                sbSql.Append(" JOIN Usuarios u ON t.idUsuario = u.idUsuario");
                sbSql.Append(" JOIN Deudas_clientes dc ON dc.idCliente = c.idCliente");
                if (idVenta > 0 || oCliente != null || oUsuario != null || !string.IsNullOrEmpty(fecha))
                {
                    sbSql.Append(" WHERE t.devuelto=0 AND ");
                    if (idVenta > 0) sbSql.Append(" t.idTransaccion = @idTran ");
                    if (oCliente != null)
                    {
                        if (idVenta > 0) sbSql.Append(" AND(c.nombre LIKE '%@nombreCliente%' OR c.apellido LIKE '%@apellidoCliente%') OR c.razonSocial LIKE '%@razonSocial%'");
                        else sbSql.Append(" (c.nombre LIKE '%@nombreCliente%' OR c.apellido LIKE '%@apellidoCliente%') OR c.razonSocial LIKE '%@razonSocial%'");
                    }
                    if (oUsuario != null)
                    {
                        if (oCliente != null) sbSql.Append(" AND u.idUsuario = @idUsuario");
                        else sbSql.Append(" u.idUsuario=@idUsuario");
                    }
                    if (!string.IsNullOrEmpty(fecha))
                    {
                        if (oUsuario != null) sbSql.Append(" AND fecha = @fecha");
                        else sbSql.Append(" t.fecha = @fecha");
                    }
                    param = new SqlParameter[] {
                    oCliente != null ?new SqlParameter("@nombreCliente",oCliente!= null ? oCliente.nombre:string.Empty):null,
                    oCliente != null ? new SqlParameter("@apellidoCliente",oCliente!= null ?oCliente.apellido:string.Empty):null,
                    oCliente != null ? new SqlParameter("@razonSocial",oCliente!= null? oCliente.razonSocial:string.Empty):null,
                    oUsuario!=null? new SqlParameter("@idUsuario",oUsuario!=null?oUsuario.idUsuario:0):null,
                    fecha!= default ? new SqlParameter("@fecha",fecha):null,
                    idVenta > 0? new SqlParameter("@idTran",idVenta):null
                    };
                }

                using (SqlDataReader dr = SqlHelper.ExecuteReader(cadenaConexion, CommandType.Text, sbSql.ToString(), param))
                {
                    if (dr.HasRows)
                    {
                        lstVentas = new List<VentaCliente>();
                        while (dr.Read())
                        {

                            lstVentas.Add(
                                 new VentaCliente
                                 {
                                     idTransaccion = dr.IsDBNull(0) ? default(int) : dr.GetInt32(0),
                                     tipoTransaccion = new TipoTransaccion
                                     {
                                         idTipoTransaccion = dr.IsDBNull(1) ? default(int) : dr.GetInt32(1),
                                         tipoTransaccion = dr.IsDBNull(2) ? default(string) : dr.GetString(2)
                                     },
                                     fecha = dr.IsDBNull(3) ? default(DateTime) : dr.GetDateTime(3),
                                     descripcion = dr.IsDBNull(4) ? default(string) : dr.GetString(4),
                                     cliente = new Cliente
                                     {
                                         idCliente = dr.IsDBNull(5) ? default(int) : dr.GetInt32(5),
                                         nombre = dr.IsDBNull(6) ? default(string) : dr.GetString(6),
                                         apellido = dr.IsDBNull(7) ? default(string) : dr.GetString(7),
                                         dni = dr.IsDBNull(8) ? default(string) : dr.GetString(8),
                                         cuit = dr.IsDBNull(9) ? default(string) : dr.GetString(9),
                                         direccion = dr.IsDBNull(10) ? default(string) : dr.GetString(10),
                                         razonSocial = dr.IsDBNull(11) ? default(string) : dr.GetString(11),
                                         deuda = new DeudaCliente
                                         {
                                             idDeudaCliente = dr.IsDBNull(17) ? default(int) : dr.GetInt32(17),
                                             monto = dr.IsDBNull(18) ? default(decimal) : dr.GetDecimal(18),
                                             montoAfavor = dr.IsDBNull(19) ? default(decimal) : dr.GetDecimal(19)
                                         }
                                     },

                                     usuario = new Usuario
                                     {
                                         idUsuario = dr.IsDBNull(12) ? default(int) : dr.GetInt32(12),
                                         nombre = dr.IsDBNull(13) ? default(string) : dr.GetString(13),
                                         apellido = dr.IsDBNull(14) ? default(string) : dr.GetString(14)
                                     },
                                     factura = new Factura
                                     {
                                         nroFactura = dr.IsDBNull(15) ? default(int) : dr.GetInt32(15),
                                         total = dr.IsDBNull(16) ? default(decimal) : dr.GetDecimal(16)
                                     }

                                 }
                         );


                        }
                    }
                }

            }
            catch (Exception ex)
            {
                return null;
                throw ex;
            }
            return lstVentas;
        }

        public static Factura obtenerFacturas(int idTransaccion = 0)
        {
            sbSql = null;
            Factura factura = null;
            List<DetalleFactura> lstDetalle = new List<DetalleFactura>();
            SqlParameter[] param = null;
            try
            {
                sbSql = new StringBuilder("SELECT f.nroFactura,f.fecha, f.total,p.idProducto, p.codigo,p.nombre,df.idDetalle,df.cantidad,df.subTotal,df.precio, p.cantidadRestante,p.stockMinimo,p.stockMaximo, inv.idInventario, p.precioCosto,p.precioVenta, c.idCliente ");
                sbSql.Append(" FROM Facturas f join Detalles_Facturas DF on f.nroFactura = df.nroFactura ");
                sbSql.Append(" JOIN Productos p on p.idProducto = df.idProducto ");
                sbSql.Append(" JOIN Transacciones t on f.idTransaccion = t.idTransaccion");
                sbSql.Append(" JOIN Inventario inv on inv.idInventario = df.idInventario");
                sbSql.Append(" JOIN Clientes c  on c.idCliente = f.idCliente");
                sbSql.Append(" where f.idTransaccion = @idTransaccion ORDER BY f.nroFactura");
                if (idTransaccion > 0)
                {
                    param = new SqlParameter[] {
                        new SqlParameter("@idTransaccion",idTransaccion)
                    };
                }

                using (SqlDataReader dr = SqlHelper.ExecuteReader(cadenaConexion, CommandType.Text, sbSql.ToString(), param))
                {
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            lstDetalle.Add(new DetalleFactura
                            {
                                idDetalle = dr.IsDBNull(6) ? default(int) : dr.GetInt32(6),
                                cantidad = dr.IsDBNull(7) ? default(int) : dr.GetInt32(7) / dr.GetInt32(7),
                                subTotal = dr.IsDBNull(8) ? default(decimal) : dr.GetDecimal(8),
                                precio = dr.IsDBNull(9) ? default(decimal) : dr.GetDecimal(9),
                                producto = new Producto
                                {
                                    idProducto = dr.IsDBNull(3) ? default(int) : dr.GetInt32(3),
                                    codigo = dr.IsDBNull(4) ? default(string) : dr.GetString(4),
                                    nombre = dr.IsDBNull(5) ? default(string) : dr.GetString(5),
                                    cantidadRestante = dr.IsDBNull(10) ? default(int) : dr.GetInt32(10),
                                    stockMinimo = dr.IsDBNull(11) ? default(int) : dr.GetInt32(11),
                                    stockMaximo = dr.IsDBNull(12) ? default(int) : dr.GetInt32(12),
                                    codigoUnico = string.Format("{0}{1}{2}",dr.IsDBNull(13) ? default(string) : dr.GetInt32(13).ToString(),"-",dr.GetString(4)),
                                    precioCosto = dr.IsDBNull(14) ? default(decimal) : dr.GetDecimal(14),
                                    precioVenta = dr.IsDBNull(15) ? default(decimal) : dr.GetDecimal(15)
                                }
                            });
                            factura = new Factura
                            {
                                nroFactura = dr.IsDBNull(0) ? default(int) : dr.GetInt32(0),
                                fecha = dr.IsDBNull(1) ? default(DateTime) : dr.GetDateTime(1),
                                total = dr.IsDBNull(2) ? default(decimal) : dr.GetDecimal(2),
                                detallesFactura = lstDetalle,
                                cliente = new Cliente { 
                                    idCliente = dr.IsDBNull(16) ? default(int) : dr.GetInt32(16)
                                }

                            };
                            
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                return null;
                throw ex;
            }
            return factura;
        }

        private static int obtenerUltimoNroFactura()
        {
            int nro = 0;
            StringBuilder sql = new StringBuilder("SELECT MAX(nroFactura) FROM Facturas");
            try
            {
                using (SqlDataReader dr = SqlHelper.ExecuteReader(cadenaConexion, CommandType.Text, sql.ToString()))
                {
                    if (dr.HasRows)
                    {
                        dr.Read();
                        nro = dr.IsDBNull(0) ? 0 : dr.GetInt32(0);
                    }
                }
            }
            catch (Exception ex)
            {
                return 0;
                throw ex;
            }
            return nro;
        }
    }
}
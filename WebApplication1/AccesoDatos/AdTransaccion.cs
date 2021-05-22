using Easy_Stock.Entidades;
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

        public  static bool RegistrarVenta(VentaCliente oVentaCliente)
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
                    new SqlParameter("@descuento", oVentaCliente.descuento),
                    new SqlParameter("@total", oVentaCliente.total),
                    new SqlParameter("@idFormaPago", oVentaCliente.formaPago.idFormaPago),
                    new SqlParameter("@idTipoTransaccion", oVentaCliente.tipoTransaccion.idTipoTransaccion),
                    new SqlParameter("@idUsuario", oVentaCliente.factura.usuario.idUsuario),
                    //new SqlParameter("@idFactura", oVentaCliente.factura.nroFactura),
                    //new SqlParameter("@cantidad", oVentaCliente.factura.cantidadTotalDeProductos()),
                    //new SqlParameter("@idProducto", oCliente.apellido),
                    //new SqlParameter("@iva", oCliente.dni),
                    //new SqlParameter("@subTotal", oCliente.barrio),
                };

                using (SqlDataReader dr = SqlHelper.ExecuteReader(cadenaConexion, CommandType.StoredProcedure, sbSql.ToString(), parametros)) 
                {
                     int idFactura = obtenerUltimoNroFactura();
                    string sql = "INSERT INTO Detalles_Facturas (nroFactura,cantidad,idProducto,iva, subTotal,precio) ";
                    sql += "VALUES (@nroFactura,@cantidad,@idProducto,@iva,@subTotal,@precio)";
                    for (int i = 0; i < oVentaCliente.factura.detallesFactura.Count; i++)
                    {
                        var item = oVentaCliente.factura.detallesFactura[i];
                        SqlParameter[] paramDetalle =  {
                            new SqlParameter("@nroFactura", idFactura),
                            new SqlParameter("@cantidad", item.cantidad),
                            new SqlParameter("@idProducto", item.producto.idProducto),
                            new SqlParameter("@iva", 0),
                            new SqlParameter("@subTotal", item.producto.calcularSubTotal()),
                            new SqlParameter("@precio", item.precio),

                        };

                        try
                        {
                            SqlHelper.ExecuteNonQuery(cadenaConexion, CommandType.Text, sql, paramDetalle);
                        }
                        catch (Exception ex)
                        {
                            return false;
                            throw ex;
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

        public static List<Transaccion> obtenerTransacciones(bool top10=false)
        {
            sbSql = null;
            List<Transaccion> lstTransacciones = null;
            try
            {
                if (top10) sbSql = new StringBuilder(" SELECT TOP 10 t.idTransaccion,t.idTipoTransaccion,tt.tipoTransaccion, t.fecha,t.descripcion,");
                sbSql = new StringBuilder("SELECT t.idTransaccion,t.idTipoTransaccion,tt.tipoTransaccion, t.fecha,t.descripcion, ");
                sbSql.Append(" c.idCliente,c.nombre,c.apellido,c.dni,c.cuit,c.direccion,c.barrio,lo.idLocalidad,lo.localidad,p.idProvincia,p.provincia,pr.idProveedor, pr.nombre, c.razonSocial, tc.idTipoCliente,tc.tipoCliente  ");
                sbSql.Append(" FROM Transacciones t ");
                sbSql.Append(" JOIN Clientes c on T.idCliente = C.idCliente");
                sbSql.Append(" JOIN Localidades lo ON c.idLocalidad = lo.idLocalidad");
                sbSql.Append(" JOIN Provincias p ON c.idProvincia = p.idProvincia");
                sbSql.Append(" JOIN Tipos_Clientes tc ON c.idTipoCliente = tc.idTipoCliente");
                sbSql.Append(" JOIN Tipos_Transacciones tt ON t.idTipoTransaccion = tt.idTipoTransaccion");
                sbSql.Append(" LEFT JOIN Proveedores pr ON t.idProveedor = pr.idProveedor");
                if (top10) sbSql.Append(" ORDER BY t.fecha DESC");

                using (SqlDataReader dr = SqlHelper.ExecuteReader(cadenaConexion, CommandType.Text, sbSql.ToString()))
                {
                    if (dr.HasRows)
                    {
                        lstTransacciones = new List<Transaccion>();
                        while (dr.Read())
                        {
                            Transaccion t = new Transaccion();
                            t.idTransaccion = dr.IsDBNull(0) ? default(int) : dr.GetInt32(0);
                            TipoTransaccion tt = new TipoTransaccion();
                            tt.idTipoTransaccion = dr.IsDBNull(1) ? default(int) : dr.GetInt32(1);
                            tt.tipoTransaccion = dr.IsDBNull(2) ? default(string) : dr.GetString(2);
                            t.fecha = dr.IsDBNull(3) ? default(DateTime) : dr.GetDateTime(3);
                            t.descripcion = dr.IsDBNull(4) ? default(string) : dr.GetString(4);
                            Cliente c = new Cliente();
                            TipoCliente tc = new TipoCliente();
                            tc.idTipoCliente = dr.IsDBNull(19) ? default(int) : dr.GetInt32(19);
                            tc.tipoCliente = dr.IsDBNull(20) ? default(string) : dr.GetString(20);
                            c.idCliente = dr.IsDBNull(5) ? default(int) : dr.GetInt32(5);
                            c.nombre = dr.IsDBNull(6) ? default(string) : dr.GetString(6);
                            c.apellido = dr.IsDBNull(7) ? default(string) : dr.GetString(7);
                            c.razonSocial = dr.IsDBNull(18) ? default(string) : dr.GetString(18);
                            c.dni = dr.IsDBNull(8) ? default(string) : dr.GetString(8);
                            c.cuit = dr.IsDBNull(9) ? default(string) : dr.GetString(9);
                            c.direccion = dr.IsDBNull(10) ? default(string) : dr.GetString(10);
                            c.barrio = dr.IsDBNull(11) ? default(string) : dr.GetString(11);
                            Localidad lo = new Localidad();
                            lo.idLocalidad = dr.IsDBNull(12) ? default(int) : dr.GetInt32(12);
                            lo.localidad = dr.IsDBNull(13) ? default(string) : dr.GetString(13);
                            Provincia pr = new Provincia();
                            pr.idProvincia = dr.IsDBNull(14) ? default(int) : dr.GetInt32(14);
                            pr.provincia = dr.IsDBNull(15) ? default(string) : dr.GetString(15);
                            Proveedor pro = new Proveedor();
                            pro.idProveedor = dr.IsDBNull(16) ? default(int) : dr.GetInt32(16);
                            pro.nombre = dr.IsDBNull(17) ? default(string) : dr.GetString(17);


                            lstTransacciones.Add(
                                 new Transaccion
                                 {
                                     idTransaccion = dr.IsDBNull(0) ? default(int) : dr.GetInt32(0),
                                     tipoTransaccion = new TipoTransaccion { 
                                         idTipoTransaccion = dr.IsDBNull(1) ? default(int) : dr.GetInt32(1),
                                         tipoTransaccion = dr.IsDBNull(2) ? default(string) : dr.GetString(2)
                                     },
                                     fecha = dr.IsDBNull(3) ? default(DateTime) : dr.GetDateTime(3),
                                     descripcion = dr.IsDBNull(4) ? default(string) : dr.GetString(4),
                                     cliente = new Cliente { 
                                         idCliente = dr.IsDBNull(5) ? default(int) : dr.GetInt32(5),
                                         nombre = dr.IsDBNull(6) ? default(string) : dr.GetString(6),
                                         apellido = dr.IsDBNull(7) ? default(string) : dr.GetString(7),
                                         razonSocial = dr.IsDBNull(18) ? default(string) : dr.GetString(18),
                                         dni = dr.IsDBNull(8) ? default(string) : dr.GetString(8),
                                         cuit = dr.IsDBNull(9) ? default(string) : dr.GetString(9),
                                         direccion = dr.IsDBNull(10) ? default(string) : dr.GetString(10),
                                         barrio = dr.IsDBNull(11) ? default(string) : dr.GetString(11),
                                         localidad = new Localidad { 
                                             idLocalidad = dr.IsDBNull(12) ? default(int) : dr.GetInt32(12),
                                             localidad = dr.IsDBNull(13) ? default(string) : dr.GetString(13)
                                         },
                                         provincia = new Provincia {
                                             idProvincia = dr.IsDBNull(14) ? default(int) : dr.GetInt32(14),
                                             provincia = dr.IsDBNull(15) ? default(string) : dr.GetString(15)
                                         },
                                         tipoCliente = new TipoCliente { 
                                             idTipoCliente= dr.IsDBNull(19) ? default(int) : dr.GetInt32(19),
                                             tipoCliente = dr.IsDBNull(20) ? default(string) : dr.GetString(20)
                                         }
                                     },
                                     proveedor = new Proveedor { 
                                         idProveedor = dr.IsDBNull(16) ? default(int) : dr.GetInt32(16),
                                         nombre = dr.IsDBNull(17) ? default(string) : dr.GetString(17)
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
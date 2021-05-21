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

        public List<Transaccion> obtenerTransaccion()
        {
            sbSql = null;
            try
            {

            }
            catch (Exception ex)
            {
                return null;
                throw ex;
            }
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
using Easy_Stock.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Easy_Stock.AccesoDatos
{
    public static class AdReporte
    {
        static StringBuilder sbSql = null;
        private static readonly string cadenaConexion = System.Configuration.ConfigurationManager.ConnectionStrings["conexion"].ConnectionString.ToString();

        public static Reporte ObtenerTotalFacturado(Reporte auxRepo)
        {
            sbSql = null;
            Reporte oReporte = null;
            List<Factura> lstFacturas;
            try
            {
                sbSql = new StringBuilder(auxRepo.query.comando);

                using (SqlDataReader dr = SqlHelper.ExecuteReader(cadenaConexion, CommandType.Text, sbSql.ToString(), auxRepo.query.parametros))
                {
                    if (dr.HasRows)
                    {
                        oReporte = new ReTotalFacturado();
                        lstFacturas = new List<Factura>();
                        while (dr.Read())
                        {

                            lstFacturas.Add(
                                new Factura { 
                                    nroFactura = dr.IsDBNull(0) ? default : dr.GetInt32(0),
                                    total = dr.IsDBNull(1) ? default: dr.GetDecimal(1)
                                }
                            );
                            
                        }
                        ((ReTotalFacturado)oReporte).facturas = lstFacturas;
                        ((ReTotalFacturado)oReporte).totalTodasFacturas = ((ReTotalFacturado)oReporte).CalcularTotalFacturado();


                    }
                }
            }
            catch (Exception ex)
            {
                return null;
                throw ex;
            }

            return oReporte;
        }

        public static Reporte ObtenerTotalFacturadoGrafico(Reporte auxRepo)
        {
            sbSql = null;
            Reporte oReporte = null;
            List<Factura> lstFacturas;
            try
            {
                sbSql = new StringBuilder(auxRepo.query.comando);

                using (SqlDataReader dr = SqlHelper.ExecuteReader(cadenaConexion, CommandType.Text, sbSql.ToString(), auxRepo.query.parametros))
                {
                    if (dr.HasRows)
                    {
                        oReporte = new ReTotalFacturado();
                        lstFacturas = new List<Factura>();
                        while (dr.Read())
                        {

                            lstFacturas.Add(
                                new Factura
                                {
                                    nroFactura = dr.IsDBNull(0) ? default : dr.GetInt32(0),
                                    total = dr.IsDBNull(1) ? default : dr.GetDecimal(1),
                                    fecha = dr.IsDBNull(2) ? default : dr.GetDateTime(2)
                                }
                            );

                        }
                        ((ReTotalFacturado)oReporte).facturas = lstFacturas;
                        ((ReTotalFacturado)oReporte).totalTodasFacturas = ((ReTotalFacturado)oReporte).CalcularTotalFacturado();


                    }
                }
            }
            catch (Exception ex)
            {
                return null;
                throw ex;
            }

            return oReporte;
        }

        public static List<Factura> ObtenerRankingClientes()
        {
            sbSql = null;
            List<Factura> lstResultado = null;
            try
            {
                sbSql = new StringBuilder(" SELECT TOP 10 c.idCliente,c.nombre,c.apellido,c.razonSocial,c.dni,c.cuit, SUM(f.total) Total ,COUNT(f.nroFactura), c.idTipoCliente ");
                sbSql.Append(" FROM Clientes c JOIN Facturas f on f.idCliente = c.idCliente ");
                sbSql.Append(" GROUP BY c.idCliente,c.nombre,c.apellido,c.razonSocial,c.dni,c.cuit,c.idTipoCliente ORDER BY Total DESC ");

                using (SqlDataReader dr = SqlHelper.ExecuteReader(cadenaConexion, CommandType.Text, sbSql.ToString()))
                {
                    if (dr.HasRows)
                    {
                        lstResultado = new List<Factura>();
                        while (dr.Read())
                        {
                            lstResultado.Add(
                                new Factura {
                                    cliente = new Cliente { 
                                        idCliente = dr.IsDBNull(0) ? 0 : dr.GetInt32(0),
                                        nombre = dr.IsDBNull(1) ? string.Empty : dr.GetString(1),
                                        apellido = dr.IsDBNull(2) ? string.Empty : dr.GetString(2),
                                        razonSocial = dr.IsDBNull(3) ? string.Empty : dr.GetString(3),
                                        dni = dr.IsDBNull(4) ? string.Empty : dr.GetString(4),
                                        cuit = dr.IsDBNull(5) ? string.Empty : dr.GetString(5),   
                                        tipoCliente = new TipoCliente {
                                            idTipoCliente = dr.IsDBNull(8) ?  0 : dr.GetInt32(8)
                                        }
                                    },
                                    total = dr.IsDBNull(6) ? 0 : dr.GetDecimal(6),
                                    cantidadFacutasPorCliente = dr.IsDBNull(7) ? 0 : dr.GetInt32(7)
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

            return lstResultado;
        }

        public static ReVenta ObtenerTotalPorCategoria(int idCategoria=0)
        {
            sbSql = null;
            ReVenta resultado = null;
            SqlParameter[] param = null;

            try
            {
                if (idCategoria == 0)
                {
                    sbSql = new StringBuilder(" SELECT TOP 5 SUM (df.subTotal),c.idCategoria,c.nombre from Facturas f ");
                    sbSql.Append(" JOIN Detalles_Facturas df on f.nroFactura  = df.nroFactura JOIN Productos P on p.idProducto = df.idProducto JOIN Categorias c ON C.idCategoria  = P.idCategoria ");
                    sbSql.Append(" GROUP BY c.idCategoria,c.nombre order by 1 DESC  ");
                }
                else {
                    sbSql = new StringBuilder(" SELECT SUM (df.subTotal),c.idCategoria,c.nombre from Facturas f ");
                    sbSql.Append(" JOIN Detalles_Facturas df on f.nroFactura  = df.nroFactura  JOIN Productos P on p.idProducto = df.idProducto  JOIN Categorias c ON C.idCategoria  = P.idCategoria ");
                    sbSql.Append(" WHERE p.idCategoria = @idCat GROUP BY c.idCategoria,c.nombre ");

                    param = new SqlParameter[] {
                    new SqlParameter("@idCat",idCategoria)
                    };
                }
                
                using (SqlDataReader dr = SqlHelper.ExecuteReader(cadenaConexion, CommandType.Text, sbSql.ToString(), param))
                {
                    if (dr.HasRows)
                    {
                        resultado = new ReVenta();

                        while (dr.Read())
                        {
                            resultado.totalesCategoriasxFactura.Add(
                                new TotalCategoriaxFactura { 
                                    factura = new Factura {  
                                        
                                        total = dr.IsDBNull(0) ? 0 : dr.GetDecimal(0)
                                    },
                                    categoria = new Categoria { 
                                        idCategoria = dr.IsDBNull(1) ? 0 : dr.GetInt32(1),
                                        nombre = dr.IsDBNull(2) ? string.Empty : dr.GetString(2)
                                    }
                                }
                            );
                        }
                        
                    }
                }
                return resultado;
            }
            catch (Exception ex)
            {
                return null;
                throw ex;
            }
        }

        public static ReVenta ObtenerTotalPorProduto()
        {
            sbSql = null;
            ReVenta resultado = null;

            try
            {

                sbSql = new StringBuilder(" SELECT TOP 5 SUM (df.subTotal),p.nombre from Facturas f JOIN Detalles_Facturas df on f.nroFactura  = df.nroFactura  ");
                sbSql.Append(" JOIN Productos P on p.idProducto = df.idProducto GROUP BY p.nombre order by 1 DESC ");

                using (SqlDataReader dr = SqlHelper.ExecuteReader(cadenaConexion, CommandType.Text, sbSql.ToString()))
                {
                    if (dr.HasRows)
                    {
                        resultado = new ReVenta();

                        while (dr.Read())
                        {
                            resultado.totalesProductosxFactura.Add(
                                new TotalPorProducto
                                {
                                    producto = new Producto
                                    {
                                        nombre = dr.IsDBNull(1) ? string.Empty : dr.GetString(1)
                                    },
                                    factura = new Factura 
                                    { 
                                        total = dr.IsDBNull(0) ? 0 : dr.GetDecimal(0)
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
            return resultado;
        }


    }
}
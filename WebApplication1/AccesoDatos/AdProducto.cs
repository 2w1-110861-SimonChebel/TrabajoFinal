﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Easy_Stock.Entidades;

namespace Easy_Stock.AccesoDatos
{
    public static class AdProducto
    {
        static StringBuilder sbSql = null;
        private static readonly string cadenaConexion = System.Configuration.ConfigurationManager.ConnectionStrings["conexion"].ConnectionString.ToString();

        public static List<Producto> obtenerProductos()
        {
            try
            {
                sbSql = new StringBuilder("SELECT p.idProducto,p.nombre,p.descripcion,m.idMarca,m.marca,p.precioVenta,p.precioCosto, p.stockMinimo, p.stockMaximo,c.idCategoria, c.nombre 'categoria',pr.idProveedor, pr.nombre 'Proveedor'");
                sbSql.Append(" FROM Productos p JOIN Marcas m ON p.idMarca = m.idMarca");
                sbSql.Append(" JOIN Categorias c ON p.idCategoria = c.idCategoria");
                sbSql.Append(" JOIN Proveedores pr ON p.idProveedor = pr.idProveedor");
                using (SqlDataReader dr = SqlHelper.ExecuteReader(cadenaConexion, CommandType.Text, sbSql.ToString()))
                {
                    List<Producto> lstProductos = null;
                    if (dr.HasRows)
                    {
                        lstProductos = new List<Producto>();
                        while (dr.Read())
                        {
                            lstProductos.Add(new Producto {
                                idProducto = dr.IsDBNull(0) ? default(int): dr.GetInt32(0),
                                nombre = dr.IsDBNull(1) ? default(string) : dr.GetString(1),
                                descripcion = dr.IsDBNull(2) ? default(string) : dr.GetString(2),
                                marca = new Marca {
                                    idMarca = dr.IsDBNull(3) ? default(int) : dr.GetInt32(3),
                                    marca = dr.IsDBNull(4) ? default(string) : dr.GetString(4)
                                },
                                precioVenta = dr.IsDBNull(5) ? default(float) : dr.GetFloat(5),
                                precioCosto = dr.IsDBNull(6) ? default(float) : dr.GetFloat(5),
                                stockMinimo = dr.IsDBNull(7) ? default(int) : dr.GetInt32(7),
                                stockMaximo = dr.IsDBNull(8) ? default(int) : dr.GetInt32(8),
                                categoria = new Categoria { 
                                    idCategoria = dr.IsDBNull(9) ? default(int) : dr.GetInt32(9),
                                    categoria = dr.IsDBNull(10) ? default(string) : dr.GetString(10)
                                },
                                proveedor = new Proveedor { 
                                    idProveedor = dr.IsDBNull(11) ? default(int) : dr.GetInt32(11),
                                    nombre = dr.IsDBNull(12) ? default(string) : dr.GetString(12)
                                }

                            }); 
                        }                                             
                    }
                    return lstProductos;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public static Producto obtenerProducto(int idProducto)
        {
            try
            {
                sbSql = new StringBuilder("SELECT p.idProducto,p.nombre,p.descripcion,m.idMarca,m.marca,p.precioVenta,p.precioCosto, p.stockMinimo, p.stockMaximo,c.idCategoria, c.nombre 'categoria',pr.idProveedor, pr.nombre 'Proveedor'");
                sbSql.Append(" FROM Productos p JOIN Marcas m ON p.idMarca = m.idMarca");
                sbSql.Append(" JOIN Categorias c ON p.idCategoria = c.idCategoria");
                sbSql.Append(" JOIN Proveedores pr ON p.idProveedor = pr.idProveedor");
                sbSql.Append(" JOIN Proveedores pr ON p.idProveedor = pr.idProveedor");
                sbSql.Append(" WHERE p.idProducto = @idProducto");

                SqlParameter parametro = new SqlParameter("@idProducto", idProducto);

                using (SqlDataReader dr = SqlHelper.ExecuteReader(cadenaConexion, CommandType.Text, sbSql.ToString(), parametro))
                {
                    Producto oProducto = null;
                    if (dr.HasRows)
                    {
                        oProducto = new Producto
                        {
                            idProducto = dr.IsDBNull(0) ? default(int) : dr.GetInt32(0),
                            nombre = dr.IsDBNull(1) ? default(string) : dr.GetString(1),
                            descripcion = dr.IsDBNull(2) ? default(string) : dr.GetString(2),
                            marca = new Marca
                            {
                                idMarca = dr.IsDBNull(3) ? default(int) : dr.GetInt32(3),
                                marca = dr.IsDBNull(4) ? default(string) : dr.GetString(4)
                            },
                            precioVenta = dr.IsDBNull(5) ? default(float) : dr.GetFloat(5),
                            precioCosto = dr.IsDBNull(6) ? default(float) : dr.GetFloat(5),
                            stockMinimo = dr.IsDBNull(7) ? default(int) : dr.GetInt32(7),
                            stockMaximo = dr.IsDBNull(8) ? default(int) : dr.GetInt32(8),
                            categoria = new Categoria
                            {
                                idCategoria = dr.IsDBNull(9) ? default(int) : dr.GetInt32(9),
                                categoria = dr.IsDBNull(10) ? default(string) : dr.GetString(10)
                            },
                            proveedor = new Proveedor
                            {
                                idProveedor = dr.IsDBNull(11) ? default(int) : dr.GetInt32(11),
                                nombre = dr.IsDBNull(12) ? default(string) : dr.GetString(12)
                            }
                        };
                    }
                    return oProducto;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool eliminarProductoPorId(int idProducto)
        {
            try
            {
                string sql = "DELETE FROM Productos WHERE idProducto = @idProducto";
                SqlParameter[] parametros = { 
                    new SqlParameter("@idProducto", idProducto)
                };

                SqlHelper.ExecuteNonQuery(cadenaConexion, CommandType.Text, sql, parametros);
            }
            catch (Exception ex)
            {
                return false;
                throw ex;                
            }
            return true;               
        }

        public static bool actualizarProducto(Producto oProdcuto) 
        {
            try
            {
                StringBuilder sbSql = new StringBuilder("UPDATE Productos");
                sbSql.Append("SET nombre=@nombre, ");
                sbSql.Append("idMarca=@idMarca, ");
                sbSql.Append("precioVenta=@precioVenta, ");
                sbSql.Append("precioCosto=@precioCosto, ");
                sbSql.Append("descripcion=@descripcion, ");
                sbSql.Append("idCategoria=@idCategoria, ");
                sbSql.Append("idProveedor=@idProveedor, ");
                //sbSql.Append("idDeposito=@idDeposito, ");
                sbSql.Append("stockMinimo=@stockMinimo, ");
                sbSql.Append("stockMaximo=@stockMaximo ");
                sbSql.Append("WHERE idProducto=@idProducto");

                SqlParameter[] parametros = {
                    new SqlParameter("@idProducto", oProdcuto.idProducto),
                    new SqlParameter("@idMarca", oProdcuto.marca.idMarca),
                    new SqlParameter("@precioVenta", oProdcuto.precioVenta),
                    new SqlParameter("@precioCosto", oProdcuto.precioCosto),
                    new SqlParameter("@descripcion", oProdcuto.descripcion),
                    new SqlParameter("@idCategoria", oProdcuto.categoria.idCategoria),
                    new SqlParameter("@idProveedor", oProdcuto.proveedor.idProveedor),
                    //new SqlParameter("@idDeposito", oProdcuto.deposito.idDeposito),
                    new SqlParameter("@stockMinimo", oProdcuto.stockMinimo),
                    new SqlParameter("@stockMaximo", oProdcuto.stockMaximo),
                };

                SqlHelper.ExecuteNonQuery(cadenaConexion, CommandType.Text, sbSql.ToString(), parametros);
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
            return true;
        }
        
    }
}
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


        public static bool agregarProducto(Producto oProducto)
        {
            sbSql = null;
            bool tieneDeposito = oProducto.deposito.idDeposito > 0;
            try
            {
                //sbSql = new StringBuilder("INSERT INTO Productos(idMarca,nombre,precioVenta,precioCosto,descripcion,idCategoria,idProveedor,idDeposito,stockMinimo,stockMaximo,cantidadRestante)");
                sbSql = new StringBuilder("INSERT INTO Productos(codigo,idMarca,nombre,precioVenta,precioCosto,descripcion,idCategoria,idProveedor,stockMinimo,stockMaximo,cantidadRestante,fechaVenc,fechaElab,habilitado"+(tieneDeposito?",idDeposito":string.Empty) +")");
                sbSql.Append(" VALUES(@codigo,@idMarca,@nombre,@precioVenta,@precioCosto,@descripcion,@idCategoria,@idProveedor,@stockMinimo,@stockMaximo,@cantidad,@fechaVenc,@fechaElab,@habilitado" + (tieneDeposito? ",@idDeposito":string.Empty) +")");

                if (tieneDeposito)
                {

                    SqlParameter[] parametros = {
                    new SqlParameter("@idMarca", oProducto.marca.idMarca),
                    new SqlParameter("@nombre", oProducto.nombre),
                    new SqlParameter("@precioVenta", oProducto.precioVenta),
                    new SqlParameter("@precioCosto", oProducto.precioCosto),
                    new SqlParameter("@descripcion", oProducto.descripcion),
                    new SqlParameter("@idCategoria", oProducto.categoria.idCategoria),
                    new SqlParameter("@idProveedor", oProducto.proveedor.idProveedor),
                    new SqlParameter("@idDeposito", oProducto.deposito.idDeposito),
                    new SqlParameter("@stockMinimo", oProducto.stockMinimo),
                    new SqlParameter("@stockMaximo", oProducto.stockMaximo),
                    new SqlParameter("@cantidad", oProducto.cantidadRestante),
                    new SqlParameter("@fechaVenc", oProducto.fechaVenc),
                    new SqlParameter("@fechaElab", oProducto.fechaElab),
                    new SqlParameter("@codigo", oProducto.codigo),
                    new SqlParameter("@habilitado",1)
                    };   
                    SqlHelper.ExecuteNonQuery(cadenaConexion, CommandType.Text, sbSql.ToString(), parametros);
                }
                else
                {
                    SqlParameter[] parametros = {
                    new SqlParameter("@idMarca", oProducto.marca.idMarca),
                    new SqlParameter("@nombre", oProducto.nombre),
                    new SqlParameter("@precioVenta", oProducto.precioVenta),
                    new SqlParameter("@precioCosto", oProducto.precioCosto),
                    new SqlParameter("@descripcion", oProducto.descripcion),
                    new SqlParameter("@idCategoria", oProducto.categoria.idCategoria),
                    new SqlParameter("@idProveedor", oProducto.proveedor.idProveedor),
                    new SqlParameter("@stockMinimo", oProducto.stockMinimo),
                    new SqlParameter("@stockMaximo", oProducto.stockMaximo),
                    new SqlParameter("@cantidad", oProducto.cantidadRestante),
                    new SqlParameter("@fechaVenc", oProducto.fechaVenc),
                    new SqlParameter("@fechaElab", oProducto.fechaElab),
                    new SqlParameter("@codigo", oProducto.codigo),
                    new SqlParameter("@habilitado",1)
                    };
                    SqlHelper.ExecuteNonQuery(cadenaConexion, CommandType.Text, sbSql.ToString(), parametros);
                }


                
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
            return true;
        }


        public static void actualizarProducto(Producto oProdcuto)
        {
            sbSql = null;
            bool tieneDeposito;
            try
            {
                tieneDeposito = oProdcuto.deposito.idDeposito > 0;
                StringBuilder sbSql = new StringBuilder("UPDATE Productos");
                sbSql.Append(" SET codigo=@codigo,nombre=@nombre, idMarca=@idMarca, precioVenta=@precioVenta, precioCosto=@precioCosto, descripcion=@descripcion, idCategoria= @idCategoria, idProveedor=@idProveedor,stockMinimo=@stockMinimo,stockMaximo=@stockMaximo,fechaVenc=@fechaVenc,fechaElab=@fechaElab");
                if (tieneDeposito) { sbSql.Append(",idDeposito=@idDeposit"); };
                sbSql.Append(" WHERE idProducto=@idProducto");

                if (tieneDeposito)
                {
                    SqlParameter[] parametros = {
                    new SqlParameter("@idProducto", oProdcuto.idProducto),
                    new SqlParameter("@codigo", oProdcuto.codigo),
                    new SqlParameter("@nombre", oProdcuto.nombre),
                    new SqlParameter("@idMarca", oProdcuto.marca.idMarca),
                    new SqlParameter("@precioVenta", oProdcuto.precioVenta),
                    new SqlParameter("@precioCosto", oProdcuto.precioCosto),
                    new SqlParameter("@descripcion", oProdcuto.descripcion),
                    new SqlParameter("@idCategoria", oProdcuto.categoria.idCategoria),
                    new SqlParameter("@idProveedor", oProdcuto.proveedor.idProveedor),
                    new SqlParameter("@stockMinimo", oProdcuto.stockMinimo),
                    new SqlParameter("@stockMaximo", oProdcuto.stockMaximo),
                    new SqlParameter ("@idDeposito", oProdcuto.deposito.idDeposito ),
                    new SqlParameter("@cantidad", oProdcuto.cantidadRestante),
                    new SqlParameter("@fechaVenc", oProdcuto.fechaVenc),
                    new SqlParameter("@fechaElab", oProdcuto.fechaElab)
                    };
                    SqlHelper.ExecuteNonQuery(cadenaConexion, CommandType.Text, sbSql.ToString(), parametros);
                }
                else
                {
                    SqlParameter[] parametros = {
                    new SqlParameter("@idProducto", oProdcuto.idProducto),
                    new SqlParameter("@codigo", oProdcuto.codigo),
                    new SqlParameter("@nombre", oProdcuto.nombre),
                    new SqlParameter("@idMarca", oProdcuto.marca.idMarca),
                    new SqlParameter("@precioVenta", oProdcuto.precioVenta),
                    new SqlParameter("@precioCosto", oProdcuto.precioCosto),
                    new SqlParameter("@descripcion", oProdcuto.descripcion),
                    new SqlParameter("@idCategoria", oProdcuto.categoria.idCategoria),
                    new SqlParameter("@idProveedor", oProdcuto.proveedor.idProveedor),
                    new SqlParameter("@stockMinimo", oProdcuto.stockMinimo),
                    new SqlParameter("@stockMaximo", oProdcuto.stockMaximo),
                    new SqlParameter("@cantidad", oProdcuto.cantidadRestante),
                    new SqlParameter("@fechaVenc", oProdcuto.fechaVenc),
                    new SqlParameter("@fechaElab", oProdcuto.fechaElab)

                    };

                    SqlHelper.ExecuteNonQuery(cadenaConexion, CommandType.Text, sbSql.ToString(), parametros);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static List<Producto> obtenerProductos(string nombre = "")
        {
            sbSql = null;
            try
            {
                sbSql = new StringBuilder("SELECT p.idProducto,p.nombre,p.descripcion,m.idMarca,m.marca,p.precioVenta,p.precioCosto, p.stockMinimo, p.stockMaximo,c.idCategoria, c.nombre 'categoria',pr.idProveedor, pr.nombre 'Proveedor', p.cantidadRestante,p.fechaVenc,p.fechaElab,p.codigo ");
                sbSql.Append(" FROM Productos p JOIN Marcas m ON p.idMarca = m.idMarca");
                sbSql.Append(" JOIN Categorias c ON p.idCategoria = c.idCategoria");
                sbSql.Append(" JOIN Proveedores pr ON p.idProveedor = pr.idProveedor");
                if (!string.IsNullOrEmpty(nombre)) sbSql.Append(string.Format("{0}{1}{2}", " WHERE p.nombre LIKE '%", nombre, "%' AND habilitado=1"));
                using (SqlDataReader dr = SqlHelper.ExecuteReader(cadenaConexion, CommandType.Text, sbSql.ToString()))
                {
                    List<Producto> lstProductos = null;
                    if (dr.HasRows)
                    {
                        lstProductos = new List<Producto>();
                        while (dr.Read())
                        {
                            lstProductos.Add(new Producto
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
                                precioCosto = dr.IsDBNull(6) ? default(float) : dr.GetFloat(6),
                                stockMinimo = dr.IsDBNull(7) ? default(int) : dr.GetInt32(7),
                                stockMaximo = dr.IsDBNull(8) ? default(int) : dr.GetInt32(8),
                                categoria = new Categoria
                                {
                                    idCategoria = dr.IsDBNull(9) ? default(int) : dr.GetInt32(9),
                                    nombre = dr.IsDBNull(10) ? default(string) : dr.GetString(10)
                                },
                                proveedor = new Proveedor
                                {
                                    idProveedor = dr.IsDBNull(11) ? default(int) : dr.GetInt32(11),
                                    nombre = dr.IsDBNull(12) ? default(string) : dr.GetString(12)
                                },
                                cantidadRestante = dr.IsDBNull(13) ? default(int) : dr.GetInt32(13),
                                fechaVenc = dr.IsDBNull(14) ? default(DateTime) : dr.GetDateTime(14),
                                fechaElab = dr.IsDBNull(15) ? default(DateTime) : dr.GetDateTime(15),
                                codigo = dr.IsDBNull(16) ? default(string) : dr.GetString(16)

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

        public static Producto obtenerProductoPorId(int idProducto)
        {
            sbSql = null;
            try
            {
                sbSql = new StringBuilder("SELECT p.idProducto,p.nombre,p.descripcion,m.idMarca,m.marca,p.precioVenta,p.precioCosto, p.stockMinimo, p.stockMaximo,c.idCategoria, c.nombre 'categoria',pr.idProveedor, pr.nombre 'Proveedor', p.cantidadRestante,p.fechaVenc,p.fechaElab,p.codigo");
                sbSql.Append(" FROM Productos p JOIN Marcas m ON p.idMarca = m.idMarca");
                sbSql.Append(" JOIN Categorias c ON p.idCategoria = c.idCategoria");
                sbSql.Append(" JOIN Proveedores pr ON p.idProveedor = pr.idProveedor");
                sbSql.Append(" WHERE p.idProducto = @idProducto");

                SqlParameter parametro = new SqlParameter("@idProducto", idProducto);

                using (SqlDataReader dr = SqlHelper.ExecuteReader(cadenaConexion, CommandType.Text, sbSql.ToString(), parametro))
                {
                    Producto oProducto = null;
                    if (dr.HasRows)
                    {
                        dr.Read();
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
                            precioCosto = dr.IsDBNull(6) ? default(float) : dr.GetFloat(6),
                            stockMinimo = dr.IsDBNull(7) ? default(int) : dr.GetInt32(7),
                            stockMaximo = dr.IsDBNull(8) ? default(int) : dr.GetInt32(8),
                            categoria = new Categoria
                            {
                                idCategoria = dr.IsDBNull(9) ? default(int) : dr.GetInt32(9),
                                nombre = dr.IsDBNull(10) ? default(string) : dr.GetString(10)
                            },
                            proveedor = new Proveedor
                            {
                                idProveedor = dr.IsDBNull(11) ? default(int) : dr.GetInt32(11),
                                nombre = dr.IsDBNull(12) ? default(string) : dr.GetString(12)
                            },
                            cantidadRestante = dr.IsDBNull(13) ? default(int) : dr.GetInt32(13),
                            fechaVenc = dr.IsDBNull(14) ? default(DateTime) : dr.GetDateTime(14),
                            fechaElab = dr.IsDBNull(15) ? default(DateTime) : dr.GetDateTime(15),
                            codigo = dr.IsDBNull(16) ? default(string) : dr.GetString(16)
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

        public static List<ProductoReponer> obtenerProductosReponer(string nombre)
        {

            sbSql = null;
            List<ProductoReponer> lstProductos = null;
            try
            {
                sbSql = new StringBuilder("SELECT p.idProducto,p.nombre, p.cantidadRestante,p.codigo");
                sbSql.Append(" FROM Productos p");
                sbSql.Append(string.Format("{0}{1}{2}", " WHERE p.nombre like '%", nombre, "%' AND habilitado=1"));

                SqlParameter parametro = new SqlParameter("@nombre", nombre);

                using (SqlDataReader dr = SqlHelper.ExecuteReader(cadenaConexion, CommandType.Text, sbSql.ToString(), parametro))
                {
                    if (dr.HasRows)
                    {
                        lstProductos = new List<ProductoReponer>();
                        while (dr.Read())
                        {
                            lstProductos.Add(new ProductoReponer
                            {
                                idProducto = dr.IsDBNull(0) ? default(int) : dr.GetInt32(0),
                                nombre = dr.IsDBNull(1) ? default(string) : dr.GetString(1),
                                cantidadRestante = dr.IsDBNull(2) ? default(int) : dr.GetInt32(2),
                                codigo = dr.IsDBNull(3) ? default(string) : dr.GetString(3),

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

        public static bool eliminarProductoPorId(int idProducto)
        {
            sbSql = null;
            try
            {
                //string sql = "DELETE FROM Productos WHERE idProducto = @idProducto";
                string sql = "UPDATE Productos SET habilitado=0 WHERE idProducto = @idProducto";
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

        public static void reponerProductos(List<Producto> lstProductos)
        {
            sbSql = null;
            try
            {

                foreach (var item in lstProductos)
                {
                    StringBuilder sbSql = new StringBuilder("UPDATE Productos");
                    sbSql.Append(" SET cantidadRestante=@cantidad");
                    sbSql.Append(" WHERE idProducto = @idProducto");

                    SqlParameter[] parametros = {
                    new SqlParameter("@idProducto", item.idProducto),
                    new SqlParameter("@cantidad", item.cantidadRestante)
                    };

                    SqlHelper.ExecuteNonQuery(cadenaConexion, CommandType.Text, sbSql.ToString(), parametros);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
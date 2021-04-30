using System;
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
            try
            {
                //sbSql = new StringBuilder("INSERT INTO Productos(idMarca,nombre,precioVenta,precioCosto,descripcion,idCategoria,idProveedor,idDeposito,stockMinimo,stockMaximo,cantidadRestante)");
                sbSql = new StringBuilder("INSERT INTO Productos(idMarca,nombre,precioVenta,precioCosto,descripcion,idCategoria,idProveedor,stockMinimo,stockMaximo,cantidadRestante)");
                sbSql.Append("VALUES(@idMarca,@nombre,@precioVenta,@precioCosto,@descripcion,@idCategoria,@idProveedor,@stockMinimo,@stockMaximo,@cantidad)");

                string idDeposito = oProducto.deposito.idDeposito == 0 ? null : oProducto.deposito.idDeposito.ToString();

                SqlParameter[] parametros = {
                    new SqlParameter("@idMarca", oProducto.marca.idMarca),
                    new SqlParameter("@nombre", oProducto.nombre),
                    new SqlParameter("@precioVenta", oProducto.precioVenta),
                    new SqlParameter("@precioCosto", oProducto.precioCosto),
                    new SqlParameter("@descripcion", oProducto.descripcion),
                    new SqlParameter("@idCategoria", oProducto.categoria.idCategoria),
                    new SqlParameter("@idProveedor", oProducto.proveedor.idProveedor),
                    //new SqlParameter("@idDeposito", Convert.ToInt32(idDeposito)),
                    new SqlParameter("@stockMinimo", oProducto.stockMinimo),
                    new SqlParameter("@stockMaximo", oProducto.stockMaximo),
                    new SqlParameter("@cantidad", oProducto.cantidadRestante)
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
        public static List<Producto> obtenerProductos()
        {
            sbSql = null;
            try
            {
                sbSql = new StringBuilder("SELECT p.idProducto,p.nombre,p.descripcion,m.idMarca,m.marca,p.precioVenta,p.precioCosto, p.stockMinimo, p.stockMaximo,c.idCategoria, c.nombre 'categoria',pr.idProveedor, pr.nombre 'Proveedor', p.cantidadRestante");
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
                                precioCosto = dr.IsDBNull(6) ? default(float) : dr.GetFloat(5),
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
                                cantidadRestante = dr.IsDBNull(13) ? default(int) : dr.GetInt32(13)

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
            sbSql = null;
            try
            {
                sbSql = new StringBuilder("SELECT p.idProducto,p.nombre,p.descripcion,m.idMarca,m.marca,p.precioVenta,p.precioCosto, p.stockMinimo, p.stockMaximo,c.idCategoria, c.nombre 'categoria',pr.idProveedor, pr.nombre 'Proveedor', p.cantidadRestante");
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
                            precioCosto = dr.IsDBNull(6) ? default(float) : dr.GetFloat(5),
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
                            cantidadRestante = dr.IsDBNull(13) ? default(int) : dr.GetInt32(13)
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

        public static Producto obtenerProductoPorNombre(string nombre)
        {

            sbSql = null;
            try
            {
                sbSql = new StringBuilder("SELECT p.idProducto,p.nombre,p.descripcion,m.idMarca,m.marca,p.precioVenta,p.precioCosto, p.stockMinimo, p.stockMaximo,c.idCategoria, c.nombre 'categoria',pr.idProveedor, pr.nombre 'Proveedor', p.cantidadRestante");
                sbSql.Append(" FROM Productos p JOIN Marcas m ON p.idMarca = m.idMarca");
                sbSql.Append(" JOIN Categorias c ON p.idCategoria = c.idCategoria");
                sbSql.Append(" JOIN Proveedores pr ON p.idProveedor = pr.idProveedor");
                sbSql.Append(string.Format("{0}{1}{2}", " WHERE p.nombre like '%",nombre,"%'"));

                SqlParameter parametro = new SqlParameter("@nombre", nombre);

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
                            precioCosto = dr.IsDBNull(6) ? default(float) : dr.GetFloat(5),
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
                            cantidadRestante = dr.IsDBNull(13) ? default(int) : dr.GetInt32(13)
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
            sbSql = null;
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

        public static void actualizarProducto(Producto oProdcuto)
        {
            sbSql = null;
            try
            {
                StringBuilder sbSql = new StringBuilder("INSERT INTO Productos");
                sbSql.Append("(nombre, idMarca, precioVenta, precioCosto, descripcion, idCategoria, idProveedor, idDeposito,stockMinimo, stockMaximo, cantidadRestante)");
                sbSql.Append("VALUES(@idMarca, @precioVenta, @precioCosto, @descripcion, @idCategoria, @idProveedor, @idDeposito, @stockMinimo,@stockMaximo, @cantidad)");

                SqlParameter[] parametros = {
                    new SqlParameter("@idProducto", oProdcuto.idProducto),
                    new SqlParameter("@idMarca", oProdcuto.marca.idMarca),
                    new SqlParameter("@precioVenta", oProdcuto.precioVenta),
                    new SqlParameter("@precioCosto", oProdcuto.precioCosto),
                    new SqlParameter("@descripcion", oProdcuto.descripcion),
                    new SqlParameter("@idCategoria", oProdcuto.categoria.idCategoria),
                    new SqlParameter("@idProveedor", oProdcuto.proveedor.idProveedor),
                    new SqlParameter("@idDeposito", oProdcuto.deposito != null ? oProdcuto.deposito.idDeposito : 0),
                    new SqlParameter("@stockMinimo", oProdcuto.stockMinimo),
                    new SqlParameter("@stockMaximo", oProdcuto.stockMaximo),
                    new SqlParameter("@cantidad", oProdcuto.cantidadRestante),
                };

                SqlHelper.ExecuteNonQuery(cadenaConexion, CommandType.Text, sbSql.ToString(), parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
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
            bool tieneDeposito = oProducto.deposito.idDeposito > 0;
            try
            {
                //sbSql = new StringBuilder("INSERT INTO Productos(idMarca,nombre,precioVenta,precioCosto,descripcion,idCategoria,idProveedor,idDeposito,stockMinimo,stockMaximo,cantidadRestante)");
                //sbSql = new StringBuilder("INSERT INTO Productos(codigo,idMarca,nombre,precioVenta,precioCosto,descripcion,idCategoria,idProveedor,stockMinimo,stockMaximo,cantidadRestante,fechaVenc,fechaElab,habilitado" + (tieneDeposito ? ",idDeposito" : string.Empty) + ", fechaIngreso)");
                //sbSql.Append(" VALUES(@codigo,@idMarca,@nombre,@precioVenta,@precioCosto,@descripcion,@idCategoria,@idProveedor,@stockMinimo,@stockMaximo,@cantidad,@fechaVenc,@fechaElab,@habilitado" + (tieneDeposito ? ",@idDeposito" : string.Empty) + ",@fechaIngreso )");
                sbSql = new StringBuilder("SP_AgregarProducto");
                SqlParameter[] parametros = {
                    new SqlParameter("@codigo", oProducto.codigo),
                    new SqlParameter("@idMarca", oProducto.marca.idMarca),
                    new SqlParameter("@nombre", oProducto.nombre),
                    new SqlParameter("@precioVenta", oProducto.precioVenta),
                    new SqlParameter("@precioCosto", oProducto.precioCosto),
                    new SqlParameter("@descripcion", oProducto.descripcion),
                    new SqlParameter("@idCategoria", oProducto.categoria.idCategoria),
                    new SqlParameter("@idProveedor", oProducto.proveedor.idProveedor),
                    tieneDeposito? new SqlParameter("@idDeposito", oProducto.deposito.idDeposito) : null,
                    new SqlParameter("@stockMinimo", oProducto.stockMinimo),
                    new SqlParameter("@stockMaximo", oProducto.stockMaximo),
                    new SqlParameter("@cantidad", oProducto.cantidadRestante),
                    new SqlParameter("@fechaVenc", oProducto.fechaVenc),
                    new SqlParameter("@fechaElab", oProducto.fechaElab),
                    new SqlParameter("@habilitado",1),
                    new SqlParameter("@fechaIngreso",DateTime.Now),
                    new SqlParameter("@idEstado",(int)Tipo.estadoProducto.disponible)
                };

               SqlHelper.ExecuteNonQuery(cadenaConexion, CommandType.StoredProcedure, sbSql.ToString(), parametros);

                //SqlHelper.ExecuteNonQuery(cadenaConexion, CommandType.Text, sbSql.ToString(), parametros);

            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
            return true;
        }


        public static bool actualizarProducto(Producto oProducto)
        {
            sbSql = null;
            bool tieneDeposito;
            try
            {
                tieneDeposito = oProducto.deposito.idDeposito > 0;
                StringBuilder sbSql = new StringBuilder("UPDATE Productos");
                sbSql.Append(" SET codigo=@codigo, nombre=@nombre, idMarca=@idMarca, precioVenta=@precioVenta, precioCosto=@precioCosto, descripcion=@descripcion, idCategoria= @idCategoria, idProveedor=@idProveedor,stockMinimo=@stockMinimo,stockMaximo=@stockMaximo,fechaVenc=@fechaVenc,fechaElab=@fechaElab, fechaIngreso =@fechaIngreso ");
                if (tieneDeposito) { sbSql.Append(",idDeposito=@idDeposit"); };
                sbSql.Append(" WHERE idProducto=@idProducto");

                if (tieneDeposito)
                {
                    SqlParameter[] parametros = {
                    new SqlParameter("@idProducto", oProducto.idProducto),
                    new SqlParameter("@codigo", oProducto.codigo),
                    new SqlParameter("@nombre", oProducto.nombre),
                    new SqlParameter("@idMarca", oProducto.marca.idMarca),
                    new SqlParameter("@precioVenta", oProducto.precioVenta),
                    new SqlParameter("@precioCosto", oProducto.precioCosto),
                    new SqlParameter("@descripcion", oProducto.descripcion),
                    new SqlParameter("@idCategoria", oProducto.categoria.idCategoria),
                    new SqlParameter("@idProveedor", oProducto.proveedor.idProveedor),
                    new SqlParameter("@stockMinimo", oProducto.stockMinimo),
                    new SqlParameter("@stockMaximo", oProducto.stockMaximo),
                    new SqlParameter ("@idDeposito", oProducto.deposito.idDeposito ),
                    //new SqlParameter("@cantidad", oProducto.cantidadRestante),
                    new SqlParameter("@fechaVenc", oProducto.fechaVenc),
                    new SqlParameter("@fechaElab", oProducto.fechaElab),
                    new SqlParameter("@fechaIngreso", oProducto.fechaIngreso)
                    };
                    SqlHelper.ExecuteNonQuery(cadenaConexion, CommandType.Text, sbSql.ToString(), parametros);
                    return true;
                }
                else
                {
                    SqlParameter[] parametros = {
                    new SqlParameter("@idProducto", oProducto.idProducto),
                    new SqlParameter("@codigo", oProducto.codigo),
                    new SqlParameter("@nombre", oProducto.nombre),
                    new SqlParameter("@idMarca", oProducto.marca.idMarca),
                    new SqlParameter("@precioVenta", oProducto.precioVenta),
                    new SqlParameter("@precioCosto", oProducto.precioCosto),
                    new SqlParameter("@descripcion", oProducto.descripcion),
                    new SqlParameter("@idCategoria", oProducto.categoria.idCategoria),
                    new SqlParameter("@idProveedor", oProducto.proveedor.idProveedor),
                    new SqlParameter("@stockMinimo", oProducto.stockMinimo),
                    new SqlParameter("@stockMaximo", oProducto.stockMaximo),
                    //new SqlParameter("@cantidad", oProducto.cantidadRestante),
                    new SqlParameter("@fechaVenc", oProducto.fechaVenc),
                    new SqlParameter("@fechaElab", oProducto.fechaElab),
                    new SqlParameter("@fechaIngreso", oProducto.fechaIngreso)

                    };

                    SqlHelper.ExecuteNonQuery(cadenaConexion, CommandType.Text, sbSql.ToString(), parametros);
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
        }


        public static List<Producto> ObtenerProductos(string nombre = "", bool vencimiento = false, bool esInventario = false)
        {
            sbSql = null;
            try
            {
                sbSql = new StringBuilder("SELECT p.idProducto,p.nombre,p.descripcion,m.idMarca,m.marca,p.precioVenta,p.precioCosto, p.stockMinimo, p.stockMaximo,c.idCategoria, c.nombre 'categoria',pr.idProveedor, pr.nombre 'Proveedor', p.cantidadRestante,p.fechaVenc,p.fechaElab, p.codigo, p.fechaIngreso, p.cantidadRestante ");
                if (esInventario) sbSql.Append(" ,inv.idInventario,inv.codigo");
                sbSql.Append(" FROM Productos p JOIN Marcas m ON p.idMarca = m.idMarca");
                sbSql.Append(" JOIN Categorias c ON p.idCategoria = c.idCategoria");
                sbSql.Append(" JOIN Proveedores pr ON p.idProveedor = pr.idProveedor");
                if (esInventario) sbSql.Append(" JOIN Inventario inv  ON inv.idProducto = p.idProducto");
                //if (!string.IsNullOrEmpty(nombre) && !vencimiento) sbSql.Append(string.Format("{0}{1}{2}", " WHERE p.nombre LIKE '%", nombre, "% OR p.codigo LIKE ' AND p.habilitado=1"));
                if (!string.IsNullOrEmpty(nombre) && !vencimiento) sbSql.Append(string.Format(" WHERE p.nombre LIKE '%{0}%' OR p.codigo LIKE '%{0}%' OR p.idProducto LIKE '%{0}%' AND (p.habilitado = 1 )", nombre));
                if (string.IsNullOrEmpty(nombre) && vencimiento) sbSql.Append(" WHERE DATEDIFF(DAY,GETDATE(),p.fechaVenc) <= 7");

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
                                precioVenta = dr.IsDBNull(5) ? default(decimal) : dr.GetDecimal(5),
                                precioCosto = dr.IsDBNull(6) ? default(decimal) : dr.GetDecimal(6),
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
                                codigo = dr.IsDBNull(16) ? default(string) : dr.GetString(16),
                                fechaIngreso = dr.IsDBNull(17) ? default(DateTime) : dr.GetDateTime(17),
                                cantidad = dr.IsDBNull(18) ? default : dr.GetInt32(18),
                                codigoUnico = esInventario ? string.Format("{0}{1}{2}", dr.IsDBNull(19) ? dr.GetString(19) : default, "-", dr.GetString(16)) : string.Empty

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

        public static List<Producto> ObtenerProductosStock()
        {
            sbSql = null;
            List<Producto> resultado = null;

            try
            {
                sbSql = new StringBuilder("SELECT p.idProducto,p.nombre,p.descripcion,m.idMarca,m.marca,p.stockMinimo, p.stockMaximo,c.idCategoria, c.nombre 'categoria',p.cantidadRestante, ");
                sbSql.Append(" p.codigo FROM Productos p JOIN Marcas m ON P.idMarca = m.idMarca JOIN Categorias c ON p.idCategoria = c.idCategoria ");
                sbSql.Append(" WHERE p.cantidadRestante < p.stockMinimo ORDER BY p.nombre ");

                using (SqlDataReader dr = SqlHelper.ExecuteReader(cadenaConexion, CommandType.Text, sbSql.ToString()))
                {
                    if (dr.HasRows)
                    {
                        resultado = new List<Producto>();

                        while (dr.Read())
                        {
                            resultado.Add(
                                new Producto
                                {
                                    idProducto = dr.IsDBNull(0) ? 0 : dr.GetInt32(0),
                                    nombre = dr.IsDBNull(1) ? string.Empty : dr.GetString(1),
                                    descripcion = dr.IsDBNull(2) ? string.Empty : dr.GetString(2),
                                    marca = new Marca { 
                                        idMarca = dr.IsDBNull(3) ? 0 : dr.GetInt32(3),
                                        marca = dr.IsDBNull(4) ? string.Empty : dr.GetString(4),
                                    },
                                    stockMinimo = dr.IsDBNull(5) ? 0 : dr.GetInt32(5),
                                    stockMaximo = dr.IsDBNull(6) ? 0 : dr.GetInt32(6),
                                    categoria = new Categoria { 
                                        idCategoria = dr.IsDBNull(7) ? 0 : dr.GetInt32(7),
                                        nombre = dr.IsDBNull(8) ? string.Empty : dr.GetString(8),
                                    },
                                    cantidadRestante = dr.IsDBNull(9) ? 0 : dr.GetInt32(9),
                                    codigo = dr.IsDBNull(10) ? string.Empty : dr.GetString(10),
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

        public static List<Producto> ObtenerProductoPorId(int idProducto, bool esInventario = false, int cantidad = 0)
        {
            sbSql = null;
            try
            {
                sbSql = new StringBuilder("SELECT p.idProducto,p.nombre,p.descripcion,m.idMarca,m.marca,p.precioVenta,p.precioCosto, p.stockMinimo, p.stockMaximo,c.idCategoria, c.nombre 'categoria',pr.idProveedor, pr.nombre 'Proveedor', p.cantidadRestante,p.fechaVenc,p.fechaElab,p.codigo,p.fechaIngreso, p.cantidadRestante ");
                if (esInventario) sbSql.Append(" ,inv.idInventario,inv.codigo");
                sbSql.Append(" FROM Productos p JOIN Marcas m ON p.idMarca = m.idMarca");
                sbSql.Append(" JOIN Categorias c ON p.idCategoria = c.idCategoria");
                sbSql.Append(" JOIN Proveedores pr ON p.idProveedor = pr.idProveedor");
                if (esInventario) sbSql.Append(" JOIN Inventario inv ON inv.idProducto = p.idProducto");
                sbSql.Append(" WHERE p.idProducto = @idProducto");

                SqlParameter parametro = new SqlParameter("@idProducto", idProducto);

                using (SqlDataReader dr = SqlHelper.ExecuteReader(cadenaConexion, CommandType.Text, sbSql.ToString(), parametro))
                {
                    List<Producto> lstProductos = null;
                    //Producto oProducto = null;
                    if (dr.HasRows)
                    {
                        int contador = 0;
                        lstProductos = new List<Producto>();
                        while (dr.Read() && contador == 0 ? contador <= cantidad : contador < cantidad)
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
                                precioVenta = dr.IsDBNull(5) ? default(decimal) : dr.GetDecimal(5),
                                precioCosto = dr.IsDBNull(6) ? default(decimal) : dr.GetDecimal(6),
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
                                codigo = dr.IsDBNull(16) ? default(string) : dr.GetString(16),
                                fechaIngreso = dr.IsDBNull(17) ? default(DateTime) : dr.GetDateTime(17),
                                cantidad = dr.IsDBNull(18) ? default : dr.GetInt32(18),
                                codigoUnico = esInventario ? string.Format("{0}{1}{2}", dr.IsDBNull(19) ? default : dr.GetInt32(19), "-", dr.GetString(16)) : string.Empty
                            }); ;
                            contador++;
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

        public static List<ProductoReponer> ObtenerProductosReponer(string nombre)
        {

            sbSql = null;
            List<ProductoReponer> lstProductos = null;
            try
            {
                sbSql = new StringBuilder("SELECT p.idProducto,p.nombre, p.cantidadRestante, p.codigo");
                sbSql.Append(" FROM Productos p");
                //sbSql.Append(string.Format("{0}{1}{2}", " WHERE p.nombre like '%", nombre, "%' AND habilitado=1"));
                sbSql.Append(string.Format(" WHERE p.nombre like '%{0}%' OR p.idProducto LIKE '%{0}%' OR p.codigo LIKE '%{0}%'", nombre));

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
                                codigo = dr.IsDBNull(3) ? default(string) : dr.GetString(3)
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

        public static bool EliminarProductoPorId(int idProducto)
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

        public static bool ReponerProductos(int idProd, string codigo, int cantidad)
        {
            sbSql = null;
            try
            {
                sbSql = new StringBuilder("ReponerProducto");

                SqlParameter[] parametros = {
                    new SqlParameter("@idProducto", idProd),
                    new SqlParameter("@codigoProducto", codigo),
                    new SqlParameter("@cantidad", cantidad)
                    };

                SqlHelper.ExecuteNonQuery(cadenaConexion, CommandType.StoredProcedure, sbSql.ToString(), parametros);

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
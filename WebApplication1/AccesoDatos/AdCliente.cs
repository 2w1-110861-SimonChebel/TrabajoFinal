using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;
using Easy_Stock.Entidades;

namespace Easy_Stock.AccesoDatos
{
    public static class AdCliente
    {
        static StringBuilder sbSql = null;
        private static readonly string cadenaConexion = System.Configuration.ConfigurationManager.ConnectionStrings["conexion"].ConnectionString.ToString();

        public static bool agregarCliente(Cliente oCliente)
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
                    new SqlParameter("@idDeposito", Convert.ToInt32(idDeposito)),
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

        public static List<Cliente> obtenerClientes(string nombreYapellido = "",int idTipoEmpresa=0)
        {
            sbSql = null;
            try
            {
                sbSql = new StringBuilder("SELECT c.idCliente,c.telefono,c.email,c.direccion,c.codigoPostal,c.fechaNacimiento,c.nombre,c.apellido,c.dni,c.razonSocial,c.barrio,");
                sbSql.Append("tc.idTipoCliente, tc.tipoCliente,");
                sbSql.Append("l.idLocalidad,l.localidad, p.idProvincia,p.provincia,c.razonSocial");
                if (idTipoEmpresa > 0) sbSql.Append(",tp.idTipoEmpresa,tp.tipoEmpresa, c.cuit");

                sbSql.Append(" FROM clientes c JOIN Tipos_Clientes tc ON c.idTipoCliente = tc.idTipoCliente ");
                sbSql.Append(" JOIN Localidades l  ON l.idLocalidad = c.idLocalidad");
                sbSql.Append(" JOIN Provincias p ON p.idProvincia = C.idProvincia");
                sbSql.Append(" JOIN Sexos s on s.idSexo = c.idSexo");
                if (idTipoEmpresa > 0) sbSql.Append(" JOIN Tipos_Empresas tp on tp.idTipoEmpresa = c.idTipoEmpresa");
                if (idTipoEmpresa > 0) sbSql.Append(string.Format("{0}{1}{2}", " WHERE c.razonSocial LIKE '%", nombreYapellido, "%'"));
                else if (!string.IsNullOrEmpty(nombreYapellido)) sbSql.Append(string.Format("{0}{1}{2}{3}{4}", " WHERE c.nombre LIKE '%", nombreYapellido, "%' OR c.apellido LIKE '%",nombreYapellido,"%' "));
                
                using (SqlDataReader dr = SqlHelper.ExecuteReader(cadenaConexion, CommandType.Text, sbSql.ToString()))
                {
                    List<Cliente> lstClientes = null;
                    if (dr.HasRows)
                    {
                        lstClientes = new List<Cliente>();
                        while (dr.Read())
                        {
                            int auxTipoCliente = dr.IsDBNull(11) ? 0 : dr.GetInt32(11);
                            if (auxTipoCliente == 1)
                            {
                                lstClientes.Add(new ClientePersona
                                {
                                    idCliente = dr.IsDBNull(0) ? default(int) : dr.GetInt32(0),
                                    telefono = dr.IsDBNull(1) ? default(string) : dr.GetString(1),
                                    email = dr.IsDBNull(2) ? default(string) : dr.GetString(2),
                                    direccion = dr.IsDBNull(3) ? default(string) : dr.GetString(3),
                                    codigoPostal = dr.IsDBNull(4) ? default(string) : dr.GetString(4),
                                    fechaNacimiento = dr.IsDBNull(5) ? default(DateTime) : dr.GetDateTime(5),
                                    nombre = dr.IsDBNull(6) ? default(string) : dr.GetString(6),
                                    apellido = dr.IsDBNull(7) ? default(string) : dr.GetString(7),
                                    dni = dr.IsDBNull(8) ? default(string) : dr.GetString(8),
                                    barrio = dr.IsDBNull(10) ? default(string) : dr.GetString(10),
                                    tipoCliente = new TipoCliente {
                                        idTipoCliente = dr.IsDBNull(11) ? default(int) : dr.GetInt32(11),
                                        tipoCliente = dr.IsDBNull(12) ? default(string) : dr.GetString(12)
                                    },
                                    localidad = new Localidad 
                                    {
                                        idLocalidad = dr.IsDBNull(13) ? default(int) : dr.GetInt32(13),
                                        localidad = dr.IsDBNull(14) ? default(string) : dr.GetString(14)
                                    },
                                    provincia = new Provincia 
                                    {
                                        idProvincia = dr.IsDBNull(15) ? default(int) : dr.GetInt32(15),
                                        provincia = dr.IsDBNull(16) ? default(string) : dr.GetString(16)
                                    },                            
                                });
                            }
                            else 
                            {
                                lstClientes.Add(new ClienteEmpresa
                                {
                                    idCliente = dr.IsDBNull(0) ? default(int) : dr.GetInt32(0),
                                    telefono = dr.IsDBNull(1) ? default(string) : dr.GetString(1),
                                    email = dr.IsDBNull(2) ? default(string) : dr.GetString(2),
                                    direccion = dr.IsDBNull(3) ? default(string) : dr.GetString(3),
                                    codigoPostal = dr.IsDBNull(4) ? default(string) : dr.GetString(4),
                                    razonSocial = dr.IsDBNull(9) ? default(string) : dr.GetString(9),
                                    tipoCliente = new TipoCliente
                                    {
                                        idTipoCliente = dr.IsDBNull(11) ? default(int) : dr.GetInt32(11),
                                        tipoCliente = dr.IsDBNull(12) ? default(string) : dr.GetString(12)
                                    },
                                    localidad = new Localidad
                                    {
                                        idLocalidad = dr.IsDBNull(13) ? default(int) : dr.GetInt32(13),
                                        localidad = dr.IsDBNull(14) ? default(string) : dr.GetString(14)
                                    },
                                    provincia = new Provincia
                                    {
                                        idProvincia = dr.IsDBNull(15) ? default(int) : dr.GetInt32(15),
                                        provincia = dr.IsDBNull(16) ? default(string) : dr.GetString(16)
                                    },
                                    tipoEmpresa = new TipoEmpresa 
                                    {
                                        idTipoEmpresa = dr.IsDBNull(17) ? default(int) : dr.GetInt32(17),
                                        tipoEmpresa= dr.IsDBNull(18) ? default(string) : dr.GetString(18)
                                    },
                                    cuit = dr.IsDBNull(19) ? default(string) : dr.GetString(19)
                                });
                            }
                           
                        }
                    }
                    return lstClientes;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public static bool eliminarClientePorId(int idCliente)
        {
            sbSql = null;
            try
            {
                string sql = "DELETE FROM Clientes WHERE idCliente = @idCliente";
                SqlParameter[] parametros = {
                    new SqlParameter("@idCliente", idCliente)
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
        public static void actualizarCliente(Cliente oCLiente)
        {
            sbSql = null;
            try
            {
                StringBuilder sbSql = new StringBuilder("INSERT INTO Productos");
                sbSql.Append("(nombre, idMarca, precioVenta, precioCosto, descripcion, idCategoria, idProveedor, idDeposito,stockMinimo, stockMaximo, cantidadRestante,fechaVenc,fechaElab)");
                sbSql.Append("VALUES(@idMarca, @precioVenta, @precioCosto, @descripcion, @idCategoria, @idProveedor, @idDeposito, @stockMinimo,@stockMaximo, @cantidad,@fechaVenc,@fechaElab)");

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
                    new SqlParameter("@fechaVenc", oProdcuto.fechaVenc),
                    new SqlParameter("@fechaElab", oProdcuto.fechaElab)
                };

                SqlHelper.ExecuteNonQuery(cadenaConexion, CommandType.Text, sbSql.ToString(), parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static Cliente obtenerClientePorId(int idCliente)
        {

        }
    }
}
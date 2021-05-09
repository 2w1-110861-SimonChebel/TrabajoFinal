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

        public static bool verificarDniCuitExiste(string valor)
        {
            sbSql = new StringBuilder("SELECT TOP 1 idCliente FROM CLIENTES WHERE dni =@valor or cuit=@valor");

            SqlParameter[] parametros = {
                    new SqlParameter("@valor", valor)
            };

            using (SqlDataReader dr = SqlHelper.ExecuteReader(cadenaConexion, CommandType.Text, sbSql.ToString(), parametros))
            {
                return dr.HasRows;               
            }          
        }

        public static bool agregarCliente(Cliente oCliente, int tipoCliente)
        {
            sbSql = null;
            try
            {
                if (tipoCliente == 1)//tipo persona
                {
                    sbSql = new StringBuilder("INSERT INTO Clientes(idTipoCliente,telefono,email,direccion,idLocalidad,idProvincia,codigoPostal,fechaNacimiento,idSexo,nombre,apellido,dni,barrio,habilitado)");
                    sbSql.Append("VALUES(@idTipoCliente,@telefono,@email,@direccion,@idLocalidad,@idProvincia,@codigoPostal,@fechaNacimiento,@idSexo,@nombre,@apellido,@dni,@barrio,@habilitado)");

                    SqlParameter[] parametros = {
                    new SqlParameter("@idTipoCliente", oCliente.tipoCliente.idTipoCliente),
                    new SqlParameter("@telefono", oCliente.telefono),
                    new SqlParameter("@email", oCliente.email),
                    new SqlParameter("@direccion", oCliente.direccion),
                    new SqlParameter("@idLocalidad", oCliente.localidad.idLocalidad),
                    new SqlParameter("@idProvincia", oCliente.provincia.idProvincia),
                    new SqlParameter("@codigoPostal", oCliente.codigoPostal),
                    new SqlParameter("@fechaNacimiento", oCliente.fechaNacimiento),
                    new SqlParameter("@idSexo", oCliente.sexo.idSexo),
                    new SqlParameter("@nombre", oCliente.nombre),
                    new SqlParameter("@apellido", oCliente.apellido),
                    new SqlParameter("@dni", oCliente.dni),
                    new SqlParameter("@barrio", oCliente.barrio),
                    new SqlParameter("@habilitado", 1),
                    };

                    SqlHelper.ExecuteNonQuery(cadenaConexion, CommandType.Text, sbSql.ToString(), parametros);
                }
                else {
                    sbSql = new StringBuilder("INSERT INTO Clientes(idTipoCliente,telefono,email,direccion,idLocalidad,idProvincia,codigoPostal,idTipoEmpresa,razonSocial,barrio,cuit,habilitado)");
                    sbSql.Append("VALUES(@idTipoCliente,@telefono,@email,@direccion,@idLocalidad,@idProvincia,@codigoPostal,@idTipoEmpresa,@razonSocial,@barrio,@cuit,@habilitado)");
                    
                    SqlParameter[] parametros = {
                    new SqlParameter("@idTipoCliente", oCliente.tipoCliente.idTipoCliente),
                    new SqlParameter("@telefono", oCliente.telefono),
                    new SqlParameter("@email", oCliente.email),
                    new SqlParameter("@direccion", oCliente.direccion),
                    new SqlParameter("@idLocalidad", oCliente.localidad.idLocalidad),
                    new SqlParameter("@idProvincia", oCliente.provincia.idProvincia),
                    new SqlParameter("@codigoPostal", oCliente.codigoPostal),
                    new SqlParameter("@barrio", oCliente.barrio),
                    new SqlParameter("@cuit", oCliente.cuit),
                    new SqlParameter("@idTipoEmpresa", oCliente.tipoEmpresa.idTipoEmpresa),
                    new SqlParameter("@razonSocial", oCliente.razonSocial),
                    new SqlParameter("@habilitado", 1),
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

        public static Cliente obtenerClientePorId(int idCliente, int tipoCliente)
        {
            sbSql = null;
            try
            {

                SqlParameter[] parametros = {
                        new SqlParameter("@idCliente", idCliente)
                };

                if (tipoCliente == 1) //cliente tipo persona
                {
                    sbSql = new StringBuilder("SELECT c.idCliente,c.telefono,c.email,c.direccion,c.codigoPostal,c.fechaNacimiento,c.nombre,c.apellido,c.dni,c.barrio,tc.idTipoCliente, tc.tipoCliente,l.idLocalidad,l.localidad, p.idProvincia,p.provincia,dc.idDeuda,dc.monto, s.idSexo,s.sexo,c.habilitado ");

                    sbSql.Append(" FROM clientes c JOIN Tipos_Clientes tc ON c.idTipoCliente = tc.idTipoCliente ");
                    sbSql.Append(" JOIN Localidades l  ON l.idLocalidad = c.idLocalidad");
                    sbSql.Append(" JOIN Provincias p ON p.idProvincia = C.idProvincia");
                    sbSql.Append(" LEFT JOIN Sexos s on s.idSexo = c.idSexo");
                    sbSql.Append(" RIGHT JOIN Deudas_Clientes dc ON dc.idCliente = c.idCliente");
                    sbSql.Append(" WHERE c.idCliente = @idCliente");


                }
                else
                {
                    sbSql = new StringBuilder("SELECT c.idCliente,c.telefono,c.email,c.direccion,c.codigoPostal,c.razonSocial,c.barrio,tc.idTipoCliente, tc.tipoCliente,l.idLocalidad,l.localidad, p.idProvincia,p.provincia,dc.idDeuda,dc.monto,te.idTipoEmpresa,te.tipoEmpresa,c.cuit,c.habilitado ");

                    sbSql.Append(" FROM clientes c JOIN Tipos_Clientes tc ON c.idTipoCliente = tc.idTipoCliente ");
                    sbSql.Append(" JOIN Localidades l  ON l.idLocalidad = c.idLocalidad");
                    sbSql.Append(" JOIN Provincias p ON p.idProvincia = C.idProvincia");
                    sbSql.Append(" JOIN Tipos_Empresas te ON c.idTipoEmpresa = te.idTipoEmpresa");
                    sbSql.Append(" RIGHT JOIN Deudas_Clientes dc ON dc.idCliente = c.idCliente");
                    sbSql.Append(" WHERE c.idCliente = @idCliente");
                }


                using (SqlDataReader dr = SqlHelper.ExecuteReader(cadenaConexion, CommandType.Text, sbSql.ToString(), parametros))
                {
                    Cliente oCliente = null;
                    if (dr.HasRows)
                    {
                        dr.Read();

                        TipoCliente oTipoCliente = new TipoCliente();
                        Localidad oLocalidad;
                        Provincia oProvincia;
                        DeudaCliente oDeuda;
                        oCliente.idCliente = dr.IsDBNull(0) ? default(int) : dr.GetInt32(0);
                        oCliente.telefono = dr.IsDBNull(1) ? default(string) : dr.GetString(1);
                        oCliente.email = dr.IsDBNull(2) ? default(string) : dr.GetString(2);
                        oCliente.direccion = dr.IsDBNull(3) ? default(string) : dr.GetString(3);
                        oCliente.codigoPostal = dr.IsDBNull(4) ? default(string) : dr.GetString(4);

                        if (tipoCliente == 1) //cliente tipo persona 
                        {
                            oCliente = new Cliente();
                            oCliente.fechaNacimiento = dr.IsDBNull(5) ? default(DateTime) : dr.GetDateTime(5);
                            oCliente.nombre = dr.IsDBNull(6) ? default(string) : dr.GetString(6);
                            oCliente.apellido = dr.IsDBNull(7) ? default(string) : dr.GetString(7);
                            oCliente.dni = dr.IsDBNull(8) ? default(string) : dr.GetString(8);
                            oCliente.barrio = dr.IsDBNull(9) ? default(string) : dr.GetString(9);
                            oTipoCliente = new TipoCliente
                            {
                                idTipoCliente = dr.IsDBNull(10) ? default(int) : dr.GetInt32(10),
                                tipoCliente = dr.IsDBNull(11) ? default(string) : dr.GetString(11)
                            };
                            oLocalidad = new Localidad
                            {
                                idLocalidad = dr.IsDBNull(12) ? default(int) : dr.GetInt32(12),
                                localidad = dr.IsDBNull(13) ? default(string) : dr.GetString(13)
                            };
                            oProvincia = new Provincia
                            {
                                idProvincia = dr.IsDBNull(14) ? default(int) : dr.GetInt32(14),
                                provincia = dr.IsDBNull(15) ? default(string) : dr.GetString(15)
                            };
                            oDeuda = new DeudaCliente
                            {
                                idDeudaCliente = dr.IsDBNull(16) ? default(int) : dr.GetInt32(16),
                                monto = dr.IsDBNull(17) ? default(float) : dr.GetFloat(17)
                            };
                            oCliente.sexo = new Sexo
                            {
                                idSexo = dr.IsDBNull(18) ? default(int) : dr.GetInt32(18),
                                sexo = dr.IsDBNull(19) ? default(string) : dr.GetString(19),
                            };
                            oCliente.habilitado = dr.IsDBNull(20) ? default : dr.GetBoolean(20);

                        }
                        else
                        {

                            oCliente = new Cliente();
                            oCliente.razonSocial = dr.IsDBNull(5) ? default(string) : dr.GetString(5);
                            oCliente.barrio = dr.IsDBNull(6) ? default(string) : dr.GetString(6);
                            oCliente.tipoCliente = new TipoCliente
                            {
                                idTipoCliente = dr.IsDBNull(7) ? default(int) : dr.GetInt32(7),
                                tipoCliente = dr.IsDBNull(8) ? default(string) : dr.GetString(8)
                            };
                            oCliente.localidad = new Localidad
                            {
                                idLocalidad = dr.IsDBNull(9) ? default(int) : dr.GetInt32(9),
                                localidad = dr.IsDBNull(10) ? default(string) : dr.GetString(10)
                            };
                            oCliente.provincia = new Provincia
                            {
                                idProvincia = dr.IsDBNull(11) ? default(int) : dr.GetInt32(11),
                                provincia = dr.IsDBNull(12) ? default(string) : dr.GetString(12)
                            };
                            oCliente.deuda = new DeudaCliente
                            {
                                idDeudaCliente = dr.IsDBNull(13) ? default(int) : dr.GetInt32(13),
                                monto = dr.IsDBNull(14) ? default(float) : dr.GetFloat(14),
                            };
                            oCliente.tipoEmpresa = new TipoEmpresa
                            {
                                idTipoEmpresa = dr.IsDBNull(15) ? default(int) : dr.GetInt32(15),
                                tipoEmpresa = dr.IsDBNull(16) ? default(string) : dr.GetString(16)
                            };
                            oCliente.cuit = dr.IsDBNull(17) ? default(string) : dr.GetString(17);
                            oCliente.habilitado = dr.IsDBNull(18) ? default(bool) : dr.GetBoolean(18);
                        };

                    }
                    return oCliente;
                }

            }
            catch
            {
                return null;
            }
        }

        public static List<Cliente> obtenerClientes(string nombre = "", int idTipoCliente = 0)
        {
            sbSql = null;
            try
            {

                sbSql = new StringBuilder("SELECT c.idCliente,c.telefono,c.email,c.direccion,c.codigoPostal,c.fechaNacimiento,c.nombre,c.apellido,c.dni,c.razonSocial,c.barrio,tc.idTipoCliente, tc.tipoCliente,l.idLocalidad,l.localidad, p.idProvincia,p.provincia,dc.idDeuda,dc.monto, s.idSexo,s.sexo,te.idTipoEmpresa,te.tipoEmpresa,c.cuit,c.habilitado ");

                sbSql.Append(" FROM clientes c JOIN Tipos_Clientes tc ON c.idTipoCliente = tc.idTipoCliente ");
                sbSql.Append(" JOIN Localidades l  ON l.idLocalidad = c.idLocalidad");
                sbSql.Append(" JOIN Provincias p ON p.idProvincia = C.idProvincia");
                sbSql.Append(" LEFT JOIN Sexos s on s.idSexo = c.idSexo");
                sbSql.Append(" RIGHT JOIN Deudas_Clientes dc ON dc.idCliente = c.idCliente");
                sbSql.Append(" LEFT JOIN Tipos_Empresas te on te.idTipoEmpresa = c.idTipoEmpresa");
                //if (idTipoCliente > 0) sbSql.Append(string.Format("{0}{1}{2}", " WHERE c.razonSocial LIKE '%", nombre, "%'"));
                if (!string.IsNullOrEmpty(nombre))
                {
                    sbSql.Append(string.Format("{0}{1}{2}{3}{4}", " WHERE (c.nombre LIKE '%", nombre, "%' OR c.apellido LIKE '%", nombre, "%') "));
                    sbSql.Append(string.Format("{0}{1}{2}", " or (c.razonSocial LIKE '%", nombre, "%')"));
                };


                using (SqlDataReader dr = SqlHelper.ExecuteReader(cadenaConexion, CommandType.Text, sbSql.ToString()))
                {
                    List<Cliente> lstClientes = null;
                    if (dr.HasRows)
                    {
                        lstClientes = new List<Cliente>();
                        while (dr.Read())
                        {

                            lstClientes.Add(new Cliente
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
                                razonSocial = dr.IsDBNull(9) ? default(string) : dr.GetString(9),
                                barrio = dr.IsDBNull(10) ? default(string) : dr.GetString(10),
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
                                deuda = new DeudaCliente
                                {
                                    idDeudaCliente = dr.IsDBNull(17) ? default(int) : dr.GetInt32(17),
                                    monto = dr.IsDBNull(18) ? default(float) : dr.GetFloat(18),
                                },
                                sexo = new Sexo
                                {
                                    idSexo = dr.IsDBNull(19) ? default(int) : dr.GetInt32(19),
                                    sexo = dr.IsDBNull(20) ? default(string) : dr.GetString(20)
                                },
                                tipoEmpresa = new TipoEmpresa
                                {
                                    idTipoEmpresa = dr.IsDBNull(21) ? default(int) : dr.GetInt32(21),
                                    tipoEmpresa = dr.IsDBNull(22) ? default(string) : dr.GetString(22)
                                },
                                cuit = dr.IsDBNull(23) ? default(string) : dr.GetString(23),
                                habilitado = dr.IsDBNull(24) ? default(bool) : dr.GetBoolean(24)
                            });


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
        //public static void actualizarCliente(Cliente oCLiente)
        //{
        //    sbSql = null;
        //    try
        //    {
        //        StringBuilder sbSql = new StringBuilder("INSERT INTO Productos");
        //        sbSql.Append("(nombre, idMarca, precioVenta, precioCosto, descripcion, idCategoria, idProveedor, idDeposito,stockMinimo, stockMaximo, cantidadRestante,fechaVenc,fechaElab)");
        //        sbSql.Append("VALUES(@idMarca, @precioVenta, @precioCosto, @descripcion, @idCategoria, @idProveedor, @idDeposito, @stockMinimo,@stockMaximo, @cantidad,@fechaVenc,@fechaElab)");

        //        SqlParameter[] parametros = {
        //            new SqlParameter("@idProducto", oProdcuto.idProducto),
        //            new SqlParameter("@idMarca", oProdcuto.marca.idMarca),
        //            new SqlParameter("@precioVenta", oProdcuto.precioVenta),
        //            new SqlParameter("@precioCosto", oProdcuto.precioCosto),
        //            new SqlParameter("@descripcion", oProdcuto.descripcion),
        //            new SqlParameter("@idCategoria", oProdcuto.categoria.idCategoria),
        //            new SqlParameter("@idProveedor", oProdcuto.proveedor.idProveedor),
        //            new SqlParameter("@idDeposito", oProdcuto.deposito != null ? oProdcuto.deposito.idDeposito : 0),
        //            new SqlParameter("@stockMinimo", oProdcuto.stockMinimo),
        //            new SqlParameter("@stockMaximo", oProdcuto.stockMaximo),
        //            new SqlParameter("@cantidad", oProdcuto.cantidadRestante),
        //            new SqlParameter("@fechaVenc", oProdcuto.fechaVenc),
        //            new SqlParameter("@fechaElab", oProdcuto.fechaElab)
        //        };

        //        SqlHelper.ExecuteNonQuery(cadenaConexion, CommandType.Text, sbSql.ToString(), parametros);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public static Cliente obtenerClientePorId(int idCliente)
        //{

        //}
    }
}
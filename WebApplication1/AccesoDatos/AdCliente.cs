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

        public static bool verificarDniCuitExiste(string valor, int idCliente)
        {
            sbSql = new StringBuilder("SELECT TOP 1 idCliente FROM CLIENTES WHERE (dni=@valor or cuit=@valor) and idCliente <>@idCliente");

            SqlParameter[] parametros = {
                    new SqlParameter("@valor", valor),
                    new SqlParameter("@idCliente",idCliente)
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
                    sbSql = new StringBuilder("SP_AgregarClientePersona");

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

                    SqlHelper.ExecuteNonQuery(cadenaConexion, CommandType.StoredProcedure, sbSql.ToString(), parametros);
                }
                else
                {
                    sbSql.Append("SP_AgregarClienteEmpresa");
                    //sbSql = new StringBuilder("INSERT INTO Clientes(idTipoCliente,telefono,email,direccion,idLocalidad,idProvincia,codigoPostal,idTipoEmpresa,razonSocial,barrio,cuit,habilitado)");
                    //sbSql.Append("VALUES(@idTipoCliente,@telefono,@email,@direccion,@idLocalidad,@idProvincia,@codigoPostal,@idTipoEmpresa,@razonSocial,@barrio,@cuit,@habilitado)");

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

                    SqlHelper.ExecuteNonQuery(cadenaConexion, CommandType.StoredProcedure, sbSql.ToString(), parametros);
                }

            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
            return true;
        }

        public static Cliente obtenerClientePorId(int idCliente, int tipoCli)
        {
            sbSql = null;
            try
            {

                SqlParameter[] parametros = {
                        new SqlParameter("@idCliente", idCliente)
                };

                if (tipoCli == 1) //cliente tipo persona
                {
                    sbSql = new StringBuilder("SELECT c.idCliente,c.telefono,c.email,c.direccion,c.codigoPostal,c.fechaNacimiento,c.nombre,c.apellido,c.dni,c.barrio,tc.idTipoCliente, tc.tipoCliente,l.idLocalidad,l.localidad, p.idProvincia,p.provincia,dc.idDeuda,dc.monto, s.idSexo,s.sexo,c.habilitado, dc.montoAfavor ");

                    sbSql.Append(" FROM clientes c JOIN Tipos_Clientes tc ON c.idTipoCliente = tc.idTipoCliente ");
                    sbSql.Append(" JOIN Localidades l  ON l.idLocalidad = c.idLocalidad");
                    sbSql.Append(" JOIN Provincias p ON p.idProvincia = C.idProvincia");
                    sbSql.Append(" LEFT JOIN Sexos s on s.idSexo = c.idSexo");
                    sbSql.Append(" RIGHT JOIN Deudas_Clientes dc ON dc.idCliente = c.idCliente");
                    sbSql.Append(" WHERE c.idCliente = @idCliente AND c.habilitado =1");


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
                        oCliente = new Cliente();
                        oCliente.idCliente = dr.IsDBNull(0) ? default(int) : dr.GetInt32(0);
                        oCliente.telefono = dr.IsDBNull(1) ? default(string) : dr.GetString(1);
                        oCliente.email = dr.IsDBNull(2) ? default(string) : dr.GetString(2);
                        oCliente.direccion = dr.IsDBNull(3) ? default(string) : dr.GetString(3);
                        oCliente.codigoPostal = dr.IsDBNull(4) ? default(string) : dr.GetString(4);

                        if (tipoCli == 1) //cliente tipo persona 
                        {
                            
                            oCliente.fechaNacimiento = dr.IsDBNull(5) ? default(DateTime) : dr.GetDateTime(5);
                            oCliente.nombre = dr.IsDBNull(6) ? default(string) : dr.GetString(6);
                            oCliente.apellido = dr.IsDBNull(7) ? default(string) : dr.GetString(7);
                            oCliente.dni = dr.IsDBNull(8) ? default(string) : dr.GetString(8);
                            oCliente.barrio = dr.IsDBNull(9) ? default(string) : dr.GetString(9);
                            oCliente.tipoCliente = new TipoCliente
                            {
                                idTipoCliente = dr.IsDBNull(10) ? default(int) : dr.GetInt32(10),
                                tipoCliente = dr.IsDBNull(11) ? default(string) : dr.GetString(11)
                            };

                            oCliente.localidad = new Localidad
                            {
                                idLocalidad = dr.IsDBNull(12) ? default(int) : dr.GetInt32(12),
                                localidad = dr.IsDBNull(13) ? default(string) : dr.GetString(13)
                            };

                            oCliente.provincia = new Provincia
                            {
                                idProvincia = dr.IsDBNull(14) ? default(int) : dr.GetInt32(14),
                                provincia = dr.IsDBNull(15) ? default(string) : dr.GetString(15)
                            };
                            oCliente.deuda = new DeudaCliente
                            {
                                idDeudaCliente = dr.IsDBNull(16) ? default(int) : dr.GetInt32(16),
                                monto = dr.IsDBNull(17) ? default(decimal) : dr.GetDecimal(17),
                                montoAfavor= dr.IsDBNull(21) ? default(decimal) : dr.GetDecimal(21)
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
                                monto = dr.IsDBNull(14) ? default(decimal) : dr.GetDecimal(14),
                                montoAfavor = dr.IsDBNull(19) ? default(decimal) : dr.GetDecimal(19)
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
            catch(Exception ex)
            {
                return null;
                throw ex;
            }
        }

        public static List<Cliente> obtenerClientes(string nombre = "", int idTipoCliente = 0, string docu="")
        {
            sbSql = null;
            try
            {

                sbSql = new StringBuilder("SELECT c.idCliente,c.telefono,c.email,c.direccion,c.codigoPostal,c.fechaNacimiento,c.nombre,c.apellido,c.dni,c.razonSocial,c.barrio,tc.idTipoCliente, tc.tipoCliente,l.idLocalidad,l.localidad, p.idProvincia,p.provincia,dc.idDeuda,dc.monto, s.idSexo,s.sexo,te.idTipoEmpresa,te.tipoEmpresa,c.cuit,c.habilitado, dc.montoAfavor ");

                sbSql.Append(" FROM clientes c JOIN Tipos_Clientes tc ON c.idTipoCliente = tc.idTipoCliente ");
                sbSql.Append(" JOIN Localidades l  ON l.idLocalidad = c.idLocalidad");
                sbSql.Append(" JOIN Provincias p ON p.idProvincia = C.idProvincia");
                sbSql.Append(" LEFT JOIN Sexos s on s.idSexo = c.idSexo");
                sbSql.Append(" RIGHT JOIN Deudas_Clientes dc ON dc.idCliente = c.idCliente");
                sbSql.Append(" LEFT JOIN Tipos_Empresas te on te.idTipoEmpresa = c.idTipoEmpresa");
                sbSql.Append(" WHERE c.habilitado=1 ");
                //if (idTipoCliente > 0) sbSql.Append(string.Format("{0}{1}{2}", " WHERE c.razonSocial LIKE '%", nombre, "%'"));
                if (!string.IsNullOrEmpty(docu) && (nombre == "" && idTipoCliente == 0)) //es busqueda para carrito
                {
                    sbSql.Append(string.Format("{0}{1}{2}{3}{4}", " AND (c.dni = '", docu, "' OR c.cuit = '", docu, "')"));
                }
                else {
                    if (!string.IsNullOrEmpty(nombre))
                    {
                        sbSql.Append(string.Format("{0}{1}{2}{3}{4}", " AND (c.nombre LIKE '%", nombre, "%' OR c.apellido LIKE '%", nombre, "%') "));
                        sbSql.Append(string.Format("{0}{1}{2}", " or (c.razonSocial LIKE '%", nombre, "%')"));
                    };
                }
            


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
                                    monto = dr.IsDBNull(18) ? default(decimal) : dr.GetDecimal(18),
                                    montoAfavor = dr.IsDBNull(25) ? default(decimal) : dr.GetDecimal(25)
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
                string sql = "UPDATE Clientes SET habilitado = @habilitado WHERE idCliente=@idCliente";
                SqlParameter[] parametros = {
                    new SqlParameter("@habilitado", false),
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
        public static bool actualizarCliente(Cliente oCLiente, int tipoCliente)
        {
            sbSql = null;
            bool actualizo = false;
            try
            {            
                if (tipoCliente == 1)
                {
                    StringBuilder sbSql = new StringBuilder("UPDATE Clientes SET ");
                    sbSql.Append(" idTipoCliente=@idTipoCliente, telefono=@telefono, email=@email, direccion=@direccion, idLocalidad=@idLocalidad, idProvincia= @idProvincia, codigoPostal=@codigoPostal,barrio=@barrio,");
                    sbSql.Append("fechaNacimiento=@fechaNacimiento,idSexo=@idSexo,nombre=@nombre,apellido=@apellido,dni=@dni ");
                    sbSql.Append("WHERE idCliente = @idCliente");

                    SqlParameter[] parametros = {
                    new SqlParameter("@idCliente", oCLiente.idCliente),
                    new SqlParameter("@idTipoCliente",oCLiente.tipoCliente.idTipoCliente),
                    new SqlParameter("@telefono", oCLiente.telefono),
                    new SqlParameter("@email", oCLiente.email),
                    new SqlParameter("@direccion", oCLiente.direccion),
                    new SqlParameter("@idLocalidad", oCLiente.localidad.idLocalidad),
                    new SqlParameter("@idProvincia", oCLiente.provincia.idProvincia),
                    new SqlParameter("@codigoPostal", oCLiente.codigoPostal),
                    new SqlParameter("@barrio", oCLiente.barrio),
                    new SqlParameter("@fechaNacimiento", oCLiente.fechaNacimiento),
                    new SqlParameter("@idSexo", oCLiente.sexo.idSexo),
                    new SqlParameter("@nombre", oCLiente.nombre),
                    new SqlParameter("@apellido",oCLiente.apellido),
                    new SqlParameter("@dni",oCLiente.dni)
                    };

                    SqlHelper.ExecuteNonQuery(cadenaConexion, CommandType.Text, sbSql.ToString(), parametros);
                }
                if (tipoCliente == 2)
                {
                    StringBuilder sbSql = new StringBuilder("UPDATE Clientes SET ");
                    sbSql.Append(" idTipoCliente=@idTipoCliente, telefono=@telefono, email=@email, direccion=@direccion, idLocalidad=@idLocalidad, idProvincia=@idProvincia, codigoPostal=@codigoPostal, barrio=@barrio, ");
                    sbSql.Append("idTipoEmpresa=@idTipoEmpresa,razonSocial=@razonSocial,cuit=@cuit ");
                    sbSql.Append("WHERE idCliente = @idCliente");

                    SqlParameter[] parametros = {
                    new SqlParameter("@idCliente", oCLiente.idCliente),
                    new SqlParameter("@idTipoCliente",oCLiente.tipoCliente.idTipoCliente),
                    new SqlParameter("@telefono", oCLiente.telefono),
                    new SqlParameter("@email", oCLiente.email),
                    new SqlParameter("@direccion", oCLiente.direccion),
                    new SqlParameter("@idLocalidad", oCLiente.localidad.idLocalidad),
                    new SqlParameter("@idProvincia", oCLiente.provincia.idProvincia),
                    new SqlParameter("@codigoPostal", oCLiente.codigoPostal),
                    new SqlParameter("@barrio", oCLiente.barrio),
                    new SqlParameter("@idTipoEmpresa", oCLiente.tipoEmpresa.idTipoEmpresa),
                    new SqlParameter("@razonSocial", oCLiente.razonSocial),
                    new SqlParameter("@cuit", oCLiente.cuit)
                    };

                    SqlHelper.ExecuteNonQuery(cadenaConexion, CommandType.Text, sbSql.ToString(), parametros);
                }
                actualizo = true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return actualizo;
        }
    }
}
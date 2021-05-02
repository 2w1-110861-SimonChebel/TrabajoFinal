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
    public static class AdDeposito
    {
        static StringBuilder sbSql = null;
        private static readonly string cadenaConexion = System.Configuration.ConfigurationManager.ConnectionStrings["conexion"].ConnectionString.ToString();
        public static List<Sucursal> obtenerDepositos()
        {
            sbSql = null;
            try
            {
                sbSql = new StringBuilder("SELECT s.idSucursal,s.nombre,s.direccion,d.idDeposito,d.descripcion,d.completo, p.idProvincia,p.provincia,l.idLocalidad, l.localidad ");
                sbSql.Append(" FROM Sucursales s JOIN Depositos d ON s.idDeposito = d.idDeposito");
                sbSql.Append(" JOIN Localidades l ON l.idLocalidad=s.idLocalidad");
                sbSql.Append(" JOIN Provincias p ON p.idProvincia=s.idProvincia");

                using (SqlDataReader dr = SqlHelper.ExecuteReader(cadenaConexion, CommandType.Text, sbSql.ToString()))
                {
                    List<Sucursal> lstDepositos = null;
                    if (dr.HasRows)
                    {
                        lstDepositos = new List<Sucursal>();
                        while (dr.Read())
                        {
                            lstDepositos.Add(new Sucursal
                            {
                                idSucursal = dr.IsDBNull(0) ? 0 : dr.GetInt32(0),
                                nombre = dr.IsDBNull(1) ? "N/d" : dr.GetString(1),
                                direccion = dr.IsDBNull(2) ? "N/d" : dr.GetString(2),
                                deposito = new Deposito
                                {
                                    idDeposito = dr.IsDBNull(3) ? 0 : dr.GetInt32(3),
                                    descripcion = dr.IsDBNull(4) ? "N/d" : dr.GetString(4),
                                    completo = dr.IsDBNull(5) ? false : dr.GetBoolean(5)
                                },
                                provincia = new Provincia
                                {
                                    idProvincia = dr.IsDBNull(6) ? 0 : dr.GetInt32(6),
                                    provincia = dr.IsDBNull(7) ? "N/d" : dr.GetString(7)
                                },
                                localidad = new Localidad
                                {
                                    idLocalidad = dr.IsDBNull(8) ? 0 : dr.GetInt32(8),
                                    localidad = dr.IsDBNull(9) ? "N/d" : dr.GetString(9)
                                }

                            });
                        }
                    }
                    return lstDepositos;
                }
            }
            catch (Exception ex)
            {
                return null;
                throw ex;
            }
        }

        public static bool agregarDeposito(Sucursal sucursal)
        {
            sbSql = null;
            try
            {
                sbSql = new StringBuilder("SP_AgregarDeposito");

                SqlParameter[] parametros = {
                    new SqlParameter("@desc", sucursal.deposito.descripcion),
                    new SqlParameter("@completo", sucursal.deposito.completo),
                    new SqlParameter("@nombreSucu", sucursal.nombre),
                    new SqlParameter("@direSucu", sucursal.direccion),
                    new SqlParameter("@idLocalidad",sucursal.localidad.idLocalidad),
                    new SqlParameter("@idProvincia", sucursal.provincia.idProvincia),
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

        public static List<Deposito> obtenerDepositosCombo()
        {
            sbSql = null;
            try
            {
                sbSql = new StringBuilder("SELECT * FROM Depositos");

                using (SqlDataReader dr = SqlHelper.ExecuteReader(cadenaConexion, CommandType.Text, sbSql.ToString()))
                {
                    List<Deposito> lstDepositos = null;
                    if (dr.HasRows)
                    {
                        lstDepositos = new List<Deposito>();
                        while (dr.Read())
                        {
                            lstDepositos.Add(new Deposito
                            {
                                idDeposito = dr.IsDBNull(0) ? 0 : dr.GetInt32(0),
                                descripcion = dr.IsDBNull(1) ? "N/d" : dr.GetString(1),
                                completo = dr.IsDBNull(2) ? false : dr.GetBoolean(2)

                            });
                        }
                    }
                    return lstDepositos;
                }
            }
            catch (Exception ex)
            {
                return null;
                throw ex;
            }
        }

        public static Sucursal obtenerDepositoPorId(int idSucursal)
        {
            sbSql = null;
            try
            {
                sbSql = new StringBuilder("SELECT s.idSucursal,s.nombre,s.direccion,d.idDeposito,d.descripcion,d.completo, p.idProvincia,p.provincia,l.idLocalidad, l.localidad ");
                sbSql.Append(" FROM Sucursales s JOIN Depositos d ON s.idDeposito = d.idDeposito");
                sbSql.Append(" JOIN Localidades l ON l.idLocalidad=s.idLocalidad");
                sbSql.Append(" JOIN Provincias p ON p.idProvincia=s.idProvincia");
                sbSql.Append(" WHERE @idSucursal = s.idSucursal");

                SqlParameter[] param = {
                    new SqlParameter("@idSucursal",idSucursal)
                };

                using (SqlDataReader dr = SqlHelper.ExecuteReader(cadenaConexion, CommandType.Text, sbSql.ToString(),param))
                {
                    Sucursal oSucursal = null;
                    if (dr.HasRows)
                    {
                        dr.Read();
                        oSucursal = new Sucursal
                        {
                            idSucursal = dr.IsDBNull(0) ? 0 : dr.GetInt32(0),
                            nombre = dr.IsDBNull(1) ? "N/d" : dr.GetString(1),
                            direccion = dr.IsDBNull(2) ? "N/d" : dr.GetString(2),
                            deposito = new Deposito
                            {
                                idDeposito = dr.IsDBNull(3) ? 0 : dr.GetInt32(3),
                                descripcion = dr.IsDBNull(4) ? "N/d" : dr.GetString(4),
                                completo = dr.IsDBNull(5) ? false : dr.GetBoolean(5)
                            },
                            provincia = new Provincia
                            {
                                idProvincia = dr.IsDBNull(6) ? 0 : dr.GetInt32(6),
                                provincia = dr.IsDBNull(7) ? "N/d" : dr.GetString(7)
                            },
                            localidad = new Localidad
                            {
                                idLocalidad = dr.IsDBNull(8) ? 0 : dr.GetInt32(8),
                                localidad = dr.IsDBNull(9) ? "N/d" : dr.GetString(9)
                            }

                        };

                    }
                    return oSucursal;
                }
            }
            catch (Exception ex)
            {
                return null;
                throw ex;
            }
        }

        public static bool editarDeposito(Sucursal oSucursal)
        {
            sbSql = null;
            try
            {
                string sql = "SP_EditarDeposito";
                SqlParameter[] parametros = {
                    new SqlParameter("@idDeposito", oSucursal.deposito.idDeposito),
                    new SqlParameter("@desc", oSucursal.deposito.descripcion),
                    new SqlParameter("@completo", oSucursal.deposito.completo),
                    new SqlParameter("@idSucu", oSucursal.idSucursal),
                    new SqlParameter("@nombreSucu", oSucursal.nombre),
                    new SqlParameter("@dire", oSucursal.direccion),
                    new SqlParameter("@idLocalidad", oSucursal.localidad.idLocalidad),
                    new SqlParameter("@idProvincia", oSucursal.provincia.idProvincia)

                };

                SqlHelper.ExecuteNonQuery(cadenaConexion, CommandType.StoredProcedure, sql, parametros);
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
            return true;
        }

        public static bool eliminarDeposito(int idDeposito, int idSucu)
        {
            sbSql = null;
            try
            {
                string sql = "SP_EliminarDeposito";
                SqlParameter[] parametros = {
                    new SqlParameter("@idDeposito", idDeposito),
                    new SqlParameter("@idSucu",idSucu)
                };

                SqlHelper.ExecuteNonQuery(cadenaConexion, CommandType.StoredProcedure, sql, parametros);
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
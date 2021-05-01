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
                sbSql = new StringBuilder("SELECT s.idSucursal,s.nombre,s.direccion,d.descripcion,d.completo, p.idProvincia,p.provincia,l.idLocalidad, l.localidad ");
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
                                deposito = new Deposito { 
                                    descripcion = dr.IsDBNull(3) ? "N/d" : dr.GetString(3),
                                    completo = dr.IsDBNull(4) ? false : dr.GetBoolean(4)
                                },
                                provincia = new Provincia { 
                                    idProvincia = dr.IsDBNull(5) ? 0 : dr.GetInt32(5),
                                    provincia = dr.IsDBNull(6) ? "N/d" : dr.GetString(6)
                                },
                                localidad = new Localidad { 
                                    idLocalidad = dr.IsDBNull(7) ? 0 : dr.GetInt32(7),
                                    localidad = dr.IsDBNull(8) ? "N/d" : dr.GetString(8)
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
                               idDeposito = dr.IsDBNull(0) ?  0 : dr.GetInt32(0),
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
    }
}
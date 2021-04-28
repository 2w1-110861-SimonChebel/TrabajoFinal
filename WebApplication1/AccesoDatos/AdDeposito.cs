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
        public static List<Deposito> obtenerDepositos()
        {
            sbSql = null;
            try
            {
                sbSql = new StringBuilder("SELECT * FROM Depositos ORDER BY descripcion");

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
                                completo = dr.IsDBNull(2) ? false : dr.GetBoolean(2),
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
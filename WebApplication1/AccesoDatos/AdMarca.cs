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
    public static class AdMarca
    {
        static StringBuilder sbSql = null;
        private static readonly string cadenaConexion = System.Configuration.ConfigurationManager.ConnectionStrings["conexion"].ConnectionString.ToString();

        public static List<Marca> obtenerMarcas()
        {
            sbSql = null;
            try
            {
                sbSql = new StringBuilder("SELECT * FROM Marcas ORDER BY marca");

                using (SqlDataReader dr = SqlHelper.ExecuteReader(cadenaConexion, CommandType.Text, sbSql.ToString()))
                {
                    List<Marca> lstMarcas = null;
                    if (dr.HasRows)
                    {
                        lstMarcas = new List<Marca>();
                        while (dr.Read())
                        {
                            lstMarcas.Add(new Marca
                            {
                                idMarca = dr.IsDBNull(0) ? 0 : dr.GetInt32(0),
                                marca = dr.IsDBNull(1) ? "N/d" : dr.GetString(1)
                            });
                        }
                    }
                    return lstMarcas;
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
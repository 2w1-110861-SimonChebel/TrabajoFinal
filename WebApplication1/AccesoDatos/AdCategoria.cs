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
    public static class AdCategoria
    {
        static StringBuilder sbSql = null;
        private static readonly string cadenaConexion = System.Configuration.ConfigurationManager.ConnectionStrings["conexion"].ConnectionString.ToString();

        public static List<Categoria> obtenerCategorias()
        {
            sbSql = null;
            try
            {
                sbSql = new StringBuilder("SELECT * FROM Categorias ORDER BY nombre");

                using (SqlDataReader dr = SqlHelper.ExecuteReader(cadenaConexion, CommandType.Text, sbSql.ToString()))
                {
                    List<Categoria> lstCategorias = null;
                    if (dr.HasRows)
                    {
                        lstCategorias = new List<Categoria>();
                        while (dr.Read())
                        {
                            lstCategorias.Add(new Categoria
                            {
                                idCategoria = dr.IsDBNull(0) ? 0 : dr.GetInt32(0),
                                nombre = dr.IsDBNull(1) ? "N/d" : dr.GetString(1),
                                descripcion = dr.IsDBNull(2) ? "N/d" : dr.GetString(2),
                            });
                        }
                    }
                    return lstCategorias;
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
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
    public static class AdProveedor
    {
        static StringBuilder sbSql = null;
        private static readonly string cadenaConexion = System.Configuration.ConfigurationManager.ConnectionStrings["conexion"].ConnectionString.ToString();

        public static List<Proveedor> obtenerProveedoresSimple()
        {
            sbSql = null;
            try
            {
                sbSql = new StringBuilder("SELECT idProveedor, nombre FROM Proveedores ORDER BY nombre");

                using (SqlDataReader dr = SqlHelper.ExecuteReader(cadenaConexion, CommandType.Text, sbSql.ToString()))
                {
                    List<Proveedor> lstProveedores = null;
                    if (dr.HasRows)
                    {
                        lstProveedores = new List<Proveedor>();
                        while (dr.Read())
                        {
                            lstProveedores.Add(new Proveedor
                            {
                                idProveedor = dr.IsDBNull(0) ? 0 : dr.GetInt32(0),
                                nombre = dr.IsDBNull(1) ? "N/d" : dr.GetString(1)
                            });
                        }
                    }
                    return lstProveedores;
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
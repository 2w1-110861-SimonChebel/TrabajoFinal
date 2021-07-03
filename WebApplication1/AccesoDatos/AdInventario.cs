using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Easy_Stock.Entidades;
using InventarioP = Easy_Stock.Entidades.Inventario;

namespace Easy_Stock.AccesoDatos
{
    public static class AdInventario
    {
        static StringBuilder sbSql = null;
        private static readonly string cadenaConexion = System.Configuration.ConfigurationManager.ConnectionStrings["conexion"].ConnectionString.ToString();

        public static List<InventarioP> ObtenerInventario()
        {
            sbSql = null;
            List<InventarioP> resultado = null;

            try
            {
                sbSql = new StringBuilder("SELECT inv.idInventario, p.idProducto, p.codigo, p.nombre,ep.idEstado, ep.estado,p.fechaIngreso ");
                sbSql.Append(" FROM Productos p JOIN Inventario inv ON p.idProducto = inv.idProducto JOIN Estados_Productos ep ON inv.idEstado = ep.idEstado  ");
                sbSql.Append(" ORDER BY nombre ");

                using (SqlDataReader dr = SqlHelper.ExecuteReader(cadenaConexion, CommandType.Text, sbSql.ToString()))
                {
                    if (dr.HasRows)
                    {
                        resultado = new List<InventarioP>();

                        while (dr.Read())
                        {
                            resultado.Add(
                                new InventarioP
                                { 
                                    idInventario = dr.IsDBNull(0) ? 0 : dr.GetInt32(0),
                                    producto = new Producto
                                    {
                                        idProducto = dr.IsDBNull(1) ? 0 : dr.GetInt32(1),
                                        codigo = dr.IsDBNull(2) ? string.Empty : dr.GetString(2),
                                        nombre = dr.IsDBNull(3) ? string.Empty : dr.GetString(3),                   
                                        fechaIngreso = dr.IsDBNull(6) ? default : dr.GetDateTime(6)
                                    },
                                    estado = new EstadoProducto {
                                        idEstadoProducto = dr.IsDBNull(4) ? 0 : dr.GetInt32(4),
                                        estadoProducto = dr.IsDBNull(5) ? string.Empty : dr.GetString(5),
                                    }
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
    }
}
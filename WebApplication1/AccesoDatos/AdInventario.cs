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

        public static List<InventarioP> ObtenerInventario(string codigoUnico = "",string codigoProducto="",int idEstado=0,DateTime fechaInicio=default,DateTime fechaFin=default,string nombre = "")
        {
            sbSql = null;
            bool hayFiltroAnterior = false;
            List<SqlParameter> parametros = new List<SqlParameter>();
            List<InventarioP> resultado = null;

            try
            {
                sbSql = new StringBuilder("SELECT inv.idInventario, p.idProducto, p.codigo, p.nombre,ep.idEstado, ep.estado,p.fechaIngreso ");
                sbSql.Append(" FROM Productos p JOIN Inventario inv ON p.idProducto = inv.idProducto JOIN Estados_Productos ep ON inv.idEstado = ep.idEstado ");

                if (!string.IsNullOrEmpty(codigoUnico) || !string.IsNullOrEmpty(codigoProducto) || idEstado > 0 || fechaInicio != default || fechaFin != default || !string.IsNullOrEmpty(nombre))
                {
                    sbSql.Append(" WHERE ");

                    if (!string.IsNullOrEmpty(codigoUnico))
                    {
                        string[] aux = codigoUnico.Split('-');

                        parametros.Add(new SqlParameter("@idInventario", aux[0]));
                        parametros.Add(new SqlParameter("@codigo",aux[1]));

                        sbSql.Append(" inv.idInventario = @idInventario AND inv.codigo = @codigo ");
                        hayFiltroAnterior = true;
                    }

                    if (!string.IsNullOrEmpty(codigoProducto))
                    {
                        parametros.Add(new SqlParameter("@codigo", codigoProducto));

                        if (hayFiltroAnterior) { sbSql.Append(" AND inv.codigo = @codigo "); }
                        else 
                        { 
                            sbSql.Append(" inv.codigo = @codigo ");
                            hayFiltroAnterior = true;

                        }
                    }

                    if (idEstado > 0)
                    {
                        parametros.Add(new SqlParameter("@idEstado", idEstado));

                        if (hayFiltroAnterior) { sbSql.Append(" AND inv.idEstado = @idEstado "); }
                        else
                        { 
                            sbSql.Append(" inv.idEstado = @idEstado ");
                            hayFiltroAnterior = true;
                        }
                    }

                    if (fechaInicio != default)
                    {
                        parametros.Add(new SqlParameter("@fechaInicio", fechaInicio));

                        if (hayFiltroAnterior) { sbSql.Append(" AND p.fechaIngreso >= @fechaInicio "); }
                        else 
                        {
                            sbSql.Append(" p.fechaIngreso >= @fechaInicio ");
                            hayFiltroAnterior = true;
                        }
                    }


                    if (fechaFin != default)
                    {
                        parametros.Add(new SqlParameter("@fechaFin", fechaFin));

                        if (hayFiltroAnterior) { sbSql.Append(" AND p.fechaIngreso <= @fechaFin "); }
                        else 
                        { 
                            sbSql.Append(" p.fechaIngreso <= @fechaFin ");
                            hayFiltroAnterior = true; 
                        }
                    }

                    if (!string.IsNullOrEmpty(nombre))
                    {
                        parametros.Add(new SqlParameter("@nombre",nombre));

                        if (hayFiltroAnterior) { sbSql.Append(" AND p.nombre LIKE '%@nombre%' "); }
                        else
                        {
                            sbSql.Append(" p.nombre LIKE '%@nombre%' ");
                            hayFiltroAnterior = true;
                        }
                    }


                }

                sbSql.Append(" ORDER BY p.nombre ");

                using (SqlDataReader dr = SqlHelper.ExecuteReader(cadenaConexion, CommandType.Text, sbSql.ToString(),parametros.ToArray()))
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
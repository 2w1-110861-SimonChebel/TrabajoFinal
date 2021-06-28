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

        public static List<Categoria> ObtenerCategorias(string nombre = "", int id=0)
        {
            sbSql = null;
            try
            {
                bool hayFiltroAnterior = false;
                sbSql = new StringBuilder("SELECT * FROM Categorias ");
                if (!string.IsNullOrEmpty(nombre))
                {
                    sbSql.Append(string.Format(" WHERE nombre like '%{0}%' ", nombre));
                    hayFiltroAnterior = true;
                }
                if (id > 0)
                {
                    if (hayFiltroAnterior)
                    {
                        sbSql.Append(string.Format(" AND idCategoria= {0} ", id.ToString()));
                    }
                    else { sbSql.Append(string.Format(" WHERE idCategoria= {0} ", id.ToString())); }
                }
                if (hayFiltroAnterior) { sbSql.Append(" AND estado=1 "); }
                else { sbSql.Append("WHERE estado = 1"); }

                sbSql.Append(" ORDER BY nombre ");
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

        public static bool ActualizarCategoria(int id, string nombre, string desc)
        {
            sbSql = null;

            try
            {
                sbSql = new StringBuilder("UPDATE Categorias SET nombre = @nombre, descripcion = @desc WHERE idCategoria = @id");
                SqlParameter[] parametros = new SqlParameter[]{
                    new SqlParameter("@nombre",nombre),
                    new SqlParameter("@desc", desc),
                    new SqlParameter("@id",id)

                };
                SqlHelper.ExecuteNonQuery(cadenaConexion, CommandType.Text, sbSql.ToString(), parametros);
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw;
            }

        }

        public static bool AgregarCategoria(Categoria oCategoria)
        {
            sbSql = null;
            try
            {
                sbSql = new StringBuilder(string.Format("INSERT INTO Categorias (nombre, descripcion,estado) VALUES('{0}','{1}','{2}')",oCategoria.nombre, oCategoria.descripcion, oCategoria.estado ? "1" : "0"));
                SqlHelper.ExecuteNonQuery(cadenaConexion, CommandType.Text, sbSql.ToString());
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }

            return true;
        }

        public static bool EliminarCategoria(int id)
        {
            sbSql = null;
            try
            {
                sbSql = new StringBuilder(string.Format("UPDATE Categorias SET estado ='{0}' WHERE idCategoria = {1}","0", id));
                SqlHelper.ExecuteNonQuery(cadenaConexion, CommandType.Text, sbSql.ToString());
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
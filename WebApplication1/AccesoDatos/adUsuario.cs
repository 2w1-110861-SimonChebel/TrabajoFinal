using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Easy_Stock.Entidades;

namespace Easy_Stock.AccesoDatos
{
    public static class AdUsuario
    {
        static StringBuilder sbSql = null;
        private static readonly string cadenaConexion = System.Configuration.ConfigurationManager.ConnectionStrings["conexion"].ConnectionString.ToString();

        public static List<Usuario> ObtenerUsuarios(string email = "", string clave = "", int idUsuario = 0, string nombre = "")
        {
            sbSql = null;
            try
            {
                List<Usuario> lstUsuarios = null;
                SqlDataReader dr = null;
                sbSql = new StringBuilder("SELECT u.idUsuario,u.nombre,u.apellido,u.email,u.clave,tu.idTipoUsuario, tu.tipoUsuario ");
                sbSql.Append("FROM Usuarios u  JOIN Tipos_Usuarios tu ON u.idTipoUsuario = tu.idTipoUsuario ");
                if (!string.IsNullOrEmpty(nombre))
                {
                    sbSql.Append(" WHERE nombre LIKE '%@nombre%' OR apellido LIKE '%@nombre%'");
                    SqlParameter[] param = {
                        new SqlParameter("@nombre",nombre)
                        };
                    dr = SqlHelper.ExecuteReader(cadenaConexion, CommandType.Text, sbSql.ToString(), param);
                }
                else
                {
                    if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(clave) && idUsuario == 0)
                    {
                        sbSql.Append("WHERE email = @email and clave =@clave ");
                        SqlParameter[] param = {
                        new SqlParameter("@email",email),
                        new SqlParameter("@clave", clave)

                        };
                        dr = SqlHelper.ExecuteReader(cadenaConexion, CommandType.Text, sbSql.ToString(), param);
                    }
                    else
                    {
                        if (idUsuario > 0)
                        {
                            sbSql.Append(" WHERE idUsuario = @idUsuario ");
                            SqlParameter[] param = {
                            new SqlParameter("@idUsuario",idUsuario)
                        };
                            dr = SqlHelper.ExecuteReader(cadenaConexion, CommandType.Text, sbSql.ToString(), param);
                        }
                        else { dr = SqlHelper.ExecuteReader(cadenaConexion, CommandType.Text, sbSql.ToString()); }
                    }
                }


                using (dr)
                {
                    if (dr.HasRows)
                    {
                        lstUsuarios = new List<Usuario>();
                        while (dr.Read())
                        {
                            lstUsuarios.Add(new Usuario
                            {
                                idUsuario = dr.IsDBNull(0) ? default(int) : dr.GetInt32(0),
                                nombre = dr.IsDBNull(1) ? default(string) : dr.GetString(1),
                                apellido = dr.IsDBNull(2) ? default(string) : dr.GetString(2),
                                email = dr.IsDBNull(3) ? default(string) : dr.GetString(3),
                                clave = dr.IsDBNull(4) ? default(string) : dr.GetString(4),
                                tipoUsuario = new TipoUsuario
                                {
                                    idTipoUsuario = dr.IsDBNull(5) ? default(int) : dr.GetInt32(5),
                                    tipoUsuario = dr.IsDBNull(4) ? default(string) : dr.GetString(6)
                                }

                            });
                        }

                    }
                    return lstUsuarios;
                }

            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        public static bool actualizarUsuario(Usuario oUsuario)
        {
            sbSql = null;
            try
            {
                sbSql = new StringBuilder("UPDATE Usuarios SET ");
                sbSql.Append(" nombre = @nombre, apellido=@apellido, idTipoUsuario=@idTipo,email=@email,clave=@clave ");
                sbSql.Append(" WHERE idUsuario =@idUsuario");

                SqlParameter[] param = {
                    new SqlParameter("@idUsuario",oUsuario.idUsuario),
                    new SqlParameter("@nombre",oUsuario.nombre),
                    new SqlParameter("@apellido",oUsuario.apellido),
                    new SqlParameter("@email",oUsuario.email),
                    new SqlParameter("@clave",oUsuario.clave),
                    new SqlParameter("@idTipo",oUsuario.tipoUsuario.idTipoUsuario),

                };

                SqlHelper.ExecuteNonQuery(cadenaConexion, CommandType.Text, sbSql.ToString(), param);
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }

        }

        public static List<TipoUsuario> obtenerTiposUsuario()
        {
            try
            {
                sbSql = new StringBuilder("SELECT * FROM Tipos_Usuarios");
                using (SqlDataReader dr = SqlHelper.ExecuteReader(cadenaConexion, CommandType.Text, sbSql.ToString()))
                {
                    List<TipoUsuario> lstTipos = null;
                    if (dr.HasRows)
                    {
                        lstTipos = new List<TipoUsuario>();
                        while (dr.Read())
                        {
                            lstTipos.Add(new TipoUsuario
                            {
                                idTipoUsuario = dr.IsDBNull(0) ? default(int) : dr.GetInt32(0),
                                tipoUsuario = dr.IsDBNull(1) ? default(string) : dr.GetString(1)
                            });
                        }

                    }
                    return lstTipos;
                }

            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        public static bool agregarUsuario(Usuario oUsuario)
        {
            sbSql = null;
            try
            {
                sbSql = new StringBuilder("INSERT INTO Usuarios(nombre,apellido,idTipoUsuario,email,clave)");
                sbSql.Append(" VALUES(@nombre,@apellido,@idTipo,@email,@clave)");

                SqlParameter[] parametros = {
                    new SqlParameter("@nombre", oUsuario.nombre),
                    new SqlParameter("@apellido", oUsuario.apellido),
                    new SqlParameter("@idTipo", oUsuario.tipoUsuario.idTipoUsuario),
                    new SqlParameter("@email", oUsuario.email),
                    new SqlParameter("@clave",oUsuario.clave),
                };

                SqlHelper.ExecuteNonQuery(cadenaConexion, CommandType.Text, sbSql.ToString(), parametros);
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
            return true;
        }

        public static bool eliminarUsuario(int idUsuario)
        {
            sbSql = null;

            try
            {
                sbSql = new StringBuilder("DELETE FROM Usuarios WHERE idUsuario = @id");
                SqlParameter[] parametros = {
                    new SqlParameter("@id",idUsuario)
                };
                SqlHelper.ExecuteNonQuery(cadenaConexion, CommandType.Text, sbSql.ToString(), parametros);
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
            return true;
        }

        public static bool VerificarEmailExiste(string email)
        {
            sbSql = new StringBuilder("SELECT TOP 1 idUsuario FROM Usuarios WHERE (email=@email)");

            SqlParameter[] parametros = {
                    new SqlParameter("@email", email),
            };

            using (SqlDataReader dr = SqlHelper.ExecuteReader(cadenaConexion, CommandType.Text, sbSql.ToString(), parametros))
            {
                return dr.HasRows;
            }
        }

    }
}
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

        public static Usuario ObtenerUsuario(string email, string clave)
        {
            try
            {
                sbSql = new StringBuilder("SELECT u.idUsuario,u.nombre,u.apellido,u.email,u.clave,tu.idTipoUsuario, tu.tipoUsuario ");
                sbSql.Append("FROM Usuarios u  JOIN Tipos_Usuarios tu ON u.idTipoUsuario = tu.idTipoUsuario ");
                sbSql.Append("WHERE email = @email and clave =@clave ");
                SqlParameter[] param = {
                    new SqlParameter("@email",email),
                    new SqlParameter("@clave", clave)
                    
                };
                using (SqlDataReader dr = SqlHelper.ExecuteReader(cadenaConexion, CommandType.Text, sbSql.ToString(), param))
                {
                    if (dr.HasRows)
                    {
                        dr.Read();
                        return new Usuario
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

                        };
                    }
                    return null;
                }

            }
            catch (SqlException ex )
            {

                throw ex;
            }
        }
    }
}
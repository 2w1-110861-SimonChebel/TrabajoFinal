using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;
using Easy_Stock.Entidades;

namespace Easy_Stock.AccesoDatos
{
    public static class AdCliente
    {
        static StringBuilder sbSql = null;
        private static readonly string cadenaConexion = System.Configuration.ConfigurationManager.ConnectionStrings["conexion"].ConnectionString.ToString();

        public static Cliente obtenerClientePorId(int idCliente)
        {
            
        }
    }
}
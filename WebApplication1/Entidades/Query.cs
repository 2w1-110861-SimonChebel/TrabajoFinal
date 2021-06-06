using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Easy_Stock.Entidades
{
    public class Query
    {
        public string comando { get; set; } = string.Empty;
        public SqlParameter[] parametros { get; set; } = null;

        public Query()
        {
            
        }
    }
}
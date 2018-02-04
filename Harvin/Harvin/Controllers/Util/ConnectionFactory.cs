using Dapper;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace Harvin.Controllers.Util
{
    public class ConnectionFactory
    {
        internal static IEnumerable<T> Query<T>(string sql, object param = null)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Entities"].ConnectionString))
            {
                conn.Open();
                return conn.Query<T>(sql, param);
            }
        }

        internal static int Execute(string sql, object param = null)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Entities"].ConnectionString))
            {
                conn.Open();
                return conn.Execute(sql, param);
            }
        }
    }
}
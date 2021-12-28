using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hau.GUI.DAO
{
    public class DBConnection
    {
        public DBConnection() { }
        public SqlConnection CreateConnection()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=DESKTOP-7FIQ32C\SQLEXPRESS;Initial Catalog=sale;User Id=sa;Password=sa";
            return conn;
        }
    }
}

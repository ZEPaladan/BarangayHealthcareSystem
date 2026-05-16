using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarangayHealthcareSystem
{
    public class DatabaseConnection
    {
        private readonly string connectionString =
            @"Data Source=.\SQLEXPRESS;
              Initial Catalog=BHSdb;
              User ID=sa;
              Password=admin";

        public SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}

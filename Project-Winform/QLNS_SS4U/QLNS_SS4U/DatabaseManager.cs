using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNS_SS4U
{
    internal class DatabaseManager
    {
        private static string connectionString;

        public static void SetConnectionString(string dataSource, string initialCatalog, bool integratedSecurity)
        {
            // Tạo chuỗi kết nối từ thông tin cung cấp
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = dataSource;
            builder.InitialCatalog = initialCatalog;
            builder.IntegratedSecurity = integratedSecurity;

            // Thiết lập chuỗi kết nối
            connectionString = builder.ToString();
        }

        public static SqlConnection GetSqlConnection()
        {
            // Tạo và trả về một đối tượng SqlConnection từ chuỗi kết nối
            SqlConnection connection = new SqlConnection(connectionString);
            return connection;
        }
    }
}

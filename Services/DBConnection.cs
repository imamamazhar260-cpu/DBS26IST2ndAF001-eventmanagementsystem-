using System.Data.SqlClient;

namespace eventmanagementsystem.Services
{
    class DBConnection
    {
        public static SqlConnection GetConnection()
        {
            SqlConnection con =
            new SqlConnection(
            "Data Source=PC\\SQLEXPRESS01;Initial Catalog=eventmanagementsystem;Integrated Security=True");

            return con;
        }
    }
}
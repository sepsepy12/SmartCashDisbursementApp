using MySql.Data.MySqlClient;

namespace SmartCashDisbursementApp
{
    public class DatabaseHelper
    {
        // Adjust username/password to match your MariaDB root/user setup
        private static string connectionString =
            "server=localhost;port=3306;database=smart_cash_db;user=root;password=Mangao.20;";

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }
    }
}
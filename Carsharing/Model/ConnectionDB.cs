using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carsharing.Model
{
    class ConnectionDB
    {
        private ConnectionDB() { }

        private static string connectionString = "server=localhost;user=root;password=root;database=carsharing";

        public static MySqlConnection getConnection()
        {
            return new MySqlConnection(connectionString);
        }

    }
}

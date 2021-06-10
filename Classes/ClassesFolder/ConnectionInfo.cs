using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesFolder
{
    public static class ConnectionInfo
    {
        private static string _connectionString;
        //@"server=localhost;userid=root;password=1234;database=project_db"
        public static string ConnectionString
        {
            get { return _connectionString; }
            set { _connectionString = value; }
        }

        public static bool CheckConnection()
        {
            bool result = false;
            MySqlConnection connection = new MySqlConnection(ConnectionString);
            try
            {
                connection.Open();
                result = true;
                connection.Close();
            }
            catch
            {
                result = false;
            }

            return result;
        }
    }
}
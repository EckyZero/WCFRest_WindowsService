using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestWCFServiceLibrary.Repos
{
    class DatabaseConnection : IDatabaseConnection
    {
        private const string databaseName = "MyDatabase.sqlite";

        public void CreateDatabase()
        {
            if (!System.IO.File.Exists(databaseName))
            {
                SQLiteConnection.CreateFile(databaseName);
            }
        }

        public SQLiteConnection GetDatabaseConnection()
        {
            var connection = new SQLiteConnection("Data Source=" + databaseName + "; Version=3;");

            return connection;
        }

        public bool TableExists(string tableName)
        {
            using (var connection = GetDatabaseConnection())
            {
                connection.Open();

                var sql = "SELECT name FROM sqlite_master WHERE type='table' AND name='" + tableName + "'";
                var command = new SQLiteCommand(sql, connection);
                var reader = command.ExecuteReader();
                var exists = reader.HasRows;

                return exists;
            }
        }
    }
}

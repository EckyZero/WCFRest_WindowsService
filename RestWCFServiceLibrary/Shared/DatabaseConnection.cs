using System.Data.SQLite;

namespace RestWCFServiceLibrary.Repos
{
    internal class DatabaseConnection : IDatabaseConnection
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
                using (var command = new SQLiteCommand(sql, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        var exists = reader.HasRows;

                        return exists;
                    }
                }
            }
        }
    }
}

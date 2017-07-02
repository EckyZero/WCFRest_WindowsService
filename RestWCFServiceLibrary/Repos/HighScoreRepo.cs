using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestWCFServiceLibrary.Repos
{
    class HighScoreRepo : IHighScoreRepo
    {
        IDatabaseConnection _dbConnection;
        const string _tableName = "highscores";

        public HighScoreRepo(IDatabaseConSnection dbConnection)
        {
            _dbConnection = dbConnection;

            CreateTableIfNeeded();
        }

        public void Insert(string name, int score)
        {
            using (var connection = _dbConnection.GetDatabaseConnection())
            {
                connection.Open();

                var sql = "insert into " + _tableName + " (name, score) values ('" + name + "', " + score + ")";
                var command = new SQLiteCommand(sql, connection);
                // TODO: Locks - why?
                command.ExecuteNonQuery();
            }
        }

        private void CreateTableIfNeeded()
        {
            if (!_dbConnection.TableExists(_tableName))
            {
                using (var connection = _dbConnection.GetDatabaseConnection())
                {
                    connection.Open();

                    var sql = "CREATE TABLE " + _tableName + " (name VARCHAR(20), score INT)";
                    var command = new SQLiteCommand(sql, connection);
  
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}

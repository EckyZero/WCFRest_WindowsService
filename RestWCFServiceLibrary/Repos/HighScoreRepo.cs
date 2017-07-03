using RestWCFServiceLibrary.Models;
using System.Collections.Generic;
using System.Data.SQLite;

namespace RestWCFServiceLibrary.Repos
{
    class HighScoreRepo : IHighScoreRepo
    {
        IDatabaseConnection _dbConnection;
        const string _tableName = "highscores";

        public HighScoreRepo(IDatabaseConnection dbConnection)
        {
            _dbConnection = dbConnection;

            CreateTableIfNeeded();
        }

        public void Create(HighScore highscore)
        {
            using (var connection = _dbConnection.GetDatabaseConnection())
            {
                connection.Open();

                var sql = "insert into " + _tableName + " (name, score) values ('" + highscore.Name + "', " + highscore.Score + ")";
                var command = new SQLiteCommand(sql, connection);
                // TODO: Locks - why?
                command.ExecuteNonQuery();

                connection.Dispose();
            }
        }

        public HighScore Read(int id)
        {
            HighScore highscore = null;

            using (var connection = _dbConnection.GetDatabaseConnection())
            {
                connection.Open();

                var sql = "select * from " + _tableName + "  where score = " + id;
                var command = new SQLiteCommand(sql, connection);

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var name = reader["name"].ToString();
                    var score = int.Parse(reader["score"].ToString());

                    highscore = new HighScore(name, score);
                }
                connection.Dispose();
            }

            return highscore;
        }

        public IEnumerable<HighScore> ReadAll()
        {
            List<HighScore> highscores = new List<HighScore>();

            using (var connection = _dbConnection.GetDatabaseConnection())
            {
                connection.Open();

                var sql = "select * from " + _tableName;
                var command = new SQLiteCommand(sql, connection);

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var name = reader["name"].ToString();
                    var score = int.Parse(reader["score"].ToString());
                    var highscore = new HighScore(name, score);

                    highscores.Add(highscore);
                }
                connection.Dispose();
            }

            return highscores;
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

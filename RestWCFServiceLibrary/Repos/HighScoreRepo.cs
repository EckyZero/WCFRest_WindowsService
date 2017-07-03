using RestWCFServiceLibrary.Models;
using System.Collections.Generic;
using System.Data.SQLite;

namespace RestWCFServiceLibrary.Repos
{
    class HighScoreRepo : IHighScoreRepo
    {
        IDatabaseConnection _dbConnection;
        const string _tableName = "highscores";

        internal HighScoreRepo(IDatabaseConnection dbConnection)
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
                using (var command = new SQLiteCommand(sql, connection))
                {
                    // TODO: Locks - why?
                    command.ExecuteNonQuery();
                }
            }
        }

        public HighScore Read(int id)
        {
            HighScore highscore = null;

            using (var connection = _dbConnection.GetDatabaseConnection())
            {
                connection.Open();

                var sql = "select * from " + _tableName + "  where score = " + id;
                using (var command = new SQLiteCommand(sql, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var name = reader["name"].ToString();
                            var score = int.Parse(reader["score"].ToString());

                            highscore = new HighScore(name, score);
                        }
                    }
                }
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
                using (var command = new SQLiteCommand(sql, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var name = reader["name"].ToString();
                            var score = int.Parse(reader["score"].ToString());
                            var highscore = new HighScore(name, score);

                            highscores.Add(highscore);
                        }
                    }
                }
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
                    using (var command = new SQLiteCommand(sql, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}

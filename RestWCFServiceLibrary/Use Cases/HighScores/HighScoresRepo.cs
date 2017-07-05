using RestWCFServiceLibrary.Repos;
using RestWCFServiceLibrary.Use_Cases.HighScores.Interfaces;
using RestWCFServiceLibrary.Use_Cases.HighScores.Models;
using System.Collections.Generic;
using System.Data.SQLite;

namespace RestWCFServiceLibrary.Use_Cases.HighScores
{
    class HighScoresRepo : IHighScoresRepo
    {
        IDatabase _database;
        const string _tableName = "highscores";

        public HighScoresRepo(IDatabase database)
        {
            _database = database;

            CreateTableIfNeeded();
        }

        public void Create(HighScore highscore)
        {
            using (var connection = _database.GetConnection())
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

            using (var connection = _database.GetConnection())
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

        public IList<HighScore> ReadAll()
        {
            List<HighScore> highscores = new List<HighScore>();

            using (var connection = _database.GetConnection())
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

        public void Delete(int id)
        {
            using (var connection = _database.GetConnection())
            {
                connection.Open();

                var sql = "delete from " + _tableName + " where score = " + id;
                using (var command = new SQLiteCommand(sql, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        private void CreateTableIfNeeded()
        {
            if (!_database.TableExists(_tableName))
            {
                using (var connection = _database.GetConnection())
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

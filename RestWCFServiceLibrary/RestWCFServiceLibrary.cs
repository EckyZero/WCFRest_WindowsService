using System;
using System.Data.SQLite;

namespace RestWCFServiceLibrary
{
    public class RestWCFServiceLibrary : IRestWCFServiceLibrary
    {


        public RestWCFServiceLibrary()
        {
            Console.WriteLine("");
        }

        public string XMLData(string id)
        {
            return Data(id);
        }
        public string JSONData(string id)
        {
            return Data(id);
        }

        private string Data(string id)
        {
            SQLiteConnection m_dbConnection;
            string sql;
            SQLiteCommand command;

            if (!System.IO.File.Exists("MyDatabase.sqlite"))
            {
                SQLiteConnection.CreateFile("MyDatabase.sqlite");

                m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
                m_dbConnection.Open();

                sql = "create table highscores (name varchar(20), score int)";

                command = new SQLiteCommand(sql, m_dbConnection);
                command.ExecuteNonQuery();

                sql = "insert into highscores (name, score) values ('Me', 9001)";
                command = new SQLiteCommand(sql, m_dbConnection);
                command.ExecuteNonQuery();

            }
            else
            {
                m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
                m_dbConnection.Open();
            }

            sql = "select * from highscores";
            command = new SQLiteCommand(sql, m_dbConnection);

            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                var name = reader["name"];
                var score = reader["score"];
                Console.WriteLine("Name: " + name + "\tScore: " + score);
            }
                

            return "HWLLO";
        }
    }
}
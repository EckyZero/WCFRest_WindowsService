using RestWCFServiceLibrary.Use_Cases.HighScores.Interfaces;
using RestWCFServiceLibrary.Use_Cases.HighScores.Models;
using System.Collections.Generic;
using LiteDB;
using System.Linq;
using System;

namespace RestWCFServiceLibrary.Use_Cases.HighScores
{
    class HighScoresRepo : IHighScoresRepo
    {
        const string _tableName = "highscores";

        public HighScoresRepo()
        {

        }

        public void Create(HighScore highscore)
        {
            var collection = Application.Database.GetCollection<HighScore>();

            highscore.Id = 0;

            collection.Insert(highscore);
        }

        public HighScore Read(int id)
        {
            var collection = Application.Database.GetCollection<HighScore>();
            var highscore = collection.FindById(id);

            return highscore;
        }

        public IList<HighScore> ReadAll()
        {
            var collection = Application.Database.GetCollection<HighScore>();
            var highscores = collection.Find(_ => true).ToList();

            return highscores;
        }

        public void Delete(int id)
        {
            var collection = Application.Database.GetCollection<HighScore>();

            collection.Delete(id);
        }
    }
}

using RestWCFServiceLibrary.Use_Cases.HighScores.Interfaces;
using RestWCFServiceLibrary.Use_Cases.HighScores.Models;
using System.Collections.Generic;

namespace RestWCFServiceLibrary.Use_Cases.HighScores
{
    internal class HighScoresService : IHighScoresService
    {
        private IHighScoresRepo _highscoreRepo;

        public HighScoresService(IHighScoresRepo highscoreRepo)
        {
            _highscoreRepo = highscoreRepo;
        }

        public void Create(HighScore highscore)
        {
            _highscoreRepo.Create(highscore);
        }

        public void Delete(int id)
        {
            _highscoreRepo.Delete(id);
        }

        public HighScore Read(int id)
        {
            var highscore = _highscoreRepo.Read(id);

            return highscore;
        }

        public IList<HighScore> ReadAll()
        {
            var highscores = _highscoreRepo.ReadAll();

            return highscores;
        }
    }
}

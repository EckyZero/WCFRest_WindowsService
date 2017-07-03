using RestWCFServiceLibrary.Repos;
using RestWCFServiceLibrary.Use_Cases.HighScores.Interfaces;
using RestWCFServiceLibrary.Use_Cases.HighScores.Models;
using System.Collections.Generic;

namespace RestWCFServiceLibrary.Use_Cases.HighScores
{
    public class HighScoreController : IHighScoreController
    {
        private IHighScoreService _highscoreService;

        private HighScoreController()
        {
            // TODO: Replace this once DI is setup
            var database = new DatabaseConnection();
            var highscoreRepo = new HighScoreRepo(database);

            _highscoreService = new HighScoreService(highscoreRepo);
        }

        public IEnumerable<HighScore> GetAll()
        {
            var highscores = _highscoreService.ReadAll();

            return highscores;
        }

        public HighScore Get(string id)
        {
            // TODO: Input validation here
            var formattedId = int.Parse(id);
            var highscores = _highscoreService.Read(formattedId);

            return highscores;
        }

        public void Post(HighScore highscore)
        {
            _highscoreService.Create(highscore);
        }

        public void Delete(string id)
        {
            // TODO: Input validation here
            var formattedId = int.Parse(id);

            _highscoreService.Delete(formattedId);
        }
    }
}
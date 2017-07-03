using RestWCFServiceLibrary.Repos;
using RestWCFServiceLibrary.Use_Cases.HighScores.Interfaces;
using RestWCFServiceLibrary.Use_Cases.HighScores.Models;
using System.Collections.Generic;

namespace RestWCFServiceLibrary.Use_Cases.HighScores
{
    public class HighScoresController : IHighScoresController
    {
        private IHighScoresService _highscoreService;

        private HighScoresController()
        {
            // TODO: Replace this once DI is setup
            var database = new DatabaseConnection();
            var highscoreRepo = new HighScoresRepo(database);

            _highscoreService = new HighScoresService(highscoreRepo);
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
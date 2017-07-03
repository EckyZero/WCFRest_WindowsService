using RestWCFServiceLibrary.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestWCFServiceLibrary.Models;
using RestWCFServiceLibrary.Services;

namespace RestWCFServiceLibrary.Controllers
{
    public class HighScoreController : IHighScoreController
    {
        private IHighScoreService _highscoreService;

        private HighScoreController(IHighScoreService highscoreService)
        {
            _highscoreService = highscoreService;
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
    }
}

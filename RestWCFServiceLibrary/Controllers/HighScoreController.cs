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
    class HighScoreController : IHighScoreController
    {
        private IHighScoreService _highscoreService;

        public HighScoreController(IHighScoreService highscoreService)
        {
            _highscoreService = highscoreService;
        }

        public IEnumerable<HighScore> GetAll()
        {
            var highscores = _highscoreService.ReadAll();

            return highscores;
        }

        public HighScore Get(int id)
        {
            var highscores = _highscoreService.Read(id);

            return highscores;
        }

        public void Post(HighScore highscore)
        {
            _highscoreService.Create(highscore);
        }
    }
}

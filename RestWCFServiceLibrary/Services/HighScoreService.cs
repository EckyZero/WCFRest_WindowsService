using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestWCFServiceLibrary.Models;
using RestWCFServiceLibrary.Repos;

namespace RestWCFServiceLibrary.Services
{
    class HighScoreService : IHighScoreService
    {
        private IHighScoreRepo _highscoreRepo;

        public HighScoreService(IHighScoreRepo highscoreRepo)
        {
            _highscoreRepo = highscoreRepo;
        }

        public void Create(HighScore highscore)
        {
            _highscoreRepo.Create(highscore);
        }

        public HighScore Read(int id)
        {
            var highscore = _highscoreRepo.Read(id);

            return highscore;
        }

        public IEnumerable<HighScore> ReadAll()
        {
            var highscores = _highscoreRepo.ReadAll();

            return highscores;
        }
    }
}

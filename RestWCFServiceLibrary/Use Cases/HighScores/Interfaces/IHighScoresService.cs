using RestWCFServiceLibrary.Use_Cases.HighScores.Models;
using System.Collections.Generic;

namespace RestWCFServiceLibrary.Use_Cases.HighScores.Interfaces
{
    internal interface IHighScoresService
    {
        void Create(HighScore highscore);

        HighScore Read(int id);

        IEnumerable<HighScore> ReadAll();

        void Delete(int id);
    }
}

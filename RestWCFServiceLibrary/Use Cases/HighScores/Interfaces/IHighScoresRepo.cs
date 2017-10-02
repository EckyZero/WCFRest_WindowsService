using RestWCFServiceLibrary.Use_Cases.HighScores.Models;
using System.Collections.Generic;

namespace RestWCFServiceLibrary.Use_Cases.HighScores.Interfaces
{
    public interface IHighScoresRepo
    {
        void Create(HighScore highscore);

        HighScore Read(int id);

        IList<HighScore> ReadAll();

        void Delete(int id);
    }
}

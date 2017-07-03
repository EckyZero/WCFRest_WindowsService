using RestWCFServiceLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestWCFServiceLibrary.Services
{
    internal interface IHighScoreService
    {
        void Create(HighScore highscore);

        HighScore Read(int id);

        IEnumerable<HighScore> ReadAll();

        void Delete(int id);
    }
}

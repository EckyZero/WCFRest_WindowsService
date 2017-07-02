using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestWCFServiceLibrary.Repos
{
    interface IHighScoreRepo
    {
        void Insert(string name, int score);
    }
}

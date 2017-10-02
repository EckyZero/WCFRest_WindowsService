using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestWCFServiceLibrary.Repos
{
    public interface IDatabase
    {
        void CreateDatabase();

        SQLiteConnection GetConnection();

        bool TableExists(string tableName);
    }
}

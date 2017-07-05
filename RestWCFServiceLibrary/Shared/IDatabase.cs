using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestWCFServiceLibrary.Repos
{
    public interface IDatabaseConnection
    {
        void CreateDatabase();

        SQLiteConnection GetDatabaseConnection();

        bool TableExists(string tableName);
    }
}

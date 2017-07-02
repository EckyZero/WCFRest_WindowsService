using Autofac;
using RestWCFServiceLibrary.Repos;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestWCFServiceLibrary
{
    public static class Application
    {
        public static void Startup()
        {
            var container = SetupIoC();

            SetupDatabase(container);
        }

        public static void Destroy()
        {

        }

        private static IContainer SetupIoC()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<DatabaseConnection>().As<IDatabaseConnection>();
            builder.RegisterType<HighScoreRepo>().As<IHighScoreRepo>();

            var container = builder.Build();

            return container;
        }

        private static void SetupDatabase(IContainer container)
        {
            using (var scope = container.BeginLifetimeScope())
            {
                var databaseConnection = scope.Resolve<IDatabaseConnection>();
                var highscoreRepo = scope.Resolve<IHighScoreRepo>();

                databaseConnection.CreateDatabase();
                highscoreRepo.Insert("Erik", 1000);
            }
        }
    }
}

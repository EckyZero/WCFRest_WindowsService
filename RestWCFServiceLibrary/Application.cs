using Autofac;
using RestWCFServiceLibrary.Repos;
using RestWCFServiceLibrary.Use_Cases.HighScores;
using RestWCFServiceLibrary.Use_Cases.HighScores.Interfaces;

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
            builder.RegisterType<HighScoresRepo>().As<IHighScoresRepo>();

            var container = builder.Build();

            return container;
        }

        private static void SetupDatabase(IContainer container)
        {
            using (var scope = container.BeginLifetimeScope())
            {
                var databaseConnection = scope.Resolve<IDatabaseConnection>();

                databaseConnection.CreateDatabase();
            }
        }
    }
}

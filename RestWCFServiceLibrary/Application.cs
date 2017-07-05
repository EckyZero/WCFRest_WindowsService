using Autofac;
using RestWCFServiceLibrary.Repos;
using RestWCFServiceLibrary.Use_Cases.HighScores;
using RestWCFServiceLibrary.Use_Cases.HighScores.Interfaces;
using RestWCFServiceLibrary.Use_Cases.Teachers;
using RestWCFServiceLibrary.Use_Cases.Teachers.Interfaces;

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

            builder.RegisterType<Database>().As<IDatabase>();
            builder.RegisterType<HighScoresRepo>().As<IHighScoresRepo>();
            builder.RegisterType<HighScoresService>().As<IHighScoresService>();
            builder.RegisterType<HighScoresController>().As<IHighScoresController>();
            builder.RegisterType<TeachersController>().As<ITeachersController>();

            var container = builder.Build();

            return container;
        }

        private static void SetupDatabase(IContainer container)
        {
            using (var scope = container.BeginLifetimeScope())
            {
                var databaseConnection = scope.Resolve<IDatabase>();

                databaseConnection.CreateDatabase();
            }
        }
    }
}

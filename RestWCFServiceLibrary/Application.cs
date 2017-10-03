using Autofac;
using LiteDB;
using RestWCFServiceLibrary.Use_Cases.HighScores;
using RestWCFServiceLibrary.Use_Cases.HighScores.Interfaces;
using RestWCFServiceLibrary.Use_Cases.Teachers;
using RestWCFServiceLibrary.Use_Cases.Teachers.Interfaces;
using System;

namespace RestWCFServiceLibrary
{
    public static class Application
    {
        private static LiteDatabase _database;

        public static LiteDatabase Database
        {
            get
            {
                return _database;
            }
        }

        public static void Startup()
        {
            var container = SetupIoC();

            SetupIoC();
            SetupDatabase();
        }

        public static void Destroy()
        {

        }

        private static IContainer SetupIoC()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<HighScoresRepo>().As<IHighScoresRepo>();
            builder.RegisterType<HighScoresService>().As<IHighScoresService>();
            builder.RegisterType<HighScoresController>().As<IHighScoresController>();
            builder.RegisterType<TeachersController>().As<ITeachersController>();

            var container = builder.Build();

            return container;
        }

        private static void SetupDatabase()
        {
            _database = new LiteDatabase("WcfRestfulWithWindowsHostDemo.db");
        }
    }
}

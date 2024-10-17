using Autofac;
using CsvAccess.core.Actions.Checkout;
using CsvAccess.core.Configuration;
using CsvAccess.core.Configuration.Credentials;
using CsvAccess.core.DependencyInjection;
using CsvAccess.core.Models.Data.Columns;
using CsvAccess.core.Models.Persistence;
using CsvAccess.core.Session;
using PostgreSqlWrapper;
using PostgreSqlWrapper.Connection;
using PostgreSqlWrapper.DependencyInjection;
using System;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SetupServices();
            var postgresConnectionService = Services.Resolve<ConnectionService>();
            var credentialsService = Services.Resolve<CredentialsService>();
            var configService = Services.Resolve<PathService>();

            //Setup db session
            string path = configService.GetCredentialsPath(DatabaseSystem.PostgreSql);
            var credentials = credentialsService.GetCredentials(path);
            var postgresConnectionOptions = PostgresConnectionOptions.Create(credentials);
            IPostgresConnectionResult result = postgresConnectionService.Connect(postgresConnectionOptions);
            DatabaseSession session = result.Session;

            var sessionService = Services.Resolve<SessionService>();
            sessionService.RegisterDatabaseSession(session);

            //action
            var checkoutService = Services.Resolve<CheckoutService>();
            checkoutService.CheckoutTable("testtable", @"C:\Users\geert\Documents\Projects\csvDatabaseAccess");
        }

        private static void SetupServices()
        {
            var builder = new ContainerBuilder();
            builder.RegisterPostgresServices();
            builder.RegisterCoreServices();

            Services.Container = builder.Build();
        }
    }
}

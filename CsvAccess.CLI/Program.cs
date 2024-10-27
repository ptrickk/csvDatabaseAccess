using Autofac;
using CsvAccess.CLI.IO;
using CsvAccess.CLI.Services.Action;
using CsvAccess.CLI.Services.Setup;
using CsvAccess.core.Actions.Checkin;
using CsvAccess.core.Configuration;
using CsvAccess.core.Configuration.Credentials;
using CsvAccess.core.DependencyInjection;
using CsvAccess.core.Models.Persistence;
using CsvAccess.core.Session;
using PostgreSqlWrapper.Connection;
using PostgreSqlWrapper.DependencyInjection;
using Action = CsvAccess.core.Actions.Action;

namespace CsvAccess.CLI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                //start interactive
            }
            else
            {
                var command = new Command(args);
                SetupServices(command.DatabaseSystem).Show();

                var actionResolver = new ActionServiceResolver();
                Action action = actionResolver.GetActionFromCommand(command.CommandName);
                
                //execute action
                action.Execute(command.CommandArguments);
            }
        }

        private static Display SetupServices(string databaseSystem)
        {
            try
            {
                ServiceSetup serviceSetup = GetSystemFromArgs(databaseSystem);
                serviceSetup.RegisterServices();
                serviceSetup.Build();
                serviceSetup.Connect();

                return Information.Create("Database connection established!");
            }
            catch (ArgumentException ex)
            {
                return Error.Create(ex.Message);
            }
        }

        private static ServiceSetup GetSystemFromArgs(string databaseSystem)
        {
            var postgresIdentifier = new List<string> { "pg", "postgres" };

            if (postgresIdentifier.Contains(databaseSystem))
            {
                return new PostgresServiceSetup();
            }

            throw new ArgumentException($"Unknown database identifier: {databaseSystem}");
        }

        private static void SetupServices()
        {
            var builder = new ContainerBuilder();
            builder.RegisterPostgresServices();
            builder.RegisterCoreServices();

            core.DependencyInjection.Services.Container = builder.Build();
        }

        //hack
        public void testMethod()
        {
            SetupServices();
            var postgresConnectionService = core.DependencyInjection.Services.Resolve<ConnectionService>();
            var credentialsService = core.DependencyInjection.Services.Resolve<CredentialsService>();
            var configService = core.DependencyInjection.Services.Resolve<PathService>();

            //Setup db session
            string path = configService.GetCredentialsPath(DatabaseSystem.PostgreSql);
            var credentials = credentialsService.GetCredentials(path);
            var postgresConnectionOptions = PostgresConnectionOptions.Create(credentials);
            IPostgresConnectionResult result = postgresConnectionService.Connect(postgresConnectionOptions);
            DatabaseSession session = result.Session;

            var sessionService = core.DependencyInjection.Services.Resolve<SessionService>();
            sessionService.RegisterDatabaseSession(session);

            //action
            //var checkoutService = Services.Resolve<CheckoutAction>();
            //checkoutService.CheckoutTable("testtable", @"C:\Users\geert\Documents\Projects\csvDatabaseAccess");

            var checkingService = core.DependencyInjection.Services.Resolve<CheckinAction>();
            checkingService.CheckinTable(@"C:\Users\geert\Documents\Projects\csvDatabaseAccess\testtable.csv");
        }

    }
}

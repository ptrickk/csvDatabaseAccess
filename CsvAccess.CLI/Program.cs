using Autofac;
using CsvAccess.CLI.IO;
using CsvAccess.CLI.Services.Action;
using CsvAccess.CLI.Services.Setup;
using CsvAccess.core.Actions;
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
        /// commands:
        /// pg checkout testtable C:\Users\geert\Documents\oktay
        /// pg config

        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                //start interactive
            }
            else
            {
                var command = new Command(args);
                var actionResolver = new ActionServiceResolver();
                
                ServiceSetup serviceSetup = GetSystemFromArgs(command.DatabaseSystem);
                serviceSetup.RegisterServices();
                serviceSetup.Build();
                
                Action action = actionResolver.GetActionFromCommand(command.CommandName);

                if (action.ConnectionReliant)
                {
                    Display connectionDisplay = serviceSetup.Connect();
                    connectionDisplay.Show();
                    if (!connectionDisplay.Continue)
                    {
                        return;
                    }
                }

                //execute action
                ActionResult result = action.Execute(command.CommandArguments);
                if (!result.Success)
                {
                    Error.CreateStop(result.Message).Show();
                }
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
    }
}

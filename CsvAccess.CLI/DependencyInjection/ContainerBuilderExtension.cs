using Autofac;
using CsvAccess.CLI.Actions.Credentials;
using CsvAccess.core.Actions.Credentials;

namespace CsvAccess.CLI.DependencyInjection;


public static class ContainerBuilderExtension
{
    public static void RegisterCommandLineServices(this ContainerBuilder builder)
    {
        builder.RegisterType<CommandLineCredentialsAction>().As<CredentialsAction>();
    }
}

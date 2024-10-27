using Autofac;
using CsvAccess.CLI.DependencyInjection;
using CsvAccess.core.DependencyInjection;
using CsvAccess.core.Models.Persistence;

namespace CsvAccess.CLI.Services.Setup;

public class BaseServiceSetup : ServiceSetup
{
    protected ContainerBuilder? Builder;

    public DatabaseSystem DatabaseSystem { get; } = DatabaseSystem.Unknown;

    public virtual void RegisterServices()
    {
        Builder = new ContainerBuilder();
        Builder.RegisterCoreServices();
        Builder.RegisterCommandLineServices();
    }

    public void Build()
    {
        if (Builder == null)
        {
            RegisterServices();
        }

        core.DependencyInjection.Services.Container = Builder!.Build();
    }

    public virtual void Connect()
    {
        throw new NotImplementedException();
    }
}
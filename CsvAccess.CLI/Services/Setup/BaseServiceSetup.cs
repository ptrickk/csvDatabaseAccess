using Autofac;
using CsvAccess.CLI.DependencyInjection;
using CsvAccess.CLI.IO;
using CsvAccess.core.DependencyInjection;
using CsvAccess.core.Persistence;

namespace CsvAccess.CLI.Services.Setup;

public class BaseServiceSetup : ServiceSetup
{
    protected ContainerBuilder? Builder;

    public DatabaseStrategy DatabaseStrategy { get; }

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

    public virtual Display Connect()
    {
        throw new NotImplementedException();
    }
}
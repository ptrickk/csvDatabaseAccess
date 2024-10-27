using CsvAccess.core.Models.Persistence;

namespace CsvAccess.CLI.Services.Setup;

public interface ServiceSetup
{
    DatabaseSystem DatabaseSystem { get; }

    void RegisterServices();

    void Build();

    void Connect();
}
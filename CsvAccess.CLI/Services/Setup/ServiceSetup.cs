using CsvAccess.CLI.IO;
using CsvAccess.core.Persistence;

namespace CsvAccess.CLI.Services.Setup;

public interface ServiceSetup
{
    DatabaseStrategy DatabaseStrategy { get; }

    void RegisterServices();

    void Build();

    Display Connect();
}
using CsvAccess.CLI.IO;
using CsvAccess.core.Configuration.Credentials;
using CsvAccess.core.Configuration;
using CsvAccess.core.Session;
using PostgreSqlWrapper.Connection;
using PostgreSqlWrapper.DependencyInjection;
using CsvAccess.core.Persistence;
using PostgreSqlWrapper;

namespace CsvAccess.CLI.Services.Setup;

public class PostgresServiceSetup : BaseServiceSetup
{
    public override void RegisterServices()
    {
        base.RegisterServices();

        Builder.RegisterPostgresServices();
    }

    public override Display Connect()
    {
        var postgresConnectionService = core.DependencyInjection.Services.Resolve<ConnectionService>();
        var credentialsService = core.DependencyInjection.Services.Resolve<CredentialsService>();
        var configService = core.DependencyInjection.Services.Resolve<PathService>();

        //Setup db session
        string path = configService.GetCredentialsPath(new PostgresStrategy());
        var credentials = credentialsService.GetCredentials(path);
        var postgresConnectionOptions = PostgresConnectionOptions.Create(credentials);
        IPostgresConnectionResult result = postgresConnectionService.Connect(postgresConnectionOptions);
        if (!result.Succeeded)
        {
            return Error.CreateStop(result.Message);
        }
        
        DatabaseSession session = result.Session;

        var sessionService = core.DependencyInjection.Services.Resolve<SessionService>();
        sessionService.RegisterDatabaseSession(session);

        return Information.Create("Database connection established!");
    }
}
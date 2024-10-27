using CsvAccess.core.Configuration.Credentials;
using CsvAccess.core.Configuration;
using CsvAccess.core.Models.Persistence;
using CsvAccess.core.Session;
using PostgreSqlWrapper.Connection;
using PostgreSqlWrapper.DependencyInjection;

namespace CsvAccess.CLI.Services.Setup;

public class PostgresServiceSetup : BaseServiceSetup
{
    public new DatabaseSystem DatabaseSystem { get; } = DatabaseSystem.PostgreSql;

    public override void RegisterServices()
    {
        base.RegisterServices();

        Builder.RegisterPostgresServices();
    }

    public override void Connect()
    {
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
    }
}
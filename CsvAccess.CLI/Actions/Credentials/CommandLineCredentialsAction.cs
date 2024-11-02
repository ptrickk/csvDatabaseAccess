using CsvAccess.CLI.File.Open;
using CsvAccess.core.Actions;
using CsvAccess.core.Actions.Credentials;
using CsvAccess.core.Configuration.Credentials;
using CsvAccess.core.Encryption;
using CsvAccess.core.Models.Persistence;

namespace CsvAccess.CLI.Actions.Credentials;

//TODO implement
public class CommandLineCredentialsAction : CredentialsAction
{
    private readonly EncryptionService _encryptionService;

    public CommandLineCredentialsAction(EncryptionService encryptionService)
    {
        _encryptionService = encryptionService;
    }

    public bool DatabaseReliant => false;

    public ActionResult Execute(string[] arguments)
    {
        if (arguments.Length == 0)
        {
            //base profile
            var connectionService = core.DependencyInjection.Services.Resolve<ConnectionService>();
            return OpenCredentials(connectionService.DatabaseSystem);
        }
        if (arguments.Length == 1)
        {
            //special settings
        }
        throw new ArgumentException("Invalid number of arguments passed for credential action.");
    }

    public ActionResult OpenCredentials(DatabaseSystem database, string profile = "")
    {
        var pathService = core.DependencyInjection.Services.Resolve<PathService>();
        string path = pathService.GetCredentialsPath(database);
        var fileOpener = new FileOpener(_encryptionService);

        return fileOpener.Open(path);
    }
}
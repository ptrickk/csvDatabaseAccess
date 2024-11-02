using CsvAccess.core.Persistence;

namespace CsvAccess.core.Actions.Credentials;

public interface CredentialsAction : Action
{
    public ActionResult OpenCredentials(DatabaseStrategy database, string profile);
}
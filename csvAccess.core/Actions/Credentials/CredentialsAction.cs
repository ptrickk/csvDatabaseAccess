using CsvAccess.core.Models.Persistence;

namespace CsvAccess.core.Actions.Credentials;

public interface CredentialsAction : Action
{
    public ActionResult OpenCredentials(DatabaseSystem database, string profile);
}
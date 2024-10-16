namespace CsvAccess.core.Configuration
{
    public interface CredentialsService
    {
        public Models.Persistence.Credentials GetCredentials(string filepath);
    }
}

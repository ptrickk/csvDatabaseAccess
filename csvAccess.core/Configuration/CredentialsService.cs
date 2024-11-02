namespace CsvAccess.core.Configuration
{
    public interface CredentialsService
    {
        public Persistence.Credentials GetCredentials(string filepath);
    }
}

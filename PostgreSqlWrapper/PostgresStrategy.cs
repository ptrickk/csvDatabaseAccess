using CsvAccess.core.Persistence;

namespace PostgreSqlWrapper;

public class PostgresStrategy : DatabaseStrategy
{
    private const string DEFAULT_CONFIG_FILE = "postgres.cred";
    private static readonly string CONFIG_TEMPLATE = Resource.ConfigFileTemplate;

    public string GetCredentialsFile(string profileName = "")
    {
        if (profileName.Equals(string.Empty))
        {
            return DEFAULT_CONFIG_FILE;
        }
        return $"{profileName}.cred";
    }

    public void WriteConfigTemplateToFile(string path)
    {
        File.WriteAllText(path, CONFIG_TEMPLATE);
    }
}
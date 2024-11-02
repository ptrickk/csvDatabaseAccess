namespace CsvAccess.core.Persistence;

public interface DatabaseStrategy
{
    public string GetCredentialsFile(string profileName = "");

    public void WriteConfigTemplateToFile(string path);
}
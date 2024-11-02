namespace CsvAccess.core.Encryption;

public interface EncryptionService
{
    public void TryEncrypt(string path);

    public void TryDecrypt(string path);
    public string ContentOfEncryptedFile(string path);
}
namespace CsvAccess.core.Encryption
{
    internal class CoreEncryptionService : EncryptionService
    {
        public void TryEncrypt(string path)
        {
            try
            {
                File.Encrypt(path);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public void TryDecrypt(string path)
        {
            try
            {
                File.Decrypt(path);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public string ContentOfEncryptedFile(string path)
        {
            TryDecrypt(path);
            string content = File.ReadAllText(path);
            TryEncrypt(path);
            return content;
        }
    }
}

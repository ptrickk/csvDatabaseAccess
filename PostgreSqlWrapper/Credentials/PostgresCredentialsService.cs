using CsvAccess.core.Configuration;
using CsvAccess.core.Encryption;
using CsvAccess.core.Persistence;
using PostgreSqlWrapper;

namespace CsvAccess.core.Credentials
{
    internal class PostgresCredentialsService : CredentialsService
    {
        private readonly EncryptionService _encryptionService;

        public PostgresCredentialsService(EncryptionService encryptionService)
        {
            _encryptionService = encryptionService;
        }

        public Persistence.Credentials GetCredentials(string filepath)
        {
            if (!File.Exists(filepath))
            {
                throw new FileNotFoundException(filepath);
            }

            string fileOutput = _encryptionService.ContentOfEncryptedFile(filepath);
            var extractedCredentials = ExtractCredentialsFromOutput(fileOutput);

            return GetCredentialsFromExtraction(extractedCredentials);
        }

        private const string PASSWORD_KEY = "pwd";
        private const string USERNAME_KEY = "user";
        private const string HOST_KEY = "host";
        private const string PORT_KEY = "port";
        private const string DATABASE_KEY = "db";
        private const string SCHEMA_KEY = "schema";

        private Dictionary<string, string> ExtractCredentialsFromOutput(string fileOutput)
        {
            Dictionary<string, string> valueByCredentials = new Dictionary<string, string>();
            string[] fileLines = fileOutput.Split('\n');

            foreach (string line in fileLines)
            {
                string[] split = line.Split('=');
                if (split.Length != 2) continue;

                string key = split[0].Trim();
                string value = split[1].Trim();

                if (string.IsNullOrEmpty(value))
                {
                    continue;
                }

                switch (key)
                {
                    case PASSWORD_KEY:
                    case USERNAME_KEY:
                    case HOST_KEY:
                    case PORT_KEY:
                    case DATABASE_KEY:
                    case SCHEMA_KEY:
                        valueByCredentials.Add(key, value);break;
                }
            }
            return valueByCredentials;
        }

        private PostgresCredentials GetCredentialsFromExtraction(Dictionary<string, string> extraction)
        {
            return new PostgresCredentials()
            {
                Password = extraction.GetValueOrDefault(PASSWORD_KEY),
                Username = extraction.GetValueOrDefault(USERNAME_KEY),
                Host = extraction.GetValueOrDefault(HOST_KEY),
                Port = extraction.GetValueOrDefault(PORT_KEY),
                Database = extraction.GetValueOrDefault(DATABASE_KEY),
                Schema = extraction.GetValueOrDefault(SCHEMA_KEY)
            };
        }
    }
}

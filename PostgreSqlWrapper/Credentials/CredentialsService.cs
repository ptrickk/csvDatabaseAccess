using CsvAccess.core.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvAccess.core.Credentials
{
    internal class CredentialsService : ICredentialsService
    {
        public ICredentials GetCredentials(string filepath)
        {
            if (!File.Exists(filepath))
            {
                throw new FileNotFoundException(filepath);
            }

            string fileOutput = File.ReadAllText(filepath);
            var extractedCredentials = ExtractCredentialsFromOutput(fileOutput);

            return GetCredentialsFromExtraction(extractedCredentials);
        }

        private const string PASSWORD_KEY = "pwd";
        private const string USERNAME_KEY = "user";
        private const string HOST_KEY = "host";
        private const string PORT_KEY = "port";
        private const string DATABASE_KEY = "db";

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

                switch (key)
                {
                    case PASSWORD_KEY:
                    case USERNAME_KEY:
                    case HOST_KEY:
                    case PORT_KEY:
                    case DATABASE_KEY:
                        valueByCredentials.Add(key, value);break;
                    default:
                        break;
                        
                }
            }
            return valueByCredentials;
        }

        private PostgreSqlWrapper.Credentials GetCredentialsFromExtraction(Dictionary<string, string> extraction)
        {
            return new PostgreSqlWrapper.Credentials()
            {
                Password = extraction[PASSWORD_KEY],
                Username = extraction[USERNAME_KEY],
                Host = extraction[HOST_KEY],
                Port = extraction[PORT_KEY],
                Database = extraction[DATABASE_KEY],
            };
        }
    }
}

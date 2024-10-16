using CsvAccess.core.Models.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvAccess.core.Configuration.Credentials
{
    internal class CorePathService : PathService
    {
        private const string APP_FOLDER_NAME = "CSV Access";
        private const string CONFIG_FOLDER_NAME = "config";
        private const string CHECKSUM_FOLDER_NAME = "check";

        private const string POSTGRES_SAVEFILE = "postgres.cred";

        private string _configDestination;

        public CorePathService()
        {
            AssureConfig();
        }

        public void AssureConfig()
        {
            string appDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            _configDestination = Path.Combine(appDataFolder, APP_FOLDER_NAME, CONFIG_FOLDER_NAME);

            Directory.CreateDirectory(_configDestination);
        }

        public string GetCredentialsPath(DatabaseSystem database)
        {
            string credentialsPath = Path.Combine(_configDestination, GetFileByDatabase(database));
            if (!File.Exists(credentialsPath))
            {
                File.Create(credentialsPath).Close();
            }
            return credentialsPath;
        }

        private string GetFileByDatabase(DatabaseSystem database)
        {
            switch (database)
            {
                case DatabaseSystem.PostgreSql:
                    return POSTGRES_SAVEFILE;
            }
            throw new ArgumentException();
        }
    }
}

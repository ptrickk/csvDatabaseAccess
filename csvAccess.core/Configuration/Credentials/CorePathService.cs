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
        private const string APP_FOLDER_NAME = "csvAccess";
        private const string CONFIG_FOLDER_NAME = "config";
        private const string CHECKSUM_FOLDER_NAME = "check";
        private const string TRACE_FOLDER_NAME = "trace";
        private const string COPY_FOLDER_NAME = "copy";
        private const string MAPPING_FOLDER_NAME = "map";

        private const string POSTGRES_SAVEFILE = "postgres.cred";

        private string _configDestination;
        private string _checksumDestination;
        private string _traceDestination;
        private string _copyDestination;
        private string _mappingDestination;

        public CorePathService()
        {
            AssureConfig();
        }

        public void AssureConfig()
        {
            string appDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            _configDestination = Path.Combine(appDataFolder, APP_FOLDER_NAME, CONFIG_FOLDER_NAME);
            _checksumDestination = Path.Combine(appDataFolder, APP_FOLDER_NAME, CHECKSUM_FOLDER_NAME);
            _copyDestination = Path.Combine(appDataFolder, APP_FOLDER_NAME, COPY_FOLDER_NAME);
            _mappingDestination = Path.Combine(appDataFolder, APP_FOLDER_NAME, MAPPING_FOLDER_NAME);

            Directory.CreateDirectory(_configDestination);
            Directory.CreateDirectory(_checksumDestination);
            Directory.CreateDirectory(_copyDestination);
            Directory.CreateDirectory(_mappingDestination);
        }

        public string GetChecksumPath(string tableName)
        {
            string fileName = $"{tableName}.sum";
            string checksumPath = Path.Combine(_checksumDestination, fileName);
            return GetPath(checksumPath);
        }

        public string GetCredentialsPath(DatabaseSystem database)
        {
            string credentialsPath = Path.Combine(_configDestination, GetFileByDatabase(database));
            return GetPath(credentialsPath);
        }

        private string GetPath(string destination)
        {
            if (!File.Exists(destination))
            {
                File.Create(destination).Close();
            }
            return destination;
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

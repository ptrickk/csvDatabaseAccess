using CsvAccess.core.Configuration.Credentials;
using CsvAccess.core.Models.Data.Table;
using CsvAccess.core.Table.Data.Checksum.Calculate;

namespace CsvAccess.core.Table.Data.Checksum
{
    internal class CoreChecksumService : ChecksumService
    {
        private DataTableChecksumConverter _checksumConverter;
        private PathService _pathService;

        public CoreChecksumService(PathService pathService)
        {
            _pathService = pathService;
            _checksumConverter = new DataTableChecksumConverter();
        }

        public string CreateChecksum(IDataTable dataTable)
        {
            return _checksumConverter.GetChecksums(dataTable);
        }

        public string GetChecksumByTableName(string tableName)
        {
            string path = _pathService.GetChecksumPath(tableName);

            if (!File.Exists(path))
            {
                return string.Empty;
            }

            return File.ReadAllText(path);
        }
    }
}

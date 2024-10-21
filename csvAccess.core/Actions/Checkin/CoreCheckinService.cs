using CsvAccess.core.Models.Data.Table;
using CsvAccess.core.Models.Persistence;
using CsvAccess.core.Session;
using CsvAccess.core.Table.Data.Checksum;
using CsvAccess.core.Table.Data.Csv.Convert;
using System.Text.RegularExpressions;

namespace CsvAccess.core.Actions.Checkin
{
    internal class CoreCheckinService : CheckinService
    {
        private SessionService _sessionService;
        private TableCsvService _tableCsvService;
        private ChecksumService _checksumService;

        public CoreCheckinService(SessionService sessionService, TableCsvService tableCsvService, ChecksumService checksumService)
        {
            _sessionService = sessionService;
            _tableCsvService = tableCsvService;
            _checksumService = checksumService;
        }

        public CheckinResult CheckinTable(string path)
        {
            DatabaseSession database = _sessionService.DatabaseSession;

            string csv = File.ReadAllText(path);

            IDataTable dataTable = _tableCsvService.FromCsv(csv);

            string checksums = TryGetChecksums(path);


            throw new NotImplementedException();
        }

        private string TryGetChecksums(string path)
        {
            Match fileName = Regex.Match(path, @"(/|\\)\w+(\.csv)");
            if (fileName.Success)
            {
                string tableName = Regex.Replace(fileName.Value, @"(/|\\|.csv)", string.Empty);

                return _checksumService.GetChecksumByTableName(tableName);
            }

            return string.Empty;
        }
    }
}

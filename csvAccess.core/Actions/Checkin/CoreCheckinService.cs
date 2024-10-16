using CsvAccess.core.Models.Data.Table;
using CsvAccess.core.Models.Persistence;
using CsvAccess.core.Session;
using CsvAccess.core.Table.Data.Checksum;
using CsvAccess.core.Table.Data.Csv.Convert;

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

        public void CheckinTable(string path)
        {
            DatabaseSession database = _sessionService.DatabaseSession;

            IDataTable dataTable = _tableCsvService.FromCsv(path);

            throw new NotImplementedException();
        }
    }
}

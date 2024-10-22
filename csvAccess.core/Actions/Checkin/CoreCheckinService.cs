using CsvAccess.core.Configuration.Credentials;
using CsvAccess.core.DependencyInjection;
using CsvAccess.core.Models.Data.Table;
using CsvAccess.core.Models.Persistence;
using CsvAccess.core.Session;
using CsvAccess.core.Table.Data;
using CsvAccess.core.Table.Data.Checksum;
using CsvAccess.core.Table.Data.Checksum.Compare;
using CsvAccess.core.Table.Data.Csv;
using CsvAccess.core.Table.Data.Csv.Convert;
using System.Text.RegularExpressions;

namespace CsvAccess.core.Actions.Checkin
{
    internal class CoreCheckinService : CheckinService
    {
        private SessionService _sessionService;
        private TableCsvService _tableCsvService;
        private ChecksumService _checksumService;
        private DataTableService _dataTableService;

        public CoreCheckinService(SessionService sessionService, TableCsvService tableCsvService, ChecksumService checksumService, DataTableService dataTableService)
        {
            _sessionService = sessionService;
            _tableCsvService = tableCsvService;
            _checksumService = checksumService;
            _dataTableService = dataTableService;
        }

        public CheckinResult CheckinTable(string path)
        {
            DatabaseSession database = _sessionService.DatabaseSession;

            string csv = File.ReadAllText(path);

            IDataTable dataTable = _tableCsvService.FromCsv(csv);

            string checksums = TryGetChecksums(path);
            var checksumComparer = new ChecksumComparer(dataTable, checksums.Split(CsvConstants.LINE_ENDING));

            var result = CheckinResult.NoChange;
            if(checksumComparer.NewDatasets.Count > 0)
            {
                _dataTableService.InsertNewDatasets(_sessionService.DatabaseSession, GetTableNameFromPath(path), dataTable.Columns, checksumComparer.NewDatasets);
                result = CheckinResult.Changes;
            }
            if(checksumComparer.ChangedDatasets.Count > 0)
            {
                _dataTableService.UpdateExistingDatasets(_sessionService.DatabaseSession, GetTableNameFromPath(path), dataTable.Columns, checksumComparer.ChangedDatasets);
                result = CheckinResult.Changes;
            }
            if (checksumComparer.DeletedDatasets.Count > 0)
            {
                _dataTableService.DeleteDatasets(_sessionService.DatabaseSession, GetTableNameFromPath(path), dataTable.Columns, checksumComparer.DeletedDatasets);
                result = CheckinResult.Changes;
            }

            string checksumContent = _checksumService.CreateChecksum(dataTable);
            var pathService = Services.Resolve<PathService>();
            string checksumPath = pathService.GetChecksumPath(GetTableNameFromPath(path));

            TryWriteToDestination(checksumContent, checksumPath);

            return result;
        }

        private string TryGetChecksums(string path)
        {
            return _checksumService.GetChecksumByTableName(GetTableNameFromPath(path));
        }

        private string GetTableNameFromPath(string path)
        {
            Match fileName = Regex.Match(path, @"(/|\\)\w+(\.csv)");
            if (fileName.Success)
            {
                return Regex.Replace(fileName.Value, @"(/|\\|.csv)", string.Empty);
            }
            throw new Exception("invalid filepath");
        }

        private void TryWriteToDestination(string content, string destination)
        {
            try
            {
                File.WriteAllText(destination, content);
            }
            catch (Exception e)
            {
                throw new Exception($"Couldnt write to \"{destination}\". Check if the path is correct. Error: {e}");
            }
        }
    }
}

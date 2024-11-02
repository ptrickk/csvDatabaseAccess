using CsvAccess.core.Configuration.Credentials;
using CsvAccess.core.DependencyInjection;
using CsvAccess.core.Models.Data.Table;
using CsvAccess.core.Session;
using CsvAccess.core.Table.Data;
using CsvAccess.core.Table.Data.Checksum;
using CsvAccess.core.Table.Data.Checksum.Compare;
using CsvAccess.core.Table.Data.Csv;
using CsvAccess.core.Table.Data.Csv.Convert;
using System.Text.RegularExpressions;

namespace CsvAccess.core.Actions.Checkin
{
    internal class CoreCheckinAction : CheckinAction
    {
        private readonly SessionService _sessionService;
        private readonly TableCsvService _tableCsvService;
        private readonly ChecksumService _checksumService;
        private readonly DataTableService _dataTableService;

        public bool DatabaseReliant { get; } = true;

        public CoreCheckinAction(SessionService sessionService, TableCsvService tableCsvService, ChecksumService checksumService, DataTableService dataTableService)
        {
            _sessionService = sessionService;
            _tableCsvService = tableCsvService;
            _checksumService = checksumService;
            _dataTableService = dataTableService;
        }

        public ActionResult Execute(string[] arguments)
        {
            if (arguments.Length != 1)
            {
                throw new ArgumentException("Invalid number of arguments passed for checkin action");
            }
            return CheckinTable(arguments[0]);
        }

        public ActionResult CheckinTable(string path)
        {
            var csv = File.ReadAllText(path);

            IDataTable dataTable = _tableCsvService.FromCsv(csv);

            var checksums = TryGetChecksums(path);
            var checksumComparer = new ChecksumComparer(dataTable, checksums.Split(CsvConstants.LINE_ENDING));

            if(checksumComparer.NewDatasets.Count > 0)
            {
                _dataTableService.InsertNewDatasets(_sessionService.DatabaseSession, GetTableNameFromPath(path), dataTable.Columns, checksumComparer.NewDatasets);
            }
            if(checksumComparer.ChangedDatasets.Count > 0)
            {
                _dataTableService.UpdateExistingDatasets(_sessionService.DatabaseSession, GetTableNameFromPath(path), dataTable.Columns, checksumComparer.ChangedDatasets);
            }
            if (checksumComparer.DeletedDatasets.Count > 0)
            {
                _dataTableService.DeleteDatasets(_sessionService.DatabaseSession, GetTableNameFromPath(path), dataTable.Columns, checksumComparer.DeletedDatasets);
            }

            var checksumContent = _checksumService.CreateChecksum(dataTable);
            var pathService = Services.Resolve<PathService>();
            var checksumPath = pathService.GetChecksumPath(GetTableNameFromPath(path));

            TryWriteToDestination(checksumContent, checksumPath);

            return CoreActionResult.CreateSuccess();
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

using Autofac;
using CsvAccess.core.Configuration.Credentials;
using CsvAccess.core.DependencyInjection;
using CsvAccess.core.Models.Data.Columns;
using CsvAccess.core.Models.Data.Table;
using CsvAccess.core.Models.Persistence;
using CsvAccess.core.Session;
using CsvAccess.core.Table.Columns.Get.ByTable;
using CsvAccess.core.Table.Data;
using CsvAccess.core.Table.Data.Checksum;
using CsvAccess.core.Table.Data.Checksum.Calculate;
using CsvAccess.core.Table.Data.Csv.Convert;
using CsvAccess.core.Table.Data.Csv.Convert.To;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvAccess.core.Actions.Checkout
{
    internal class CoreCheckoutAction : CheckoutAction
    {
        private SessionService _sessionService;
        private DataColumnService _dataColumnService;
        private DataTableService _dataTableService;
        private TableCsvService _tableCsvService;
        private ChecksumService _checksumService;

        public CoreCheckoutAction(SessionService sessionService, DataColumnService dataColumnService, DataTableService dataTableService, TableCsvService tableCsvService, ChecksumService checksumService)
        {
            _sessionService = sessionService;
            _dataColumnService = dataColumnService;
            _dataTableService = dataTableService;
            _tableCsvService = tableCsvService;
            _checksumService = checksumService;
        }
        public ActionResult Execute(string[] arguments)
        {
            if (arguments.Length != 2)
            {
                throw new ArgumentException("Invalid number of arguments passed for checkout action");
            }
            return CheckoutTable(arguments[0], arguments[1]);
        }

        public ActionResult CheckoutTable(string tableName, string destination)
        {
            DatabaseSession database = _sessionService.DatabaseSession;

            IEnumerable<DataColumn> columns = _dataColumnService.GetColumns(database, "testtable");
            IDataTable dataTable = _dataTableService.GetTable(database, "testtable", columns);

            string dataContent = _tableCsvService.ToCsv(dataTable);
            string dataPath = Path.Combine(destination, $"{tableName}.csv");

            string checksumContent = _checksumService.CreateChecksum(dataTable);
            var pathService = Services.Resolve<PathService>();
            string checksumPath = pathService.GetChecksumPath(tableName);

            TryWriteToDestination(dataContent, dataPath);
            TryWriteToDestination(checksumContent, checksumPath);

            return CoreActionResult.CreateSuccess();
        }

        private void TryWriteToDestination(string content, string destination)
        {
            try
            {
                File.WriteAllText(destination, content);
            }
            catch(Exception e)
            {
                throw new Exception($"Couldnt write to \"{destination}\". Check if the path is correct. Error: {e}");
            }
        }
    }
}

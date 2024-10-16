using CsvAccess.core.Models.Data.Columns;
using CsvAccess.core.Models.Data.Table;
using CsvAccess.core.Models.Persistence;
using CsvAccess.core.Table.Columns.Get.ByTable;
using CsvAccess.core.Table.Data;
using CsvAccess.core.Table.Data.Csv.Convert.To;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvAccess.core.Actions.Checkout
{
    internal class CoreCheckoutService : CheckoutService
    {
        private DataColumnService _dataColumnService;
        private DataTableService _dataTableService;

        public DatabaseSession Session { get; private set; }

        public CoreCheckoutService(DataColumnService dataColumnService, DataTableService dataTableService)
        {
            _dataColumnService = dataColumnService;
            _dataTableService = dataTableService;
        }

        public void RegisterSession(DatabaseSession session)
        {
            Session = session;
        }

        public void CheckoutTable(string tableName, string destination)
        {
            if (Session == null)
            {
                throw new Exception($"{nameof(Session)} is not set to an instance");
            }

            IEnumerable<DataColumn> columns = _dataColumnService.GetColumns(Session, "testtable");
            IDataTable dataTable = _dataTableService.GetTable(Session, "testtable", columns);

            var csvConverter = new DataTableToCsvConverter();
            string fileContent = csvConverter.Convert(dataTable);
            string filePath = Path.Combine(destination, $"{tableName}.csv");

            try
            {
                File.WriteAllText(filePath, fileContent);
            }
            catch
            {
                throw new Exception($"Couldnt write to \"{destination}\". Check if the path is correct");
            }

        }
    }
}

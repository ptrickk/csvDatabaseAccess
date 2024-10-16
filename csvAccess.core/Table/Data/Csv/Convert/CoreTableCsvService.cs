using CsvAccess.core.Models.Data.Table;
using CsvAccess.core.Table.Data.Checksum.Calculate;
using CsvAccess.core.Table.Data.Csv.Convert.From;
using CsvAccess.core.Table.Data.Csv.Convert.To;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvAccess.core.Table.Data.Csv.Convert
{
    internal class CoreTableCsvService : TableCsvService
    {
        public IDataTable FromCsv(string csv)
        {
            var tableConverter = new CsvToDataTableConverter();
            return tableConverter.Convert(csv)!;
        }

        public string ToCsv(IDataTable dataTable)
        {
            var csvConverter = new DataTableToCsvConverter();
            return csvConverter.Convert(dataTable);
        }
    }
}

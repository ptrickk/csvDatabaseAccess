using CsvAccess.core.Models.Data.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvAccess.core.Table.Data.Csv.Convert
{
    public interface TableCsvService
    {
        public IDataTable FromCsv(string csv);

        public string ToCsv(IDataTable dataTable);
    }
}

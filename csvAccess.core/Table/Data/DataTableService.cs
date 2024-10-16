using CsvAccess.core.Models.Data.Columns;
using CsvAccess.core.Models.Data.Table;
using CsvAccess.core.Models.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvAccess.core.Table.Data
{
    public interface DataTableService
    {
        IDataTable GetTable(DatabaseSession session, string tableName, IEnumerable<DataColumn> columns);
    }
}

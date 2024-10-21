using CsvAccess.core.Models.Data.Columns;
using CsvAccess.core.Models.Data.Set;
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
        void InsertNewDatasets(DatabaseSession session, string tableName, IEnumerable<DataColumn> columns, IEnumerable<DataSet> dataSets);
        void UpdateExistingDatasets(DatabaseSession session, string tableName, IEnumerable<DataColumn> columns, IEnumerable<DataSet> dataSets);
        void DeleteDatasets(DatabaseSession session, string tableName, IEnumerable<DataColumn> columns, IEnumerable<int> dataSets);
    }
}

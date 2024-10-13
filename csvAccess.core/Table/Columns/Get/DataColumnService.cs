using CsvAccess.core.Models.Data.Columns;

namespace CsvAccess.core.Table.Columns.Get
{
    public interface DataColumnService
    {
        IEnumerable<DataColumn> GetColumns(string tableName);
    }
}

using CsvAccess.core.Models.Data.Columns;

namespace CsvAccess.core.Table.Columns.Get
{
    public interface ITableColumnService
    {
        IEnumerable<DataColumn> GetColumns();

        DataColumn GetColumn(string columnName);
    }
}

using CsvAccess.core.Models.Data.Columns;
using CsvAccess.core.Models.Persistence;

namespace CsvAccess.core.Table.Columns.Get.ByTable
{
    public interface DataColumnService
    {
        IEnumerable<DataColumn> GetColumns(DatabaseSession session, string tableName);
    }
}

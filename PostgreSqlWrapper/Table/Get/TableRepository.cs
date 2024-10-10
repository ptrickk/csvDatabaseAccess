using csvAccess.core.Models.Data.Table;
using CsvAccess.core.Models.Database;

namespace PostgreSqlWrapper.Table.Get
{
    internal class TableRepository : ITableRepository
    {
        public DataTable GetTable(ICredentials credentials, string tableName)
        {
            throw new NotImplementedException();
        }
    }
}

using CsvAccess.core.Models.Data.Columns;
using CsvAccess.core.Table.Columns.Get;
using PostgreSqlWrapper.Connection;

namespace PostgreSqlWrapper.Table.Columns.Get
{
    internal class PostgresTableColumnService : ITableColumnService
    {
        public PostgresTableColumnService(PostgresConnection connection) 
        { 
            
        }

        public DataColumn GetColumn(string columnName)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DataColumn> GetColumns()
        {
            throw new NotImplementedException();
        }
    }
}

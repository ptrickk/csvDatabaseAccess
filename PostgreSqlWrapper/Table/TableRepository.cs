﻿using CsvAccess.core.Models.Data.Table;
using CsvAccess.core.Models.Database;
using PostgreSqlWrapper.Table.Get;

namespace PostgreSqlWrapper.Table
{
    internal class TableRepository : ITableRepository
    {
        public DataTable GetTable(ICredentials credentials, string tableName, string schemaName)
        {
            throw new NotImplementedException();
        }

        public DataTable GetTable(ICredentials credentials, string tableName)
        {
            throw new NotImplementedException();
        }
    }
}

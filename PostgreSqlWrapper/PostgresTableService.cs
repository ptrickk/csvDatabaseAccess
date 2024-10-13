using CsvAccess.core.Models.Data.Table;
using PostgreSqlWrapper.Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostgreSqlWrapper
{
    internal class PostgresTableService
    {
        private PostgresSession _connection;

        public PostgresTableService(PostgresSession connection)
        {
            _connection = connection;
        }

        public DataTable GetTable(string schema, string name)
        {
            throw new NotImplementedException();
        }
    }
}

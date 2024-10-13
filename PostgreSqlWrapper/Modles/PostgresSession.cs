using CsvAccess.core.Models.Data.Columns;
using CsvAccess.core.Models.Data.Table;
using CsvAccess.core.Models.Database;
using Npgsql;
using SqlBuilder;
using System.Collections.Generic;

namespace PostgreSqlWrapper.Connection
{
    internal class PostgresSession : DatabaseSession, IDisposable
    {
        private NpgsqlConnection _connection;
        private PostgresCredentials _credentials;

        public PostgresSession(NpgsqlConnection connection, PostgresCredentials credentials)
        {
            _connection = connection;
            _credentials = credentials;
        }

        public PostgresCredentials Credentials { get { return _credentials; } }

        public void Dispose()
        {
            _connection?.Dispose();
        }

        public NpgsqlDataReader ExecuteQuery(Query query)
        {
            NpgsqlCommand getTableColumnsCommand = new NpgsqlCommand(query.ToString(), _connection);

            return getTableColumnsCommand.ExecuteReader();
        }
    }
}

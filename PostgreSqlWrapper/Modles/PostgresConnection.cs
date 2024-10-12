using Npgsql;

namespace PostgreSqlWrapper.Connection
{
    internal class PostgresConnection : IDisposable
    {
        private NpgsqlConnection _connection;

        public PostgresConnection(NpgsqlConnection connection)
        {
            _connection = connection;
        }

        public void Dispose()
        {
            _connection?.Dispose();
        }
    }
}

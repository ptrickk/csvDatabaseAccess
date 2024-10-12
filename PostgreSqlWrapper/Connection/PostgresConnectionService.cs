using Npgsql;

namespace PostgreSqlWrapper.Connection
{
    internal class PostgresConnectionService
    {
        public PostgresConnectionResult Connect(PostgresConnectionOptions options)
        {
            NpgsqlConnection connection = new NpgsqlConnection(options.Credentials.ConnectionString);

            if(!TryOpenConnection(connection))
            {
                return PostgresConnectionResult.CreateFailure("Connection failed");
            }

            return PostgresConnectionResult.CreateSuccess(new PostgresConnection(connection));
        }

        private bool TryOpenConnection(NpgsqlConnection connection)
        {
            try
            {
                connection.Open();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}

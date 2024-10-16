using CsvAccess.core.Models.Persistence;
using Npgsql;

namespace PostgreSqlWrapper.Connection
{
    internal class PostgresConnectionService : ConnectionService
    {
        public dynamic Connect(dynamic connectionOptions)
        {
            return Connect(connectionOptions);
        }
        
        internal PostgresConnectionResult Connect(PostgresConnectionOptions options)
        {
            var credentials = PostgresCredentials.Convert(options.Credentials);
            NpgsqlConnection connection = new NpgsqlConnection(credentials.ConnectionString);

            if(!TryOpenConnection(connection))
            {
                return PostgresConnectionResult.CreateFailure("Connection failed");
            }

            return PostgresConnectionResult.CreateSuccess(new PostgresSession(connection, credentials));
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

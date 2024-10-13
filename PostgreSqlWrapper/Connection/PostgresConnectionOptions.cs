namespace PostgreSqlWrapper.Connection
{
    internal class PostgresConnectionOptions
    {
        public PostgresCredentials Credentials { get; set; }

        public PostgresConnectionOptions(PostgresCredentials credentials) {  Credentials = credentials; }
    }
}

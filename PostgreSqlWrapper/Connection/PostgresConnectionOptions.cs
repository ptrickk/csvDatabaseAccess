namespace PostgreSqlWrapper.Connection
{
    internal class PostgresConnectionOptions
    {
        public Credentials Credentials { get; set; }

        public PostgresConnectionOptions(Credentials credentials) {  Credentials = credentials; }
    }
}

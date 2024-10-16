using CsvAccess.core.Models.Persistence;

namespace PostgreSqlWrapper.Connection
{
    public class PostgresConnectionOptions : IPostgresConnectionOptions
    {
        public Credentials Credentials { get; set; }

        public static PostgresConnectionOptions Create(Credentials credentials)
        {
            return new PostgresConnectionOptions
            {
                Credentials = credentials
            };
        }

        private PostgresConnectionOptions() { }
    }
}

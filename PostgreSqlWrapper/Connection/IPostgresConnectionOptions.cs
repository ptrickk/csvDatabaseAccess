using CsvAccess.core.Persistence;

namespace PostgreSqlWrapper.Connection
{
    public interface IPostgresConnectionOptions
    {
        public Credentials Credentials { get; set; }
    }
}

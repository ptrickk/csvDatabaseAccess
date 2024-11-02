using CsvAccess.core.Persistence;

namespace PostgreSqlWrapper.Connection
{
    public interface IPostgresConnectionResult
    {
        public bool Succeeded { get; set; }
        public string Message { get; set; }
        public DatabaseSession Session { get; set; }
    }
}

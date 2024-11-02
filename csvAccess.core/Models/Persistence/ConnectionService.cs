namespace CsvAccess.core.Models.Persistence
{
    public interface ConnectionService
    {
        public DatabaseSystem DatabaseSystem { get; }
        public dynamic Connect(dynamic connectionOptions);
    }
}

namespace CsvAccess.core.Persistence
{
    public interface ConnectionService
    {
        public DatabaseStrategy DatabaseStrategy { get; }
        public dynamic Connect(dynamic connectionOptions);
    }
}

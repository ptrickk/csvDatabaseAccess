namespace CsvAccess.core.Models.Persistence
{
    public interface DatabaseSession
    {
        public dynamic ExecuteQuery(dynamic query);
    }
}

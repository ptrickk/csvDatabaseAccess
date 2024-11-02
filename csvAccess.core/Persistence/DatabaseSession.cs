namespace CsvAccess.core.Persistence
{
    public interface DatabaseSession
    {
        public dynamic ExecuteQuery(dynamic query);

        public void ExecuteNonQuery(dynamic query);
    }
}

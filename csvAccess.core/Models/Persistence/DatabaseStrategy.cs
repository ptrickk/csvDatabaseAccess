using CsvAccess.core.Models.Persistence;

namespace CsvAccess.core.Models.Persistence
{
    public interface DatabaseStrategy
    {
        public Credentials Credentials { get; set; }

        public DatabaseSession Session { get; set; }

    }
}

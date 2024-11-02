using CsvAccess.core.Models.Data.Columns;

namespace CsvAccess.core.Models.Data.Field
{
    public interface DataField
    {
        public object Value { get; }
        public DataColumn Column { get; }
        public bool IsPrimary { get; }
    }
}

using CsvAccess.core.Models.Data.Field;

namespace CsvAccess.core.Models.Data.Set
{
    public class DataSet
    {
        public IEnumerable<DataField> Fields { get; set; }

        public DataSet() {  }
    }
}

using csvAccess.core.Models.Data.Field;

namespace csvAccess.core.Models.Data.Set
{
    public class DataSet
    {
        public IEnumerable<IDataField> Fields { get; set; }
    }
}

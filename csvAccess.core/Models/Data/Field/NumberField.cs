using CsvAccess.core.Models.Data.Columns;

namespace CsvAccess.core.Models.Data.Field
{
    public class NumberField : DataFieldBase<int>
    {
        public NumberField(int value, DataColumn column) : base(value, column)
        {
        }
    }
}

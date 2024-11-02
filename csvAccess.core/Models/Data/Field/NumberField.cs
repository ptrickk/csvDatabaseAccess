using CsvAccess.core.Models.Data.Columns;

namespace CsvAccess.core.Models.Data.Field
{
    public class NumberField(int value, DataColumn column) : DataFieldBase<int>(value, column);
}

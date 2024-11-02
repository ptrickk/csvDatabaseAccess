using CsvAccess.core.Models.Data.Columns;

namespace CsvAccess.core.Models.Data.Field
{
    public class DateField(DateTime value, DataColumn column) : DataFieldBase<DateTime>(value, column);
}

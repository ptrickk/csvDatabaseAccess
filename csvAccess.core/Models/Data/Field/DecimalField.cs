using CsvAccess.core.Models.Data.Columns;

namespace CsvAccess.core.Models.Data.Field
{
    public class DecimalField(double value, DataColumn column) : DataFieldBase<double>(value, column);
}

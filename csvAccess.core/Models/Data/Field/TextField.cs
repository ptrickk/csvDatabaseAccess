using CsvAccess.core.Models.Data.Columns;

namespace CsvAccess.core.Models.Data.Field
{
    public class TextField(string value, DataColumn column) : DataFieldBase<string>(value, column);
}

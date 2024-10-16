using CsvAccess.core.Models.Data.Columns;

namespace CsvAccess.core.Models.Data.Field
{
    public class TextField : DataFieldBase<string>
    {
        public TextField(string value, DataColumn column) : base(value, column)
        {
        }
    }
}

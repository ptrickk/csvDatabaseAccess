using CsvAccess.core.Models.Data.Columns;

namespace CsvAccess.core.Models.Data.Field
{
    public class DecimalField : DataField<double>
    {
        public DecimalField(double value, DataColumn column) : base(value, column)
        {
        }
    }
}

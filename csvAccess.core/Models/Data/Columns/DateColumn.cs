using System.Globalization;
using CsvAccess.core.Models.Data.Field;

namespace CsvAccess.core.Models.Data.Columns
{
    public class DateColumn : DataColumn
    {
        public Type DataType => typeof(DateTime);
        public string ColumnName { get; init; }
        public bool IsPrimary { get; init; }

        public DataField GetField(object value)
        {
            return new DateField(DateTime.Parse(value.ToString(), CultureInfo.CurrentCulture), this);
        }

        public int Checksum
        {
            get
            {
                int checksum = 0;
                foreach (char c in ColumnName)
                {
                    checksum += c;
                }
                return checksum;
            }
        }
    }
}

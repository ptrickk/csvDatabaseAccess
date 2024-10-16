using CsvAccess.core.Models.Data.Field;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvAccess.core.Models.Data.Columns
{
    public class DecimalColumn : DataColumn
    {
        public Type DataType { get => typeof(double); }
        public string ColumnName { get; init; }

        public DataField GetField(object value)
        {
            return new DecimalField(Convert.ToDouble(value), this);
        }
    }
}

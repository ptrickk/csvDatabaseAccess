using CsvAccess.core.Models.Data.Field;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvAccess.core.Models.Data.Columns
{
    public class TextColumn : DataColumn
    {
        public Type DataType => typeof(string);

        public string ColumnName { get; init; }

        public DataField GetField(object value)
        {
            return new TextField(Convert.ToString(value), this);
        }
    }
}

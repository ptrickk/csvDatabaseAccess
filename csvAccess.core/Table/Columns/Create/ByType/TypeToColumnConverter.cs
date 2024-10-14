using CsvAccess.core.Models.Data.Columns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvAccess.core.Table.Columns.Create.ByType
{
    internal class TypeToColumnConverter
    {
        internal DataColumn CreateColumn(string columnName, Type dataType)
        {
            if (dataType == typeof(int))
            {
                return new NumberColumn() { ColumnName = columnName };
            }
            else if (dataType == typeof(double))
            {
                return new DecimalColumn() { ColumnName = columnName };
            }
            else if (dataType == typeof(string))
            {
                return new TextColumn() { ColumnName = columnName };
            }

            throw new ArgumentException($"Not supported type: {dataType}");
        }
    }
}

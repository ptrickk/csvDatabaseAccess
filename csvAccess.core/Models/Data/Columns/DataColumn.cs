using CsvAccess.core.Models.Data.Field;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvAccess.core.Models.Data.Columns
{
    public interface DataColumn
    {
        public Type DataType { get; }  
        public string ColumnName { get; init; }
        public int Checksum { get; }
        public DataField GetField(object value);
    }
}

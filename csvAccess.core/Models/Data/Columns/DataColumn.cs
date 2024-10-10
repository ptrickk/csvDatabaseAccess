using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csvAccess.core.Models.Data.Columns
{
    public struct DataColumn
    {
        public Type DataType { get; init; }  
        public string ColumnName { get; init; }
    }
}

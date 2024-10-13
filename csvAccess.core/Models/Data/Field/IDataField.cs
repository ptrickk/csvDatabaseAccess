using CsvAccess.core.Models.Data.Columns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvAccess.core.Models.Data.Field
{
    public interface IDataField
    {
        public object Value { get; }
        public DataColumn Column { get; }
    }
}

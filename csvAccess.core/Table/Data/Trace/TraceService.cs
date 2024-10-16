using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvAccess.core.Table.Data.Trace
{
    public interface TraceService
    {
        public bool CreateTrace(string tableName, DateTime dateTime);

    }
}

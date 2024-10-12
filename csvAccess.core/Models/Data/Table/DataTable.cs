using CsvAccess.core.Models.Data.Columns;
using CsvAccess.core.Models.Data.Set;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvAccess.core.Models.Data.Table
{
    public class DataTable
    {
        public IEnumerable<DataColumn> Columns { get; set; }
        public IEnumerable<DataSet> DataSets { get; set; }
    }
}

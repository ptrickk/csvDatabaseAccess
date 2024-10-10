using csvAccess.core.Models.Data.Columns;
using csvAccess.core.Models.Data.Set;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csvAccess.core.Models.Data.Table
{
    public class DataTable
    {
        public IEnumerable<DataColumn> Columns { get; set; }
        public IEnumerable<DataSet> DataSets { get; set; }
    }
}

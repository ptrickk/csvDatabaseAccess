using CsvAccess.core.Models.Data.Columns;
using CsvAccess.core.Models.Data.Set;

namespace CsvAccess.core.Models.Data.Table
{
    public interface IDataTable 
    {
        public IEnumerable<DataColumn> Columns { get; set; }
        public IEnumerable<DataSet> DataSets { get; set; }
    }
}

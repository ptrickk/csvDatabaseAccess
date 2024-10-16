using CsvAccess.core.Models.Data.Columns;
using CsvAccess.core.Models.Data.Set;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvAccess.core.Models.Data.Table
{
    public class DataTable : IDataTable
    {
        public IEnumerable<DataColumn> Columns { get; set; }
        public IEnumerable<DataSet> DataSets { get; set; }

        public int Checksum
        {
            get
            {
                if(DataSets == null || DataSets.Count() == 0)
                {
                    return 0;
                }

                int[] checksums = DataSets.Select(dataset => dataset.Checksum).ToArray();

                int checksum = checksums[0];
                for(int i = 1; i < checksums.Length; i++)
                {
                    checksum ^= checksums[i];
                }

                return checksum;
            }
        }
    }
}

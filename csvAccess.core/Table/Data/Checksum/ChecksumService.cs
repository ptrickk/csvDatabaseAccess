using CsvAccess.core.Models.Data.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvAccess.core.Table.Data.Checksum
{
    public interface ChecksumService
    {
        public string CreateChecksum(IDataTable dataTable);
    }
}

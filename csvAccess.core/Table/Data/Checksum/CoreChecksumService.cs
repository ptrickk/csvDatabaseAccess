using CsvAccess.core.Models.Data.Table;
using CsvAccess.core.Table.Data.Checksum.Calculate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvAccess.core.Table.Data.Checksum
{
    internal class CoreChecksumService : ChecksumService
    {
        private DataTableChecksumConverter _checksumConverter;

        public CoreChecksumService()
        {
            _checksumConverter = new DataTableChecksumConverter();
        }

        public string CreateChecksum(IDataTable dataTable)
        {
            return _checksumConverter.GetChecksums(dataTable);
        }
    }
}

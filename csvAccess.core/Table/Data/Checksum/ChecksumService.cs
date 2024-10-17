using CsvAccess.core.Models.Data.Table;

namespace CsvAccess.core.Table.Data.Checksum
{
    public interface ChecksumService
    {
        public string CreateChecksum(IDataTable dataTable);

        public string GetChecksumByTableName(string tableName);
    }
}

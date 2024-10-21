using CsvAccess.core.Models.Data.Table;
using CsvAccess.core.Table.Data.Csv;

namespace CsvAccess.core.Table.Data.Checksum.Calculate
{
    internal class DataTableChecksumConverter
    {
        public const string TABLE_CHECKSUM_IDENTIFIER = "t";
        public const string COLUMN_CHECKSUM_IDENTIFIER = "c";
        public const string DATA_CHECKSUM_IDENTIFIER = "d";
        public const string CHECKSUM_SEPERATOR = "_";

        public string GetChecksums(IDataTable table)
        {
            string output = TABLE_CHECKSUM_IDENTIFIER + CHECKSUM_SEPERATOR + table.Checksum.ToString();
            foreach (var column in table.Columns)
            {
                output += $"{CsvConstants.LINE_ENDING}{COLUMN_CHECKSUM_IDENTIFIER}{CHECKSUM_SEPERATOR}{column.Checksum}";
            }

            foreach (var dataSet in table.DataSets)
            {
                var primaryKey = dataSet.Fields.First(field => field.IsPrimary).Value.ToString();
                output += $"{CsvConstants.LINE_ENDING}{DATA_CHECKSUM_IDENTIFIER}{primaryKey}{CHECKSUM_SEPERATOR}{dataSet.Checksum}";
            }
            return output;
        }
    }
}

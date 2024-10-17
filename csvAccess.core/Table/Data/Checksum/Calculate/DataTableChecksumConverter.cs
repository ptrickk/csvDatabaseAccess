using CsvAccess.core.Models.Data.Table;
using CsvAccess.core.Table.Data.Csv;

namespace CsvAccess.core.Table.Data.Checksum.Calculate
{
    internal class DataTableChecksumConverter
    {
        private const string TABLE_CHECKSUM_IDENTIFIER = "t_";
        private const string COLUMN_CHECKSUM_IDENTIFIER = "c_";
        private const string DATA_CHECKSUM_IDENTIFIER = "d";

        public string GetChecksums(IDataTable table)
        {
            string output = TABLE_CHECKSUM_IDENTIFIER + table.Checksum.ToString();
            foreach (var column in  table.Columns)
            {
                output += $"{CsvConstants.LINE_ENDING}{COLUMN_CHECKSUM_IDENTIFIER}{column.Checksum}";
            }

            foreach (var dataSet in table.DataSets)
            {
                var primaryKey = dataSet.Fields.First(field => field.IsPrimary).Value.ToString();
                output += $"{CsvConstants.LINE_ENDING}{DATA_CHECKSUM_IDENTIFIER}{primaryKey}_{dataSet.Checksum}";
            }
            return output;
        }
    }
}

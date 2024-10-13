using CsvAccess.core.Models.Data.Columns;
using CsvAccess.core.Models.Data.Field;
using CsvAccess.core.Models.Data.Table;

namespace CsvAccess.core.Table.Data.Csv.Convert.To
{
    public class DataTableToCsvConverter : IDataTableToCsvConverter
    {
        private const char CSV_COLUMN_SEPERATOR = ';';
        private const string LINE_ENDING = "\r\n";

        public DataTableToCsvConverter() { }

        public string Convert(IDataTable dataTable)
        {
            string csvTable = string.Empty;
            csvTable += GetDoubleRowHeader(dataTable.Columns);

            foreach(var dataSet in dataTable.DataSets)
            {
                string row = string.Empty;

                foreach(var column in dataTable.Columns)
                {
                    IDataField field = dataSet.Fields.First(field => field.Column.Equals(column));
                    row += field.Value.ToString() + CSV_COLUMN_SEPERATOR;
                }
                csvTable += row.Trim(CSV_COLUMN_SEPERATOR) + LINE_ENDING;
            }
            return csvTable.Trim();
        }

        private string GetSingleRowHeader(IEnumerable<DataColumn> columns)
        {
            string header = string.Empty;
            foreach (DataColumn column in columns)
            {
                header += $"{column.ColumnName}[{column.DataType}]{CSV_COLUMN_SEPERATOR}";
            }
            header = header.Trim(';') + LINE_ENDING;

            return header;
        }

        private string GetDoubleRowHeader(IEnumerable<DataColumn> columns)
        {
            string dataTypeRow = string.Empty;
            string columnNameRow = string.Empty;
            foreach (DataColumn column in columns)
            {
                dataTypeRow += $"{column.DataType}{CSV_COLUMN_SEPERATOR}";
                columnNameRow += $"{column.ColumnName}{CSV_COLUMN_SEPERATOR}";
            }
            string header = dataTypeRow.Trim(';') + LINE_ENDING;
            header += columnNameRow.Trim(';') + LINE_ENDING;

            return header;
        }
    }
}

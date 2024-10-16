using CsvAccess.core.Models.Data.Columns;
using CsvAccess.core.Models.Data.Field;
using CsvAccess.core.Models.Data.Table;

namespace CsvAccess.core.Table.Data.Csv.Convert.To
{
    internal class DataTableToCsvConverter : IDataTableToCsvConverter
    {
        public DataTableToCsvConverter() { }

        public string Convert(IDataTable dataTable)
        {
            string csvTable = string.Empty;
            csvTable += GetSingleRowHeader(dataTable.Columns);

            foreach(var dataSet in dataTable.DataSets)
            {
                string row = string.Empty;

                foreach(var column in dataTable.Columns)
                {
                    DataField field = dataSet.Fields.First(field => field.Column.Equals(column));
                    row += field.Value.ToString() + CsvConstants.COLUMN_SEPERATOR;
                }
                csvTable += row.Trim(CsvConstants.COLUMN_SEPERATOR) + CsvConstants.LINE_ENDING;
            }
            return csvTable.Trim();
        }

        private string GetSingleRowHeader(IEnumerable<DataColumn> columns)
        {
            string header = string.Empty;
            foreach (DataColumn column in columns)
            {
                header += $"{column.ColumnName}[{column.DataType}]{CsvConstants.COLUMN_SEPERATOR}";
            }
            header = header.Trim(';') + CsvConstants.LINE_ENDING;

            return header;
        }

        private string GetDoubleRowHeader(IEnumerable<DataColumn> columns)
        {
            string dataTypeRow = string.Empty;
            string columnNameRow = string.Empty;
            foreach (DataColumn column in columns)
            {
                dataTypeRow += $"{column.DataType}{CsvConstants.COLUMN_SEPERATOR}";
                columnNameRow += $"{column.ColumnName}{CsvConstants.COLUMN_SEPERATOR}";
            }
            string header = dataTypeRow.Trim(';') + CsvConstants.LINE_ENDING;
            header += columnNameRow.Trim(';') + CsvConstants.LINE_ENDING;

            return header;
        }
    }
}

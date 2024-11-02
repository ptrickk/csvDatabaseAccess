using CsvAccess.core.Models.Data.Columns;
using CsvAccess.core.Models.Data.Field;
using CsvAccess.core.Models.Data.Set;
using CsvAccess.core.Models.Data.Table;
using CsvAccess.core.Table.Columns.Create.ByType;

namespace CsvAccess.core.Table.Data.Csv.Convert.From
{
    internal class CsvToDataTableConverter : ICsvToDataTableConverter
    {
        public DataTable? Convert(string csv)
        {
            string[] lines = csv.Split(CsvConstants.LINE_ENDING);
            if(lines == null  || lines.Length == 0)
            {
                return null;
            }

            List<string> temp = lines.ToList();
            temp.Remove("");
            lines = temp.ToArray();

            DataTable? result = new DataTable();
            string header = lines[0];
            string[] content = lines[1..];
            result.Columns = GetColumnsFromHeader(header);
            result.DataSets = GetDatasetsFromContent(content, result.Columns);

            return result;
        }

        private List<DataColumn> GetColumnsFromHeader(string header)
        {
            string[] columnDefinitions = header.Split(CsvConstants.COLUMN_SEPERATOR);
            var columns = new List<DataColumn>();

            foreach( var columnDefinition in columnDefinitions)
            {
                string[] columnName_DataType_columnType = columnDefinition.Trim().Split('[');

                string columnName = columnName_DataType_columnType[0];
                string dataTypeValue = columnName_DataType_columnType[1].Trim(']');
                string columnType = columnName_DataType_columnType[2].Trim(']');
                if (columnName_DataType_columnType.Length != 3) 
                {
                    throw new Exception("Header column not in correct format");
                }

                var dataType = Type.GetType(dataTypeValue);
                var typeConverter = new TypeToColumnConverter();

                bool isPrimary = columnType.Equals("p");

                columns.Add(typeConverter.CreateColumn(columnName, dataType, isPrimary));
            }
            return columns;
        }

        private List<DataSet> GetDatasetsFromContent(string[] content, IEnumerable<DataColumn> columns)
        {
            var dataSets = new List<DataSet>();
            var columnsList = columns.ToList();
            foreach (var line in content)
            {
                var dataFields = new List<DataField>();
                string[] fields = line.Split(CsvConstants.COLUMN_SEPERATOR);
                if(fields.Count() != columnsList.Count())
                {
                    throw new Exception("Number of fields doesnt match columns");
                }

                for(int i = 0; i < fields.Length; i++)
                {
                    dataFields.Add(columnsList[i].GetField(fields[i]));
                }

                dataSets.Add(new DataSet() { Fields = dataFields });
            }
            return dataSets;
        }
    }
}

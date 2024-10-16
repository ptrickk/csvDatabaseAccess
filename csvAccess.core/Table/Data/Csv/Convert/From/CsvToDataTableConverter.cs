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

            DataTable? result = new DataTable();
            string header = lines[0];
            string[] content = lines[1..];
            result.Columns = GetColumnsFromHeader(header);
            result.DataSets = GetDatasetsFromContent(content, result.Columns);

            return result;
        }

        public List<DataColumn> GetColumnsFromHeader(string header)
        {
            string[] columnDefinitions = header.Split(CsvConstants.COLUMN_SEPERATOR);
            var columns = new List<DataColumn>();

            foreach( var columnDefinition in columnDefinitions)
            {
                string[] columnName_DataType = columnDefinition.Trim().Split('[');

                string columnName = columnName_DataType[0];
                string dataTypeValue = columnName_DataType[1].Trim(']');
                if (columnName_DataType.Length != 2) 
                {
                    throw new Exception("Header column not in correct format");
                }

                var dataType = Type.GetType(dataTypeValue);
                var typeConverter = new TypeToColumnConverter();

                columns.Add(typeConverter.CreateColumn(columnName, dataType));
            }
            return columns;
        }

        public List<DataSet> GetDatasetsFromContent(string[] content, IEnumerable<DataColumn> columns)
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

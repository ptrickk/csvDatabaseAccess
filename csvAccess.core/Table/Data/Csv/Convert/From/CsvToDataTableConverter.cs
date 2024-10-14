using CsvAccess.core.Models.Data.Columns;
using CsvAccess.core.Models.Data.Table;
using CsvAccess.core.Table.Columns.Create.ByType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvAccess.core.Table.Data.Csv.Convert.From
{
    public class CsvToDataTableConverter : ICsvToDataTableConverter
    {
        public DataTable? Convert(string csv)
        {
            string[] lines = csv.Split(CsvConstants.LINE_ENDING);

            if(lines == null  || lines.Length == 0)
            {
                return null;
            }

            string header = lines[0];

            DataTable? result = new DataTable();
            result.Columns = GetColumnsFromHeader(header);

            return result;
        }

        public IEnumerable<DataColumn> GetColumnsFromHeader(string header)
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
    }
}

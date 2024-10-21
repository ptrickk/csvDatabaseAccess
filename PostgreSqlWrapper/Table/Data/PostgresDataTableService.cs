using CsvAccess.core.Models.Data.Columns;
using CsvAccess.core.Models.Data.Field;
using CsvAccess.core.Models.Data.Set;
using CsvAccess.core.Models.Data.Table;
using CsvAccess.core.Models.Persistence;
using CsvAccess.core.Table.Data;
using Npgsql;
using PostgreSqlWrapper.Connection;
using SqlBuilder;

namespace PostgreSqlWrapper.Table.Data
{
    internal class PostgresDataTableService : DataTableService
    {
        public IDataTable GetTable(DatabaseSession session, string tableName, IEnumerable<DataColumn> columns)
        {
            PostgresCredentials credentials = ((PostgresSession)session).Credentials;
            var columnNamesToSelect = columns.Select(column => column.ColumnName);
            var dataQuery = Query.Create().Select.Fields(columnNamesToSelect).From.Table(TableInSchema(credentials, tableName));

            var reader = session.ExecuteQuery(dataQuery);

            List<DataSet> dataSets = new List<DataSet>();
            while(reader.Read())
            {
                dataSets.Add(GetDatasetFromReader(reader, columns));
            }

            return new DataTable() { Columns = columns, DataSets = dataSets };
        }

        public DataSet GetDatasetFromReader(NpgsqlDataReader reader, IEnumerable<DataColumn> columns)
        {
            List<DataField> fields = new List<DataField>();

            foreach (var column in columns)
            {
                object value = reader[column.ColumnName];
                fields.Add(column.GetField(value));
            }

            return new DataSet() { Fields = fields };
        }

        private string TableInSchema(PostgresCredentials credentials, string tableName)
        {
            return $"{credentials.Schema}.{tableName}";
        }

        public void InsertNewDatasets(DatabaseSession session, string tableName, IEnumerable<DataColumn> columns, IEnumerable<DataSet> dataSets)
        {
            PostgresCredentials credentials = ((PostgresSession)session).Credentials;
            var insertQuery = Query.Create().InsertInto.Table(TableInSchema(credentials, tableName)).Fields(columns.Select(column => column.ColumnName), true).Values;
            int index = 0;
            foreach(var dataSet in dataSets)
            {
                index++;
                insertQuery = insertQuery.Fields(dataSet.Fields.Select(FormatField), true);
                if(index != dataSets.Count())
                {
                    insertQuery = insertQuery.Also;
                }
            }

            session.ExecuteNonQuery(insertQuery);
        }

        public void UpdateExistingDatasets(DatabaseSession session, string tableName, IEnumerable<DataColumn> columns, IEnumerable<DataSet> dataSets)
        {
            throw new NotImplementedException();
        }

        public void DeleteDatasets(DatabaseSession session, string tableName, IEnumerable<DataColumn> columns, IEnumerable<int> dataSets)
        {
            throw new NotImplementedException();
        }

        private string FormatField(DataField field)
        {
            if(field.Column.DataType == typeof(string))
            {
                return $"\'{field.Value}\'";
            }
            else if(field.Column.DataType == typeof(double))
            {
                return field.Value.ToString()!.Replace(",", ".");
            }
            return field.Value.ToString()!;
        }
    }
}

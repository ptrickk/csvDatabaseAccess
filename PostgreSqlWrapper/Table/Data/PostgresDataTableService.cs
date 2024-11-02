using CsvAccess.core.Models.Data.Columns;
using CsvAccess.core.Models.Data.Field;
using CsvAccess.core.Models.Data.Set;
using CsvAccess.core.Models.Data.Table;
using CsvAccess.core.Persistence;
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
            while (reader.Read())
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
            foreach (var dataSet in dataSets)
            {
                index++;
                insertQuery = insertQuery.Fields(dataSet.Fields.Select(FormatField), true);
                if (index != dataSets.Count())
                {
                    insertQuery = insertQuery.Also;
                }
            }

            session.ExecuteNonQuery(insertQuery);
        }

        public void UpdateExistingDatasets(DatabaseSession session, string tableName, IEnumerable<DataColumn> columns, IEnumerable<DataSet> dataSets)
        {
            PostgresCredentials credentials = ((PostgresSession)session).Credentials;
            var updateQueryBase = Query.Create().Update.Table(TableInSchema(credentials, tableName)).Set;

            foreach (var dataSet in dataSets)
            {
                var updateQuery = updateQueryBase;
                var fields = dataSet.Fields.ToArray();
                DataField primaryKey = null; 
                for (int i = 0; i < fields.Count(); i++)
                {
                    if (fields[i].IsPrimary)
                    {
                        primaryKey = fields[i];
                        continue;
                    }

                    updateQuery = updateQuery.Field(fields[i].Column.ColumnName).To.Field(FormatField(fields[i]));
                    if(i < fields.Count() - 1)
                    {
                        updateQuery = updateQuery.Also;
                    }
                }
                updateQuery = updateQuery.Where.Field(primaryKey.Column.ColumnName).Is.Field(FormatField(primaryKey));
                session.ExecuteNonQuery(updateQuery);
            }
        }

        public void DeleteDatasets(DatabaseSession session, string tableName, IEnumerable<DataColumn> columns, IEnumerable<int> dataSets)
        {
            PostgresCredentials credentials = ((PostgresSession)session).Credentials;
            var deleteQuery = Query.Create().Delete.From.Table(TableInSchema(credentials, tableName)).Where;
            var keysToDelete = dataSets.ToList();
            var primaryColumn = columns.First(column => column.IsPrimary);

            for (int i = 0; i < keysToDelete.Count(); i++)
            {
                deleteQuery = deleteQuery.Field(primaryColumn.ColumnName).Is.Value(keysToDelete[i]);
                if (i < keysToDelete.Count() - 1)
                {
                    deleteQuery = deleteQuery.Or;
                }
            }
            session.ExecuteNonQuery(deleteQuery);
        }

        private string FormatField(DataField field)
        {
            if (field.Column.DataType == typeof(string) || field.Column.DataType == typeof(DateTime))
            {
                return $"\'{field.Value}\'";
            }
            else if (field.Column.DataType == typeof(double))
            {
                return field.Value.ToString()!.Replace(",", ".");
            }
            return field.Value.ToString()!;
        }
    }
}

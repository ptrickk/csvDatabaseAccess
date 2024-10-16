using CsvAccess.core.Models.Data.Columns;
using CsvAccess.core.Models.Persistence;
using CsvAccess.core.Table.Columns.Get.ByTable;
using Npgsql;
using PostgreSqlWrapper.Connection;
using SqlBuilder;
using System.Data.Common;

namespace PostgreSqlWrapper.Table.Columns
{
    internal class PostgresDataColumnService : DataColumnService
    {
        private const string COLUMN_NAME_FIELD = "COLUMN_NAME";
        private const string DATA_TYPE_FIELD = "DATA_TYPE";
        private const string INFORMATION_SCHEMA_NAME = "INFORMATION_SCHEMA";
        private const string COLUMNS_TABLE_NAME = "COLUMNS";
        private const string TABLE_SCHEMA_FIELD = "TABLE_SCHEMA";
        private const string TABLE_NAME_FIELD = "TABLE_NAME";

        private const string INTEGER_FIELD_VALUE = "integer";
        private const string DOUBLE_FIELD_VALUE = "numeric";
        private const string STRING_FIELD_VALUE = "text";

        public DataColumn GetColumn(string columnName)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DataColumn> GetColumns(DatabaseSession session, string tableName)
        {
            PostgresCredentials credentials = ((PostgresSession)session).Credentials;
            var columnQuery = Query.Create().Select.Fields([COLUMN_NAME_FIELD, DATA_TYPE_FIELD]).
                From.Table(TableInSchema(INFORMATION_SCHEMA_NAME, COLUMNS_TABLE_NAME)).
                Where.Field(TABLE_SCHEMA_FIELD).Is.Value(credentials.Schema).
            And.Field(TABLE_NAME_FIELD).Is.Value(tableName);

            using NpgsqlDataReader reader = session.ExecuteQuery(columnQuery);

            List<DataColumn> columns = new();
            while (reader.Read())
            {
                columns.Add(GetColumnFromReader(reader));
            }
            return columns;
        }
        private string TableInSchema(string schemaName, string tableName)
        {
            return $"{schemaName}.{tableName}";
        }

        private DataColumn GetColumnFromReader(NpgsqlDataReader reader)
        {
            string columnNameField = Convert.ToString(reader[COLUMN_NAME_FIELD]) ?? string.Empty;
            string dataTypeField = Convert.ToString(reader[DATA_TYPE_FIELD]);
            Type dataType;

            switch (dataTypeField)
            {
                case INTEGER_FIELD_VALUE:
                    return new NumberColumn() { ColumnName = columnNameField };
                case DOUBLE_FIELD_VALUE:
                    return new DecimalColumn() { ColumnName = columnNameField };
                case STRING_FIELD_VALUE:
                    return new TextColumn() { ColumnName = columnNameField };
                default:
                    throw new Exception($"Not supported datatype: {dataTypeField}");
            }
        }
    }
}

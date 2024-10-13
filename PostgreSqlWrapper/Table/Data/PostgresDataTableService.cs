using CsvAccess.core.Models.Data.Columns;
using CsvAccess.core.Models.Data.Field;
using CsvAccess.core.Models.Data.Set;
using CsvAccess.core.Models.Data.Table;
using CsvAccess.core.Table.Data;
using Npgsql;
using PostgreSqlWrapper.Connection;
using SqlBuilder;

namespace PostgreSqlWrapper.Table.Data
{
    internal class PostgresDataTableService : DataTableService
    {
        private PostgresSession _session;

        public PostgresDataTableService(PostgresSession session)
        {
            _session = session;
        }

        public IDataTable GetTable(string tableName, IEnumerable<DataColumn> columns)
        {
            var columnNamesToSelect = columns.Select(column => column.ColumnName);
            var dataQuery = Query.Create().Select.Fields(columnNamesToSelect).From.Table(TableInSchema(tableName));

            var reader = _session.ExecuteQuery(dataQuery);

            List<DataSet> dataSets = new List<DataSet>();
            while(reader.Read())
            {
                dataSets.Add(GetDatasetFromReader(reader, columns));
            }

            return new DataTable() { Columns = columns, DataSets = dataSets };
        }

        public DataSet GetDatasetFromReader(NpgsqlDataReader reader, IEnumerable<DataColumn> columns)
        {
            DataSet dataSetFromRow = new DataSet();

            List<IDataField> fields = new List<IDataField>();
            List<DataField<int>> integerFields = new();
            List<DataField<double>> doubleFields = new();
            List<DataField<int>> stringFields = new();

            foreach (var column in columns)
            {
                object value = reader[column.ColumnName];
                fields.Add(column.GetField(value));
            }

            return new DataSet() { Fields = fields };
        }

        private string TableInSchema(string tableName)
        {
            return $"{_session.Credentials.Schema}.{tableName}";
        }
    }
}

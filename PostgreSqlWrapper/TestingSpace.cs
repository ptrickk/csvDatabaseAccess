using CsvAccess.core.Credentials;
using CsvAccess.core.Table.Data.Csv.Convert.To;
using PostgreSqlWrapper.Connection;
using PostgreSqlWrapper.Table.Columns;
using PostgreSqlWrapper.Table.Data;

namespace PostgreSqlWrapper
{
    public class TestingSpace
    {

        public static void Demo()
        {
            string filepath = @"C:\Users\geert\Documents\Projects\csvDatabaseAccess\credentials.txt";
            string output = @"C:\Users\geert\Documents\Projects\csvDatabaseAccess\test.csv";
            var credentialsService = new CredentialsService();
            var postgresConnectionService = new PostgresConnectionService();
            var options = new PostgresConnectionOptions((PostgresCredentials)credentialsService.GetCredentials(filepath));
            var result = postgresConnectionService.Connect(options);

            if (!result.Succeeded)
            {
                return;
            }

            var pgSession = result.Session;

            var columnService = new PostgresDataColumnService(pgSession);
            var columns = columnService.GetColumns("testtable");

            var dataService = new PostgresDataTableService(pgSession);
            var dataTable = dataService.GetTable("testtable", columns);

            DataTableToCsvConverter converter = new DataTableToCsvConverter();

            string csvTable = converter.Convert(dataTable);
            Console.WriteLine(csvTable);
            File.WriteAllText(output, csvTable);
            Console.ReadKey();
        }
    }
}

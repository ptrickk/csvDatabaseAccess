using CsvAccess.core.Credentials;
using Npgsql;
using PostgreSqlWrapper.Connection;
using System.Net.Sockets;

namespace PostgreSqlWrapper
{
    public class TestingSpace
    {

        public static void Demo()
        {
            string filepath = @"C:\Users\geert\Documents\Projects\csvDatabaseAccess\credentials.txt";
            var credentialsService = new CredentialsService();
            var postgresConnectionService = new PostgresConnectionService();
            var options = new PostgresConnectionOptions((Credentials)credentialsService.GetCredentials(filepath));
            var result = postgresConnectionService.Connect(options);

            if (!result.Succeeded)
            {
                return;
            }

            var pgConnection = result.Connection;

            Console.WriteLine("Enter postgres pwd");
            var pwd = Console.ReadLine();
            string connectionString = $"Host=localhost;Port=5432;Database=postgres;User Id=patrick;Password={pwd};";
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                }catch(NpgsqlException postgresException)
                {
                   Console.WriteLine (postgresException.ToString());
                    return;
                }
               
                using NpgsqlCommand command = new NpgsqlCommand("SELECT COLUMN_NAME, DATA_TYPE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_SCHEMA = 'testschema' AND TABLE_NAME = 'testtable';", connection);

                using NpgsqlDataReader reader = command.ExecuteReader();

                Console.WriteLine("\nTest output:");
                while (reader.Read())
                {
                    Console.WriteLine(reader["COLUMN_NAME"]);
                    // Use the fetched results
                }
            }
        }
        
        //using NpgsqlConnection connection = new NpgsqlConnection(connectionString);
    }
}

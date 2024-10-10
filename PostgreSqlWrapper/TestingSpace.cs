using Npgsql;

namespace PostgreSqlWrapper
{
    public class TestingSpace
    {

        public static void Demo()
        {
            Console.WriteLine("Enter postgres pwd");
            var pwd = Console.ReadLine();
            string connectionString = $"Host=localhost;Port=5432;Database=postgres;User Id=patrick;Password={pwd};";
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                using NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM testschema.testtable", connection);

                using NpgsqlDataReader reader = command.ExecuteReader();

                Console.WriteLine("\nTest output:");
                while (reader.Read())
                {
                    Console.WriteLine(reader["name"]);
                    // Use the fetched results
                }
            }
        }
        
        //using NpgsqlConnection connection = new NpgsqlConnection(connectionString);
    }
}

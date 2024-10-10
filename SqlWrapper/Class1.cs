using Npgsql;

namespace SqlWrapper
{
    public class Class1
    {

        public void Demo()
        {
            string connectionString = "Host=my_host;Port = port_number;Database = database_name;User Id = username;Password = password; ";
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                using NpgsqlCommand command = new NpgsqlCommand();
            }
        }
        
        //using NpgsqlConnection connection = new NpgsqlConnection(connectionString);
    }
}

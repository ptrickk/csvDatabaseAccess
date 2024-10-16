using CsvAccess.core.Models.Persistence;

namespace PostgreSqlWrapper
{
    internal record PostgresCredentials : Credentials
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Host {  get; set; }
        public string Port { get; set; }
        public string Database { get; set; }
        public string Schema { get; set; }

        public string ConnectionString => $"Host={Host};Port={Port};Database={Database};User Id={Username};Password={Password};";

        internal static PostgresCredentials Convert(Credentials credentials)
        {
            return (PostgresCredentials) credentials;
        }
    }
}

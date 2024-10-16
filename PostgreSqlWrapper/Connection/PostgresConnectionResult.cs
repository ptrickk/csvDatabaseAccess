using CsvAccess.core.Models.Persistence;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostgreSqlWrapper.Connection
{
    internal class PostgresConnectionResult : IPostgresConnectionResult
    {
        public bool Succeeded { get; set; }
        public string Message { get; set; }
        public DatabaseSession Session { get; set; }

        public static PostgresConnectionResult CreateSuccess(DatabaseSession connection)
        {
            return new PostgresConnectionResult
            {
                Succeeded = true,
                Session = connection
            };
        }

        public static PostgresConnectionResult CreateFailure(string message)
        {
            return new PostgresConnectionResult
            {
                Succeeded = false,
                Message = message
            };
        }
    }
}

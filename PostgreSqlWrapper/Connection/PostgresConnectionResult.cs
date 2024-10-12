using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostgreSqlWrapper.Connection
{
    internal class PostgresConnectionResult
    {
        public bool Succeeded { get; set; }
        public string Message { get; set; }
        public PostgresConnection Connection { get; set; }

        public static PostgresConnectionResult CreateSuccess(PostgresConnection connection)
        {
            return new PostgresConnectionResult
            {
                Succeeded = true,
                Connection = connection
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

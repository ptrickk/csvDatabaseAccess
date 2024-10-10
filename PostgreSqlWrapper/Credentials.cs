using CsvAccess.core.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostgreSqlWrapper
{
    internal record Credentials : ICredentials
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Host {  get; set; }
        public int Port { get; set; }
        public string Database { get; set; }
    }
}

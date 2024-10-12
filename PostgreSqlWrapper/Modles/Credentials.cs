using CsvAccess.core.Models.Database;
using System;
using System.Collections.Generic;
using System.Data.Common;
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
        public string Port { get; set; }
        public string Database { get; set; }

        public string ConnectionString => $"Host={Host};Port={Port};Database={Database};User Id={Username};Password={Password};";
    }
}

using CsvAccess.core.Models.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostgreSqlWrapper.Connection
{
    public interface IPostgresConnectionOptions
    {
        public Credentials Credentials { get; set; }
    }
}

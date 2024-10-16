using CsvAccess.core.Models.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostgreSqlWrapper.Connection
{
    public interface IPostgresConnectionResult
    {
        public bool Succeeded { get; set; }
        public string Message { get; set; }
        public DatabaseSession Session { get; set; }
    }
}

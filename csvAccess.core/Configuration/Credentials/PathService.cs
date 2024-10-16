using CsvAccess.core.Models.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvAccess.core.Configuration.Credentials
{
    public interface PathService
    {
        public string GetCredentialsPath(DatabaseSystem database);
    }
}

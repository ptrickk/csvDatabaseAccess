using CsvAccess.core.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvAccess.core.Credentials
{
    public interface ICredentialsService
    {
        public ICredentials GetCredentials(string filepath);
    }
}

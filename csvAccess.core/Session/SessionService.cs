using CsvAccess.core.Models.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvAccess.core.Session
{
    public interface SessionService
    {
        public DatabaseSession DatabaseSession { get; }

        public void RegisterDatabaseSession(DatabaseSession databaseSession);
    }
}

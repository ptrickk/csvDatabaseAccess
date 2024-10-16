using CsvAccess.core.Models.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvAccess.core.Session
{
    internal class CoreSessionService : SessionService
    {
        public DatabaseSession DatabaseSession {  get; private set; }

        public void RegisterDatabaseSession(DatabaseSession databaseSession)
        {
            DatabaseSession = databaseSession;
        }
    }
}

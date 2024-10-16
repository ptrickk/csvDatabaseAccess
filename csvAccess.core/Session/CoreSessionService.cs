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
        private DatabaseSession _databaseSession;
        public DatabaseSession DatabaseSession
        {
            get
            {
                if (_databaseSession == null)
                {
                    throw new Exception("No DatabaseSession registered");
                }
                return _databaseSession;
            } private set
            {
                _databaseSession = value;
            }
        }

        public void RegisterDatabaseSession(DatabaseSession databaseSession)
        {
            DatabaseSession = databaseSession;
        }
    }
}

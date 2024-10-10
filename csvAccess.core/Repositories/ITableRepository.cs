using csvAccess.core.Models.Data.Table;
using CsvAccess.core.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostgreSqlWrapper.Table.Get
{
    public interface ITableRepository
    {
        public DataTable GetTable(ICredentials credentials, string tableName);
    }
}

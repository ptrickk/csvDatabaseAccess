using CsvAccess.core.Models.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvAccess.core.Actions.Checkout
{
    public interface CheckoutService
    {
        public DatabaseSession Session { get; }
        public void RegisterSession(DatabaseSession session);
        public void CheckoutTable(string tableName, string destination);
    }
}

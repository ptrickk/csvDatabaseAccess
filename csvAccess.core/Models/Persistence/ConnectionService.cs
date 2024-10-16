using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvAccess.core.Models.Persistence
{
    public interface ConnectionService
    {
        public dynamic Connect(dynamic connectionOptions);
    }
}

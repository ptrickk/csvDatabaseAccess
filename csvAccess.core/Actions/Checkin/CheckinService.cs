using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvAccess.core.Actions.Checkin
{
    public enum CheckinResult
    {
        NoChange,
        Changes,
        Error
    }

    public interface CheckinService
    {
        public CheckinResult CheckinTable(string path);
    }
}

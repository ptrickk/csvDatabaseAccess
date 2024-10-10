using csvAccess.core.Models.Data.Columns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csvAccess.core.Models.Data.Field
{
    public interface IDataField
    {
        public Type DataType { get; }
        public DataColumn Column { get; }
    }
}

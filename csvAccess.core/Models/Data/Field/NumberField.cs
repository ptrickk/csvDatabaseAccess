using CsvAccess.core.Models.Data.Columns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvAccess.core.Models.Data.Field
{
    public class NumberField : DataFieldBase<int>
    {
        public NumberField(int value, DataColumn column) : base(value, column)
        {
        }
    }
}

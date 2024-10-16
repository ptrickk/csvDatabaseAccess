using CsvAccess.core.Models.Data.Field;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvAccess.core.Models.Data.Columns
{
    public class NumberColumn : DataColumn
    {
        public Type DataType => typeof(int);

        public string ColumnName { get; init; }

        public DataField GetField(object value)
        {
            return new NumberField(Convert.ToInt32(value), this);
        }

        public int Checksum
        {
            get
            {
                int checksum = 0;
                foreach (char c in ColumnName)
                {
                    checksum += c;
                }
                return checksum;
            }
        }
    }
}

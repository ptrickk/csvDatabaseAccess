using CsvAccess.core.Models.Data.Columns;

namespace CsvAccess.core.Models.Data.Field
{
    public abstract class DataFieldBase<T> : DataField
    {
        public T Value { get; set; }
        public DataColumn Column { get; set; }
        object DataField.Value => Value;

        protected DataFieldBase(T value, DataColumn column)
        {
            if(typeof(T) != column.DataType)
            {
                throw new ArgumentException($"Colum datatype [{column.DataType}] doesn't match [{typeof(T)}]");
            }
            Value = value; 
            Column = column;
        }
    }
}

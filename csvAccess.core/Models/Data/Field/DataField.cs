using CsvAccess.core.Models.Data.Columns;

namespace CsvAccess.core.Models.Data.Field
{
    public abstract class DataField<T> : IDataField
    {
        public T Value { get; set; }
        public Type DataType => throw new Exception();
        public DataColumn Column => throw new NotImplementedException();
        protected DataField(T value) { Value = value; }
    }
}

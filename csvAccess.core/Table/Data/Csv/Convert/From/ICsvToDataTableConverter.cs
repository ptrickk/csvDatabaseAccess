using CsvAccess.core.Models.Data.Table;

namespace CsvAccess.core.Table.Data.Csv.Convert.From
{
    public interface ICsvToDataTableConverter
    {
        public DataTable Convert(string csv);
    }
}

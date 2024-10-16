using CsvAccess.core.Models.Data.Field;

namespace CsvAccess.core.Models.Data.Set
{
    public class DataSet
    {
        public IEnumerable<DataField> Fields { get; set; }

        public DataSet() {  }

        public int Checksum
        {
            get
            {
                int checksum = 0;
                if(Fields == null || Fields.Count() == 0)
                {
                    return checksum;
                }

                foreach (DataField field in Fields)
                {
                    string text = Convert.ToString(field.Value);
                    foreach(char c in text)
                    {
                        checksum += c;
                    }
                }
                return checksum;
            }
        }
    }
}

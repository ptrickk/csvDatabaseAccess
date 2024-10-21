using CsvAccess.core.Models.Data.Set;
using CsvAccess.core.Models.Data.Table;
using CsvAccess.core.Table.Data.Checksum.Calculate;
using CsvAccess.core.Table.Data.Csv;

namespace CsvAccess.core.Table.Data.Checksum.Compare
{
    internal class ChecksumComparer
    {
        private IDataTable _dataTable;
        private string[] _checksums;

        public ChecksumComparer(IDataTable dataTable, string[] checksums)
        {
            _dataTable = dataTable;
            _checksums = checksums;
        }

        public bool CheckIfTableChanged
        {
            get
            {
                string firstChecksum = _checksums[0];
                if (!firstChecksum.StartsWith(DataTableChecksumConverter.TABLE_CHECKSUM_IDENTIFIER))
                {
                    throw new Exception("Corrupted checksum file. Please checkout table again before checling in");
                }
                int tableChecksum = GetChecksumValue(firstChecksum);

                return tableChecksum == _dataTable.Checksum;
            }

        }

        public bool CheckIfColumnsChanged
        {
            get
            {
                int[] checksumColumns = _checksums
                    .Where(checksum => checksum.StartsWith(DataTableChecksumConverter.COLUMN_CHECKSUM_IDENTIFIER))
                    .Select(GetChecksumValue).ToArray();

                int[] actualColumns = _dataTable.Columns.Select(column => column.Checksum).ToArray();
                if(actualColumns.Length != checksumColumns.Length)
                {
                    return true;
                }

                foreach (int checksumColumn in checksumColumns)
                {
                    if (!actualColumns.Contains(checksumColumn))
                    {
                        return true;
                    }
                }

                return false;
            }
        }

        private Dictionary<int, int> _checksumsByPrimaryKey;
        private Dictionary<int, int> ChecksumsByPrimaryKey
        {
            get
            {
                if(_checksumsByPrimaryKey != null )
                {
                    return _checksumsByPrimaryKey;
                }

                _checksumsByPrimaryKey = new Dictionary<int, int>();
                string[] checksumRows = _checksums
                    .Where(checksum => checksum.StartsWith(DataTableChecksumConverter.DATA_CHECKSUM_IDENTIFIER)).ToArray();

                foreach (string checksumRow in checksumRows)
                {
                    string[] c = checksumRow.Trim('d').Split(DataTableChecksumConverter.CHECKSUM_SEPERATOR);
                    if (c.Length != 2)
                    {
                        throw new Exception("to many \"_\" in checksum");
                    }

                    _checksumsByPrimaryKey.Add(int.Parse(c[0]), int.Parse(c[1]));
                }

                return _checksumsByPrimaryKey;
            }
        }

        private List<DataSet> _newDatasets;
        public List<DataSet> NewDatasets
        {
            get
            {
                if (_newDatasets == null)
                {
                    CompareChecksums();
                }
                return _newDatasets;
            }
        }

        private List<int> _deletedDatasets;
        public List<int> DeletedDatasets
        {
            get
            {
                if (_deletedDatasets == null)
                {
                    CompareChecksums();
                }
                return _deletedDatasets;
            }
        }

        private List<DataSet> _changedDatasets;
        public List<DataSet> ChangedDatasets
        {
            get
            {
                if (_changedDatasets == null)
                {
                    CompareChecksums();
                }
                return _changedDatasets;
            }
        }

        private List<DataSet> _unchangedDatasets;

        private void CompareChecksums()
        {
            _newDatasets = new();
            _deletedDatasets = new();
            _changedDatasets = new();
            _unchangedDatasets = new();

            var checksumCopies = ChecksumsByPrimaryKey;
            var datasetCopies = _dataTable.DataSets;
            foreach (var dataSet in datasetCopies)
            {
                bool doesChecksumsContainDataSet = checksumCopies.ContainsKey(dataSet.PrimaryKey);
                if (!doesChecksumsContainDataSet)
                {
                    _newDatasets.Add(dataSet);
                }
                else
                {
                    int checksum = checksumCopies[dataSet.PrimaryKey];
                    if(checksum != dataSet.Checksum)
                    {
                        _changedDatasets.Add(dataSet);
                    }
                    else
                    {
                        _unchangedDatasets.Add(dataSet);
                    }
                    checksumCopies.Remove(dataSet.PrimaryKey);
                }
            }

            foreach (KeyValuePair<int, int> checksum in checksumCopies)
            {
                _deletedDatasets.Add(checksum.Key);
            }
        }

        public int GetChecksumValue(string checksum)
        {
            string[] subParts = checksum.Split(DataTableChecksumConverter.CHECKSUM_SEPERATOR);

            if (subParts.Length != 2)
            {
                throw new Exception("to many \"_\" in checksum");
            }

            return int.Parse(subParts[1]);
        }
    }
}

using CsvAccess.core.Configuration.Credentials;
using CsvAccess.core.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvAccess.core.Validation
{
    internal class CopyValidationStrategy : ValidationStrategy
    {
        private readonly PathService _pathService;

        public CopyValidationStrategy(PathService pathService)
        {
            _pathService = pathService;
        }

        public void CreateValidation()
        {
            throw new NotImplementedException();
        }

        public void Validate()
        {
            throw new NotImplementedException();
        }
    }
}

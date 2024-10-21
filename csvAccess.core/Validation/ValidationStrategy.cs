using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvAccess.core.Update
{
    public interface ValidationStrategy
    {
        public void CreateValidation();

        public void Validate();
    }
}

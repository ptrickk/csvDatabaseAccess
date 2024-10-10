﻿using csvAccess.core.Models.Data.Columns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csvAccess.core.Models.Data.Field
{
    public class NumberField : DataField<int>
    {
        public NumberField(int value) : base(value)
        {
        }
    }
}

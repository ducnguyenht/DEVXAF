﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMS.BusinessObjects.Base.BusinessRules
{
    
    // enum of operators that can be used in validation rules
    
    public enum ValidationOperator
    {
        Equal, 
        NotEqual, 
        GreaterThan, 
        GreaterThanEqual, 
        LessThan, 
        LessThanEqual
    }
}

/*
 * Description:This file is used to record which method to call object and contains a enum EnumInstanceScope.
 * Author:Zhang HeKe
 * Create Date:2007-5-28
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace FastStructure.LAF.Core.Config
{
    /// <summary>
    /// Description: This enum is used to record which method to call object
    /// Author:Zhang HeKe
    /// Create Date:2007-5-28 
    /// <summary>
    public enum EnumInstanceScope
    {
        SINGLETON,
        PROTOTYPE,
        REQUEST
    }
}

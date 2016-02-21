/*
 * Description:This file contains a class LAFBuilderFactory to maintain the instance of LAFBuilder.
 * Author: Zhang HeKe
 * Create Date:2007-5-30
 */
using System;
using System.Collections.Generic;
using System.Text;

namespace FastStructure.LAF.Core
{
    /// <summary>
    /// Description:This class is used to maintain the instance of LAFBuilder.
    /// Author:Zhang HeKe
    /// Create Date:2007-5-30
    /// </summary>
    public class LAFBuilderFactory
    {
        public static ILAFBuilder GetILAFBuilder()
        {
            return new LAFBuilder();
        }
    }
}

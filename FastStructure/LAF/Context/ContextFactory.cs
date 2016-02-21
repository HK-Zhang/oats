/*
 * Description:This file contains a class ContextFactory to maintain the instance of ContextFactory.
 * Author: Zhang HeKe
 * Create Date:2007-5-30
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace FastStructure.LAF.Context
{
    /// <summary>
    /// Description:This class supply ContextFactory create instance method
    /// Author: Zhang HeKe
    /// Create Date:2007-5-30
    /// </summary>
    public class ContextFactory
    {
        /// <summary>
        /// create a new type of IContext instance
        /// </summary>
        /// <returns>IContext type new instance</returns>
        public static IContext GetIContext()
        {
            return new LAFContext();
        }
    }
}

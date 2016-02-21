/*
 * Description:This file contains a interface IContextAware which is used to implement by the child of class.
 * Author: Zhang HeKe
 * Create Date:2007-5-28
 */
using System;
using System.Collections.Generic;
using System.Text;

namespace FastStructure.LAF.Context
{
    /// <summary>
    /// Description:This interface supply core functions of IContextAware
    /// Author: Zhang HeKe
    /// Create Date:2007-5-28
    /// </summary>
    public interface IContextAware
    {
        /// <summary>
        /// get and or method of Context property value
        /// </summary>
        IContext Context
        {
            get;
            set;
        }
    }
}

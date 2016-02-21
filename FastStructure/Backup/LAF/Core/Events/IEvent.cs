/*
 * Description:This file contains a interface IEvent to supply some core functions to implement
 * Author: Zhang HeKe
 * Create Date:2007-5-28
 */
using System;
using System.Collections.Generic;
using System.Text;

namespace FastStructure.LAF.Core.Events
{
    /// <summary>
    /// Description:This interface supply some method and property for child class to implement
    /// Author: Zhang HeKe
    /// Create Date:2007-5-28
    /// </summary>
    public interface IEvent
    {
        /// <summary>
        /// supply get or set method of Sender property value
        /// </summary>
        object Sender
        {
            get;
            set;
        }
    }
}

/*
 * Description:This file contains a interface to supply some method and property 
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
    public interface IListener
    {
        /// <summary>
        /// Supply Receive listener method
        /// </summary>
        /// <param name="eventItem">eventItem</param>
        void Receive(IEvent eventItem);
    }
}
